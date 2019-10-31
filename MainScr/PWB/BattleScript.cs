using UnityEngine;
using System.IO;

public class BattleScript : MonoBehaviour
{
    public DisplayBattleValues displayBattleValues;
    public SupplementForHeroBody supplementForHero;
    public SupplementForEnemyBody supplementForEnemy;
    public GeneralSettings localization;
    public PatrsBodyHero patrsBodyHero;
    public Cleaning cleaning;
    public RoomManager roomManager;
    public SDialForBattle sDialForBattle;
    public AudioCry audioCry;

    public CharacteristicsEnemy characteristicsEnemy;

    public string NameEnemy;
    string EnemyClass;
    string EnemyAction;

    [HideInInspector]
    public float AttackEnemy;
    public float FullHealthEnemy;
    public float CurrentHealthEnemy;
    public float MaxAttackEnemy;
    public float MaxArmorEnemy;
    public float BlockEnemy;
    float AllDefenseEnemy;
    float CurrentArmorEnemy;
    float DefenseEnemy;

    int EnemyMiss;
    int ActionSelectionVariable;
    int HealthThresholdVariable;

    bool CriticalDamageEnemy;

    public CharacteristicsHero characteristicsHero;

    public string HeroName;
    string HeroAction;

    [HideInInspector]
    public float AttackHero;
    public float FullHealthHero;
    public float CurrentHealthHero;
    public float MaxAttackHero;
    public float MinAttackHero;
    public float MaxArmorHero;
    public float MinArmorHero;
    public float MaxAbilityHero;
    public float MinAbilityHero;
    public float BlockHero;
    float PotionX;
    float AbilityHero;
    float ArcherAttack;
    float AllDefenseHero;
    float CurrentArmorHero;
    float DefenseHero;
    float timeFB;

    int HeroMiss;

    bool CriticalDamageHero;

    string FirstAttack;
    bool SwitchRandomHTV;
    int number = 0;

    [HideInInspector] public int NumberOfActionsZero = 0;
    [HideInInspector] public int NumberOfActionsOne = 0;
    [HideInInspector] public int NumberOfActionsTwo = 0;
    [HideInInspector] public int NumberOfActionsThree = 0;
    [HideInInspector] public int NumberOfActionsFive = 0;

    // выбирает кто первый будет нападать   
    private static System.Random RandomChoiceWhoFirstActs = new System.Random();
    private static System.Random RandomlyChosenEnemyAction = new System.Random();
    // for foe
    private static System.Random RandomlyChosenRandomlySelectedHealthThresholdForSwitch = new System.Random();
    private static System.Random MinDamageEnemy = new System.Random();
    private static System.Random CurrentDamageEnemy = new System.Random();
    private static System.Random RandomSelectedEnemyBodyPart = new System.Random();
    private static System.Random RandomlySelectedDamageFoeEnemy = new System.Random();
    private static System.Random RandomEnemyMiss = new System.Random();
    private static System.Random RandomEnemyHealth = new System.Random();
    private static System.Random RandomEnemyAttack = new System.Random();
    private static System.Random RandomEnemyArmor = new System.Random();
    private static System.Random RandomEnemyBlock = new System.Random();
    private static System.Random RandomBlockEnemy = new System.Random();
    // for hero
    private static System.Random MinDamageHero = new System.Random();
    private static System.Random CurrentDamageHero = new System.Random();
    private static System.Random MinAbilityDamageHero = new System.Random();
    private static System.Random CurrentAbilityDamageHero = new System.Random();
    private static System.Random RandomArmorHero = new System.Random();
    private static System.Random RandomMinArmorHero = new System.Random();
    private static System.Random RandomBlockHero = new System.Random();
    private static System.Random RandomHeroMiss = new System.Random();
    private static System.Random RandomlySelectedDamage = new System.Random();
    private static System.Random RandomSelectedBodyPart = new System.Random();
    private static System.Random RandomRecoveryUsingAPotion = new System.Random();

    private void FixedUpdate()
    {
        timeFB += 0.3f * Time.deltaTime;
        if (timeFB >= 4) TakeDamageForInaction();
    }

    void TakeDamageForInaction()
    {
        HeroAction = "пропускает";
        timeFB = 0;
        CountAttackPowerEnemy();
    }

    public void LaunchBattle()
    {
        AssignsVariablesHero();
        AssignsVariablesEnemy();
        supplementForHero.load();
    }

    void AssignsVariablesHero()
    {
        HeroName = characteristicsHero.Name;
        FullHealthHero = characteristicsHero.FullHealth;
        CurrentHealthHero = characteristicsHero.CurrentHealth;
        MaxAttackHero = characteristicsHero.MaxAttack;
        MinAttackHero = characteristicsHero.MinAttack;
        MaxArmorHero = characteristicsHero.MaxArmor;
        MinArmorHero = characteristicsHero.MinArmor;
        MaxAbilityHero = characteristicsHero.MaxAbility;
        MinAbilityHero = characteristicsHero.MinAbility;
        BlockHero = characteristicsHero.Block;
        PotionX = characteristicsHero.PotionX;
        if (!File.Exists(Application.dataPath + "/data/CurValue.sav"))
        {
            patrsBodyHero.RecoveryColor();
            displayBattleValues.StartDisplayBattleValuesForHero();
        }
    }

    void AssignsVariablesEnemy()
    {
        FullHealthEnemy = characteristicsEnemy.FullHealthEnemy;
        CurrentHealthEnemy = FullHealthEnemy;
        EnemyClass = characteristicsEnemy.EnemyClass;
        MaxAttackEnemy = characteristicsEnemy.MaxAttackEnemy;
        MaxArmorEnemy = characteristicsEnemy.MaxArmorEnemy;
        BlockEnemy = characteristicsEnemy.BlockEnemy;
        if (roomManager.currentRoom.WhatIsTheRoomUsedFor != "обучение") NameEnemy = characteristicsEnemy.NameEnemy;
        else
        {
            if (localization.Language == "ru") NameEnemy = "Боби";
            else NameEnemy = "Bobi";
        }
        EnemyRandomCharacteristics();
        displayBattleValues.StartDisplayBattleValuesForEnemy();
    }

    void EnemyRandomCharacteristics()
    {
        float Health = RandomEnemyHealth.Next(-3, 5);
        float Attack = RandomEnemyAttack.Next(-2, 6);
        float Armor = RandomEnemyArmor.Next(-2, 4);
        float Block = RandomEnemyBlock.Next(-3, 2);
        FullHealthEnemy = FullHealthEnemy + (Health * 2);
        if (FullHealthEnemy < 50)
        {
            float NumberA = 0;
            if (FullHealthEnemy < 10) NumberA = 25 + FullHealthEnemy;
            FullHealthEnemy = FullHealthEnemy + NumberA + 47;
        }
        CurrentHealthEnemy = FullHealthEnemy;
        MaxAttackEnemy = MaxAttackEnemy + Attack;
        displayBattleValues.EnemyAttack = displayBattleValues.EnemyAttack + Attack;
        MaxArmorEnemy = MaxArmorEnemy + Armor;
        displayBattleValues.EnemyArmor = displayBattleValues.EnemyArmor + Armor;
        BlockEnemy = BlockEnemy + Block;
        displayBattleValues.EnemyBlock = displayBattleValues.EnemyBlock + Block;
    }

    public void InputActions(string key, string keyOne, string keyTwo)
    {
        if (key == "зелье") DrinkPotionBS();
        if (key == "ударить" && keyTwo == "мечом" || key == "sword" && keyTwo == "attack") SwordStrike();
        if (key == "поставить" && keyTwo == "блок" || key == "put" && keyTwo == "block") PutBlock();
        if (key == "воспользоваться" && keyTwo == "магией" || key == "attack" && keyOne == "with" && keyTwo == "magic") MagicAttack();
        if (characteristicsHero.Class == "лучник" || characteristicsHero.Class == "Kat")
        {
            if (key == "натянуть" && keyTwo == "тетиву" || key == "pull" && keyOne == "the" && keyTwo == "bow") PullTheBow();
        }
        else displayBattleValues.ErrorArcher();
        AdditionalActions();
    }

    void SwordStrike()
    {
        HeroAction = "атакует";
        ChoiceWhoFirstActs();
        NumberOfActionsZero++;
    }

    void PutBlock()
    {
        HeroAction = "защищается";
        ChoiceWhoFirstActs();
        NumberOfActionsOne++;
    }

    void MagicAttack()
    {
        HeroAction = "атакует магией";
        ChoiceWhoFirstActs();
        NumberOfActionsTwo++;
    }

    void PullTheBow()
    {
        HeroAction = "выстрел из лука";
        ChoiceWhoFirstActs();
        NumberOfActionsThree++;
    }

    void AdditionalActions()
    {
        if (EnemyClass == "boss") Final();
        timeFB = 0;
    }

    void Final()
    {
        number++;
        if (number == 7) roomManager.attenuation.TheAppearanceOfObject("Final");
    }

    /* если первый атакует игрок, то производится атака, при этом враг может в этот момент защищаться или нападать
     * или первый атакует враг, то производится сначала атака (или защита) врага, при этом учитывается выбор игрока
     * если игрок выбирает защиту, то враг только атакует. */
    void ChoiceWhoFirstActs()
    {
        RandomlySelectsAnAttackOrDefense();
        int SwitchForChoice;
        SwitchForChoice = RandomChoiceWhoFirstActs.Next(0, 2);
        if (SwitchForChoice == 0) FirstAttack = "первый атакует герой";
        if (SwitchForChoice == 1) FirstAttack = "первый атакует враг";
        if (FirstAttack == "первый атакует герой") FirstAttackHero();
        if (FirstAttack == "первый атакует враг") FirstAttackingEnemy();
        displayBattleValues.ActionLogFirstAttack(FirstAttack);
    }

    void FirstAttackHero()
    {
        if (HeroAction != "ставит блок") CalculateHeroArmor();
        if (EnemyAction != "ставит блок") CalculateEnemyArmor();
        if (HeroAction == "защищается") HeroBlock();
        if (EnemyAction == "ставит блок") EnemyBlock();
        if (HeroAction == "атакует") CountAttackPowerHero();
        if (HeroAction == "выстрел из лука") CountArcherPowerHero();
        if (HeroAction == "атакует магией") CountAbilityPowerHero();
        if (EnemyAction == "бьет") CountAttackPowerEnemy();
    }

    void FirstAttackingEnemy()
    {
        if (EnemyAction != "ставит блок") CalculateEnemyArmor();
        if (HeroAction != "ставит блок") CalculateHeroArmor();
        if (EnemyAction == "ставит блок") EnemyBlock();
        if (HeroAction == "защищается") HeroBlock();
        if (EnemyAction == "бьет") CountAttackPowerEnemy();
        if (HeroAction == "атакует") CountAttackPowerHero();
        if (HeroAction == "атакует магией") CountAbilityPowerHero();
        if (HeroAction == "выстрел из лука") CountArcherPowerHero();
    }

    void RandomlySelectsAnAttackOrDefense()
    {
        ActionSelectionVariable = RandomlyChosenEnemyAction.Next(0, 5);
        if (CurrentHealthEnemy < HealthThresholdVariable)
        {
            if (ActionSelectionVariable == 0 || ActionSelectionVariable == 2 || ActionSelectionVariable == 4 || ActionSelectionVariable == 5) EnemyAction = "бьет";
            if (ActionSelectionVariable == 1 || ActionSelectionVariable == 3) EnemyAction = "ставит блок";
        }
        else
        {
            if (ActionSelectionVariable == 0 || ActionSelectionVariable == 2 || ActionSelectionVariable == 3 || ActionSelectionVariable == 4 || ActionSelectionVariable == 5) EnemyAction = "бьет";
            if (ActionSelectionVariable == 1) EnemyAction = "ставит блок";
        }
        if (SwitchRandomHTV == false) TheThresholdForAggressiveCombatIsRandomlySelected();
    }

    void TheThresholdForAggressiveCombatIsRandomlySelected()
    {
        HealthThresholdVariable = RandomlyChosenRandomlySelectedHealthThresholdForSwitch.Next(0, 20);
        SwitchRandomHTV = true;
    }

    void CountAttackPowerHero()
    {
        CalculateHeroDamage();
        if (EnemyAction == "бьет")
        {
            if (AttackHero <= CurrentArmorEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                AttackHero = CurrentArmorEnemy - AttackHero;
                AttackHero = Mathf.Abs(AttackHero);
                HeroAtack();
            }
        }
        if (EnemyAction == "ставит блок")
        {
            if (AttackHero <= AllDefenseEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                AttackHero = AllDefenseEnemy - AttackHero;
                AttackHero = Mathf.Abs(AttackHero);
                HeroAtack();
            }
        }
    }

    void CalculateHeroDamage()
    {
        int MinDamage;
        if (MinAttackHero > 0) MinDamage = MinDamageHero.Next(0, (int)MinAttackHero);
        else MinDamage = 0;
        int CriticalDamage = (int)MaxAttackHero + MinDamage;
        if (CriticalDamage > MinDamage) AttackHero = CurrentDamageHero.Next(MinDamage, CriticalDamage);
        else AttackHero = 0;
        if (AttackHero > MaxAttackHero) CriticalDamageHero = true;
        else CriticalDamageHero = false;
    }

    void HeroAtack()
    {
        if (AttackHero >= 0)
        {
            CurrentHealthEnemy -= AttackHero;
            displayBattleValues.LogHeroAttack(AttackHero, CriticalDamageHero);
            RandomSwichForBTTE();
        }
        if (CurrentHealthEnemy <= 0) YouWin();
    }

    void CountAbilityPowerHero()
    {
        CalculateHeroAbility();
        if (EnemyAction == "бьет")
        {
            if (AbilityHero <= CurrentArmorEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                AbilityHero = CurrentArmorEnemy - AbilityHero;
                AbilityHero = Mathf.Abs(AbilityHero);
                HeroAbilities();
            }
        }
        else if (EnemyAction == "ставит блок")
        {
            if (AbilityHero <= AllDefenseEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                AbilityHero = AllDefenseEnemy - AbilityHero;
                AbilityHero = Mathf.Abs(AbilityHero);
                HeroAbilities();
            }
        }
    }

    void CalculateHeroAbility()
    {
        int MinDamage;
        if (MinAbilityHero > 0) MinDamage = MinAbilityDamageHero.Next(0, (int)MinAbilityHero);
        else MinDamage = 0;
        int CriticalDamage = (int)MaxAbilityHero + MinDamage;
        if (CriticalDamage > MinDamage) AbilityHero = CurrentAbilityDamageHero.Next(MinDamage, CriticalDamage);
        else AbilityHero = 0;
        if (AbilityHero > MaxAbilityHero) CriticalDamageHero = true;
        else CriticalDamageHero = false;
    }

    void HeroAbilities()
    {
        if (AbilityHero >= 0)
        {
            CurrentHealthEnemy -= AbilityHero;
            displayBattleValues.LogHeroAbilityAttack(AbilityHero, CriticalDamageHero);
            RandomSwichForBTTE();
        }
        if (CurrentHealthEnemy <= 0) YouWin();
    }

    void CountArcherPowerHero()
    {
        CalculateHeroArcher();
        if (EnemyAction == "бьет")
        {
            if (ArcherAttack <= CurrentArmorEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                ArcherAttack = CurrentArmorEnemy - ArcherAttack;
                ArcherAttack = Mathf.Abs(ArcherAttack);
                ArcheryHero();
            }
        }
        else if (EnemyAction == "ставит блок")
        {
            if (ArcherAttack <= AllDefenseEnemy)
            {
                HeroMiss = RandomHeroMiss.Next(0, 7);
                if (HeroMiss == 0 || HeroMiss == 2 || HeroMiss == 4 || HeroMiss == 6) displayBattleValues.LogEnemyDidntHurt();
                else displayBattleValues.HeroMiss();
            }
            else
            {
                ArcherAttack = AllDefenseEnemy - ArcherAttack;
                ArcherAttack = Mathf.Abs(ArcherAttack);
                ArcheryHero();
            }
        }
    }

    void CalculateHeroArcher()
    {
        int MinDamage;
        ArcherAttack = ((int)MaxAttackHero + (int)MaxAbilityHero) / 2;
        MinDamage = (int)ArcherAttack / 2;
        if (MinDamage > 0) MinDamage = MinAbilityDamageHero.Next(0, MinDamage);
        else MinDamage = 0;
        int CriticalDamage = (int)ArcherAttack + MinDamage;
        float MaxDamage;
        if (CriticalDamage > MinDamage) MaxDamage = CurrentAbilityDamageHero.Next(MinDamage, CriticalDamage);
        else MaxDamage = 0;
        if (MaxDamage > ArcherAttack) CriticalDamageHero = true;
        else CriticalDamageHero = false;
    }

    void ArcheryHero()
    {
        if (ArcherAttack >= 0)
        {
            CurrentHealthEnemy -= ArcherAttack;
            displayBattleValues.LogHeroArcherAttack(AbilityHero, CriticalDamageHero);
            RandomSwichForBTTE();
        }
        if (CurrentHealthEnemy <= 0) YouWin();
    }

    void CalculateHeroArmor()
    {
        int minArmor;
        if ((int)MinArmorHero > 0) minArmor = RandomMinArmorHero.Next(0, (int)MinArmorHero);
        else minArmor = 0;
        if ((int)MaxArmorHero > minArmor) CurrentArmorHero = RandomArmorHero.Next(minArmor, (int)MaxArmorHero);
        else CurrentArmorHero = 0;
    }

    void HeroBlock()
    {
        int minBlock = (int)MaxArmorHero / 2;
        int maxBlock = (int)MaxArmorHero + ((int)BlockHero / 2);
        if (maxBlock > minBlock) AllDefenseHero = RandomBlockHero.Next(minBlock, maxBlock);
        else AllDefenseHero = 0;
        displayBattleValues.LogHeroBlock();
    }

    void YouWin()
    {
        AssignAValueToSave();
        roomManager.attenuation.TheAppearanceOfObject("Level");
    }

    void CountAttackPowerEnemy()
    {
        CalculateEnemyDamage();
        if (HeroAction == "атакует" || HeroAction == "атакует магией" || HeroAction == "выстрел из лука" || HeroAction == "пропускает")
        {
            if (AttackEnemy <= CurrentArmorHero)
            {
                EnemyMiss = RandomEnemyMiss.Next(0, 7);
                if (EnemyMiss == 0 || EnemyMiss == 2 || EnemyMiss == 4 || EnemyMiss == 6) displayBattleValues.LogHeroDidntHurt();
                else displayBattleValues.EnemyMiss();
            }
            else
            {
                AttackEnemy = CurrentArmorHero - AttackEnemy;
                AttackEnemy = Mathf.Abs(AttackEnemy);
                EnemyAtack();
            }
        }
        else if (HeroAction == "защищается")
        {
            if (AttackEnemy <= AllDefenseHero)
            {
                EnemyMiss = RandomEnemyMiss.Next(0, 7);
                if (EnemyMiss == 0 || EnemyMiss == 2 || EnemyMiss == 4 || EnemyMiss == 6) displayBattleValues.LogHeroDidntHurt();
                else displayBattleValues.EnemyMiss();
            }
            else
            {
                AttackEnemy = AllDefenseHero - AttackEnemy;
                AttackEnemy = Mathf.Abs(AttackEnemy);
                EnemyAtack();
            }
        }
    }

    void CalculateEnemyDamage()
    {
        int MinDamage;
        MinDamage = (int)MaxAttackEnemy / 2;
        if (MinDamage > 0) MinDamage = MinDamageEnemy.Next(0, MinDamage);
        else MinDamage = 0;
        int CriticalDamage = (int)MaxAttackEnemy + MinDamage;
        if (CriticalDamage > MinDamage) AttackEnemy = CurrentDamageEnemy.Next(MinDamage, CriticalDamage);
        else AttackEnemy = 0;
        if (AttackEnemy > MaxAttackEnemy) CriticalDamageEnemy = true;
        else CriticalDamageEnemy = false;
    }

    void EnemyAtack()
    {
        if (AttackEnemy >= 0)
        {
            CurrentHealthHero -= AttackEnemy;
            displayBattleValues.LogEnemyAttack(AttackEnemy, CriticalDamageEnemy);
            RandomSwichForBTTH();
            if (sDialForBattle) sDialForBattle.SwitchingBetweenLanguagesForDialoguesOfFear(localization.Language);
            if (audioCry) CallAudioCrying();
        }
        if (CurrentHealthHero <= 0) YouLost();
    }

    void CallAudioCrying()
    {
        int rnd = Random.Range(0, 10);
        if (rnd == 5) audioCry.SelectAudiForCry();
    }

    void YouLost()
    {
        cleaning.CleanAllSave();
        roomManager.attenuation.TheAppearanceOfObject("Menu");
    }

    void CalculateEnemyArmor()
    {
        int minArmor = (int)MaxArmorEnemy / 2;
        if (minArmor > 0) minArmor = RandomMinArmorHero.Next(0, minArmor);
        else minArmor = 0;
        if (MaxArmorEnemy > minArmor) CurrentArmorEnemy = RandomArmorHero.Next(minArmor, (int)MaxArmorEnemy);
        else CurrentArmorEnemy = 1;
    }

    void EnemyBlock()
    {
        int minBlock = (int)MaxArmorEnemy / 2;
        int maxBlock = (int)MaxArmorEnemy + ((int)BlockEnemy / 2);
        if (maxBlock > minBlock) AllDefenseEnemy = RandomBlockEnemy.Next(minBlock, maxBlock);
        else AllDefenseEnemy = 1;
        displayBattleValues.LogEnemyBlock();
    }

    public void IfThePlayerHasNotEnteredTheSecondKey()
    {
        CalculateHeroArmor();
        CalculateEnemyDamage();
        if (AttackEnemy <= CurrentArmorHero)
        {
            EnemyMiss = RandomEnemyMiss.Next(0, 7);
            if (EnemyMiss == 0 || EnemyMiss == 2 || EnemyMiss == 4 || EnemyMiss == 6) displayBattleValues.LogHeroDidntHurt();
            else displayBattleValues.EnemyMiss();
        }
        else
        {
            AttackEnemy = CurrentArmorHero - AttackEnemy;
            AttackEnemy = Mathf.Abs(AttackEnemy);
            EnemyAtack();
            RandomSwichForBTTH();
        }
    }

    void RandomSwichForBTTH()
    {
        int RndSwich;
        RndSwich = RandomlySelectedDamage.Next(0, 20);
        if (RndSwich == 0 || RndSwich == 5 || RndSwich == 8) BlowToOnePartOfTheHeroBody();
    }

    void BlowToOnePartOfTheHeroBody()
    {
        int RndSwich;
        RndSwich = RandomSelectedBodyPart.Next(0, 6);
        if (RndSwich == 0) supplementForHero.BlowToTheHead();
        if (RndSwich == 1) supplementForHero.BlowToTheBody();
        if (RndSwich == 2) supplementForHero.BlowToTheLHand();
        if (RndSwich == 3) supplementForHero.BlowToTheRHand();
        if (RndSwich == 4) supplementForHero.BlowToTheLLeg();
        if (RndSwich == 5) supplementForHero.BlowToTheRLeg();
    }

    void RandomSwichForBTTE()
    {
        int RndSwich;
        RndSwich = RandomlySelectedDamageFoeEnemy.Next(0, 10);
        if (RndSwich == 0 || RndSwich == 5 || RndSwich == 9) BlowToOnePartOfTheEnemyBody();
    }

    void BlowToOnePartOfTheEnemyBody()
    {
        int RndSwich;
        RndSwich = RandomSelectedEnemyBodyPart.Next(0, 6);
        if (RndSwich == 0) supplementForEnemy.BlowToTheHead();
        if (RndSwich == 1) supplementForEnemy.BlowToTheBody();
        if (RndSwich == 2) supplementForEnemy.BlowToTheLHand();
        if (RndSwich == 3) supplementForEnemy.BlowToTheRHand();
        if (RndSwich == 4) supplementForEnemy.BlowToTheLLeg();
        if (RndSwich == 5) supplementForEnemy.BlowToTheRLeg();
    }

    public void DrinkPotionBS()
    {
        if (characteristicsHero.PotionX > 0)
        {
            if (CurrentHealthHero >= FullHealthHero) OutputOutADialogueOfPotion("полное здоровье");
            else
            {
                OutputOutADialogueOfPotion("сделать глоток");
                if (CurrentHealthHero >= FullHealthHero) OutputOutADialogueOfPotion("здоровье восстановлено");
                else OutputOutADialogueOfPotion("восстановление здоровья");
                if (PotionX == 0) OutputOutADialogueOfPotion("пузырек опустошен");
            }
            if (CurrentHealthHero < FullHealthHero)
            {
                PotionX--;
                ExposureToPotion();
                supplementForHero.BodyRecovery();
            }
            NumberOfActionsFive++;
        }
        else OutputOutADialogueOfPotion("пузырек пуст");
    }

    void OutputOutADialogueOfPotion(string dialog)
    {
        if (dialog == "полное здоровье")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "мое тело не повреждено, не буду тратить драгоценное зелье.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "my body is not damaged, I will not spend a precious potion.");
        }
        if (dialog == "сделать глоток")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "сделал глоток из пузырька.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "i took a sip from the bubble.");
        }
        if (dialog == "здоровье восстановлено")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "я чувствую как мое тело восстановилось.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "i feel my body recover.");
        }
        if (dialog == "восстановление здоровья")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "я чувствую как мое тело восстанавливается.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "i feel my body recovering.");
        }
        if (dialog == "пузырек опустошен")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "пузырек опустошен.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "the bubble is empty.");
        }
        if (dialog == "пузырек пуст")
        {
            if (localization.Language == "ru") displayBattleValues.PotionDrink(HeroName + ": " + "пузырек пуст.");
            if (localization.Language == "en") displayBattleValues.PotionDrink(HeroName + ": " + "the bubble is empty.");
        }
    }

    void ExposureToPotion()
    {
        float TemporaryValue;
        TemporaryValue = RandomRecoveryUsingAPotion.Next(50, 70);
        CurrentHealthHero += TemporaryValue;
        if (CurrentHealthHero >= FullHealthHero) CurrentHealthHero = FullHealthHero;
    }

    void AssignAValueToSave()
    {
        supplementForHero.BodyRecovery();
        characteristicsHero.FullHealth = FullHealthHero;
        characteristicsHero.CurrentHealth = CurrentHealthHero;
        characteristicsHero.MaxAttack = MaxAttackHero;
        characteristicsHero.MinAttack = MinAttackHero;
        characteristicsHero.MaxArmor = MaxArmorHero;
        characteristicsHero.MinArmor = MinArmorHero;
        characteristicsHero.MaxAbility = MaxAbilityHero;
        characteristicsHero.MinAbility = MinAbilityHero;
        characteristicsHero.Block = BlockHero;
        characteristicsHero.PotionX = PotionX;
        characteristicsHero.ActivationOpportunitiesAltarForSave();
        characteristicsHero.SaveCurCharacteristicsHero();
    }

    public void SDFASF()
    {
        displayBattleValues.lOG();
    }
}