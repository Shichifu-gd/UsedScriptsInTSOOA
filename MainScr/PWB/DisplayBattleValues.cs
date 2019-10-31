using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayBattleValues : MonoBehaviour
{
    public Text DisplayText;
    public Text DisplayTextForName;
    public Text MinAndMaxHealthHero;
    public Text MinAndMaxAttackHero;
    public Text MinAndMaxAbilityHero;
    public Text MinAndMaxArmorHero;
    public Text MinAndMaxBlockHero;
    public Text BuffAndDebuffForAttack;
    public Text BuffAndDebuffForAbility;
    public Text BuffAndDebuffForArmor;
    public Text BuffAndDebuffForBlock;
    public Text MinAndMaxHealthEnemy;
    public Text MinAndMaxAttackEnemy;
    public Text MinAndMaxArmorEnemy;
    public Text MinAndMaxBlockEnemy;
    public Text BuffAndDebuffForEnemyAttack;
    public Text BuffAndDebuffForEnemyArmor;
    public Text BuffAndDebuffForEnemyBlock;
    public Text EnemyName;
    public Text TextHeroName;

    string HeroName;
    string DisplayActionLog;
    string damage;
    float LeftHand;
    float RightHand;

    List<string> ListActionLog = new List<string>();
    List<string> ListActionLogFirstAttack = new List<string>();

    [HideInInspector]
    public float attack;
    [HideInInspector]
    public float ability;
    [HideInInspector]
    public float armor;
    [HideInInspector]
    public float HeroBlock;

    [HideInInspector]
    public float EnemyAttack;
    [HideInInspector]
    public float EnemyArmor;
    [HideInInspector]
    public float EnemyBlock;

    public CharacteristicsHero characteristicsHero;
    public GeneralSettings generalSettings;
    public BattleScript battleScript;

    void Update()
    {
        AssignHeroHealthToTheText();
        AssignHeroAttackToTheText();
        AssignHeroAbilityToTheText();
        AssignHeroArmorToTheText();
        AssignHeroBlockToTheText();

        if (battleScript == true)
        {
            AssignEnemyHealthToTheText();
            AssignEnemyAttackToTheText();
            AssignEnemyArmorToTheText();
            AssignEnemyBlockToTheText();
        }
    }

    public void StartDisplayBattleValuesForHero()
    {
        HeroName = battleScript.name;
        TextHeroName.text = HeroName;
        BuffAndDebuffForAttack.text = "(" + attack + ")";
        BuffAndDebuffForAbility.text = "(" + ability + ")";
        BuffAndDebuffForArmor.text = "(" + armor + ")";
        BuffAndDebuffForBlock.text = "(" + HeroBlock + ")";
    }

    public void StartDisplayBattleValuesForEnemy()
    {
        HeroName = battleScript.HeroName;
        TextHeroName.text = HeroName;
        EnemyName.text = battleScript.NameEnemy;
        OutputToDisplayBuffAndDebuffEnemyAttack();
        OutputToDisplayBuffAndDebufffEnemyArmor();
        OutputToDisplayBuffAndDebuffEnemyBlock();

    }

    public void ActionLog(string StringToAdd)
    {
        ListActionLog.Add(StringToAdd);
        string LogText = string.Join("\n", ListActionLog.ToArray());
        DisplayText.text = LogText;
        CleansExcessText();
    }

    void CleansExcessText()
    {
        var Quantity = DisplayText.text.Length;
        int Limit = 3000;
        if (Quantity > Limit)
        {
            int DynamicIndex = Quantity;
            DynamicIndex = DynamicIndex - Limit;
            DisplayText.text = DisplayText.text.Remove(0, DynamicIndex);
        }
    }

    public void LogHeroAttack(float AttackHero, bool critical)
    {
        string criticalLog = "";
        if (generalSettings.Language == "ru")
        {
            if (critical == false) criticalLog = HeroName + " : наносит урон.";
            else if (critical == true) criticalLog = HeroName + " : наносит критический урон.";
        }
        if (generalSettings.Language == "en")
        {
            if (critical == false) criticalLog = HeroName + " : inflict damage.";
            else if (critical == true) criticalLog = HeroName + " : inflict critical damage.";
        }
        DisplayActionLog = criticalLog + AttackHero;
        ActionLog(DisplayActionLog);
    }

    public void LogHeroAbilityAttack(float AttackHero, bool critical)
    {
        string criticalLog = "";
        if (generalSettings.Language == "ru")
        {
            if (critical == false) criticalLog = HeroName + " : наносит урон магией.";
            else if (critical == true) criticalLog = HeroName + " : наносит критический урон магией.";
        }
        if (generalSettings.Language == "en")
        {
            if (critical == false) criticalLog = HeroName + " : inflict damage with magic.";
            else if (critical == true) criticalLog = HeroName + " : inflict critical damage with magic.";
        }
        DisplayActionLog = criticalLog + AttackHero;
        ActionLog(DisplayActionLog);
    }

    public void LogHeroArcherAttack(float AttackHero, bool critical)
    {
        string criticalLog = "";
        if (generalSettings.Language == "ru")
        {
            if (critical == false) criticalLog = HeroName + " : наносит урон выстрелом.";
            else if (critical == true) criticalLog = HeroName + " : наносит критический урон выстрелом.";
        }
        if (generalSettings.Language == "en")
        {
            if (critical == false) criticalLog = HeroName + " : inflict damage with a shot.";
            else if (critical == true) criticalLog = HeroName + " : inflict critical damage with a shot.";
        }
        DisplayActionLog = criticalLog + AttackHero;
        ActionLog(DisplayActionLog);
    }

    public void LogHeroDidntHurt()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": не пробил защиту героя.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": did not break the hero’s defense.";
        ActionLog(DisplayActionLog);
    }

    public void LogHeroBlock()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : ставит блок.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : puts a block.";
        ActionLog(DisplayActionLog);
    }

    public void LogEnemyAttack(float AttackEnemy, bool critical)
    {
        string criticalLog = "";
        if (generalSettings.Language == "ru")
        {
            if (critical == false) criticalLog = ": наносит урон.";
            else if (critical == true) criticalLog = ": наносит критический урон.";
        }
        if (generalSettings.Language == "en")
        {
            if (critical == false) criticalLog = ": inflict damage.";
            else if (critical == true) criticalLog = ": inflict critical damage.";
        }
        DisplayActionLog = battleScript.NameEnemy + criticalLog + AttackEnemy;
        ActionLog(DisplayActionLog);
    }

    public void LogEnemyDidntHurt()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : не пробил защиту противника.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : did not break the enemy defense.";
        ActionLog(DisplayActionLog);
    }

    public void LogEnemyBlock()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": ставит блок.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": puts a block.";
        ActionLog(DisplayActionLog);
    }

    public void ActionLogFirstAttack(string StringToAdd)
    {
        ListActionLogFirstAttack.Add(StringToAdd);
        string LogText = string.Join("\n", ListActionLogFirstAttack.ToArray());
        DisplayTextForName.text = LogText;
    }

    public void HeroMiss()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : промахнулся.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : missed.";
        ActionLog(DisplayActionLog);
    }

    public void EnemyMiss()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": промахнулся.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": missed.";
        ActionLog(DisplayActionLog);
    }

    void AssignHeroHealthToTheText()
    {
        if (battleScript == true) MinAndMaxHealthHero.text = battleScript.CurrentHealthHero + "/" + battleScript.FullHealthHero;
        else MinAndMaxHealthHero.text = characteristicsHero.CurrentHealth + "/" + characteristicsHero.FullHealth;
    }

    void AssignHeroAttackToTheText()
    {
        if (battleScript == true) MinAndMaxAttackHero.text = battleScript.MinAttackHero + "/" + battleScript.MaxAttackHero;
        else MinAndMaxAttackHero.text = characteristicsHero.MinAttack + "/" + characteristicsHero.MaxAttack;
    }

    void AssignHeroAbilityToTheText()
    {
        if (battleScript == true) MinAndMaxAbilityHero.text = battleScript.MinAbilityHero + "/" + battleScript.MaxAbilityHero;
        else MinAndMaxAbilityHero.text = characteristicsHero.MinAbility + "/" + characteristicsHero.MaxAbility;
    }

    void AssignHeroArmorToTheText()
    {
        if (battleScript == true) MinAndMaxArmorHero.text = battleScript.MinArmorHero + "/" + battleScript.MaxArmorHero;
        else MinAndMaxArmorHero.text = characteristicsHero.MinArmor + "/" + characteristicsHero.MaxArmor;
    }

    void AssignHeroBlockToTheText()
    {
        if (battleScript == true) MinAndMaxBlockHero.text = "" + battleScript.BlockHero;
        else MinAndMaxBlockHero.text = "" + characteristicsHero.Block;
    }

    void AssignEnemyHealthToTheText()
    {
        if (battleScript == true) MinAndMaxHealthEnemy.text = battleScript.CurrentHealthEnemy + "/" + battleScript.FullHealthEnemy;
    }

    void AssignEnemyAttackToTheText()
    {
        if (battleScript == true) MinAndMaxAttackEnemy.text = "?" + "/" + battleScript.MaxAttackEnemy;
    }

    void AssignEnemyArmorToTheText()
    {
        if (battleScript == true) MinAndMaxArmorEnemy.text = "?" + "/" + battleScript.MaxArmorEnemy;
    }

    void AssignEnemyBlockToTheText()
    {
        if (battleScript == true) MinAndMaxBlockEnemy.text = "" + battleScript.BlockEnemy;
    }

    public void SwitchForOutputToDisplayToLoad(string InformationForSwitchForOutputToDisplay, float Bonus)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние головы") OutputToDisplayBuffAndDebuffAbility(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние тела") OutputToDisplayBuffAndDebuffArmor(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки") AssigningValuesLHand(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки") AssigningValuesRHand(Bonus);
    }

    public void SwitchForOutputToDisplay(string InformationForSwitchForOutputToDisplay, float Bonus)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние головы")
        {
            OutputToDisplayBuffAndDebuffAbility(Bonus);
            DamageToTheHead();
        }
        if (InformationForSwitchForOutputToDisplay == "состояние тела")
        {
            OutputToDisplayBuffAndDebuffArmor(Bonus);
            DamageToTheBody();
        }
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки")
        {
            AssigningValuesLHand(Bonus);
            DamageToTheLeftHand();
        }
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки")
        {
            AssigningValuesRHand(Bonus);
            DamageToTheRightHand();
        }
        if (InformationForSwitchForOutputToDisplay == "состояние правой ноги") DamageToTheRightLeg();
        if (InformationForSwitchForOutputToDisplay == "состояние левой ноги") DamageToTheLeftLeg();
    }

    void OutputToDisplayBuffAndDebuffAbility(float Bonus)
    {
        float TemporaryVariable = ability;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (ability > 0) NegativeAandPositive = "+";
        if (ability < 1) NegativeAandPositive = "-";
        if (ability == 0) NegativeAandPositive = "";

        BuffAndDebuffForAbility.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void AssigningValuesLHand(float Bonus)
    {
        LeftHand = Bonus;
        SummarizeHands();
    }

    void AssigningValuesRHand(float Bonus)
    {
        RightHand = Bonus;
        SummarizeHands();
    }

    void SummarizeHands()
    {
        float buffer = LeftHand + RightHand;
        OutputToDisplayBuffAndDebuffAttack(buffer);
    }

    void OutputToDisplayBuffAndDebuffAttack(float Bonus)
    {
        float TemporaryVariable = attack;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (attack > 0) NegativeAandPositive = "+";
        if (attack < 1) NegativeAandPositive = "-";
        if (attack == 0) NegativeAandPositive = "";
        BuffAndDebuffForAttack.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void OutputToDisplayBuffAndDebuffArmor(float Bonus)
    {
        float TemporaryVariable = armor;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (armor > 0) NegativeAandPositive = "+";
        if (armor < 1) NegativeAandPositive = "-";
        if (armor == 0) NegativeAandPositive = "";
        BuffAndDebuffForArmor.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    public void OutputToDisplayBuffAndDebuffBlock()
    {
        float TemporaryVariable = HeroBlock;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (HeroBlock > 1) NegativeAandPositive = "+";
        if (HeroBlock < 1) NegativeAandPositive = "-";
        if (HeroBlock == 0) NegativeAandPositive = "";
        BuffAndDebuffForBlock.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void DamageToTheHead()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по голове.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflict additional damage to the head.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheBody()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по телу.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflicts additional damage to the body.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheRightHand()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по правой руке.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflict additional damage to the right hand.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheLeftHand()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по левой руке.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflict additional damage to the left hand.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheRightLeg()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по левой ноге.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflict additional damage to the left leg.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheLeftLeg()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = battleScript.NameEnemy + ": наносит дополнительный урон по правой ноге.";
        if (generalSettings.Language == "en") DisplayActionLog = battleScript.NameEnemy + ": inflict additional damage to the right leg.";
        ActionLog(DisplayActionLog);
    }

    public void SwitchForOutputToDisplayForEnemy(string InformationForSwitchForOutputToDisplay, float Bonus)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние головы") DamageToTheEnemyHead();
        if (InformationForSwitchForOutputToDisplay == "состояние тела") OutputToDisplayBuffAndDebufffEnemyArmor();
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки") AssigningValuesfEnemyLHand(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки") AssigningValuesfEnemyRHand(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние левой ноги") DamageToTheEnemyRightLeg();
        if (InformationForSwitchForOutputToDisplay == "состояние правой ноги") DamageToTheEnemyLeftLeg();
    }

    void AssigningValuesfEnemyLHand(float Bonus)
    {
        SummarizefEnemyHands();
        DamageToTheEnemyLeftHand();
    }

    void AssigningValuesfEnemyRHand(float Bonus)
    {
        SummarizefEnemyHands();
        DamageToTheEnemyRightHand();
    }

    void SummarizefEnemyHands()
    {
        OutputToDisplayBuffAndDebuffEnemyAttack();
    }

    void OutputToDisplayBuffAndDebuffEnemyAttack()
    {
        float TemporaryVariable = EnemyAttack;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (EnemyAttack > 0) NegativeAandPositive = "+";
        if (EnemyAttack < 1) NegativeAandPositive = "-";
        if (EnemyAttack == 0) NegativeAandPositive = "";
        BuffAndDebuffForEnemyAttack.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void OutputToDisplayBuffAndDebufffEnemyArmor()
    {
        float TemporaryVariable = EnemyArmor;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (EnemyArmor > 0) NegativeAandPositive = "+";
        if (EnemyArmor < 1) NegativeAandPositive = "-";
        if (EnemyArmor == 0) NegativeAandPositive = "";
        BuffAndDebuffForEnemyArmor.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    public void OutputToDisplayBuffAndDebuffEnemyBlock()
    {
        float TemporaryVariable = EnemyBlock;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (EnemyBlock >= 1) NegativeAandPositive = "+";
        if (EnemyBlock <= 1) NegativeAandPositive = "-";
        if (EnemyBlock == 0) NegativeAandPositive = "";
        BuffAndDebuffForEnemyBlock.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    public void BodyValueRecovery()
    {
        if (attack <= 0) BuffAndDebuffForAttack.text = "(" + 0 + ")";

        if (ability <= 0) BuffAndDebuffForAbility.text = "(" + 0 + ")";

        if (armor <= 0) BuffAndDebuffForArmor.text = "(" + 0 + ")";

        if (HeroBlock <= 0) BuffAndDebuffForBlock.text = "(" + 0 + ")";
    }

    void DamageToTheEnemyHead()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по голове.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflict additional damage to the head.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheEnemyBody()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по телу.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflicts additional damage to the body.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheEnemyRightHand()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по правой руке.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflict additional damage to the right hand.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheEnemyLeftHand()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по левой руке.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflict additional damage to the left hand.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheEnemyRightLeg()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по левой ноге.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflict additional damage to the left leg.";
        ActionLog(DisplayActionLog);
    }

    void DamageToTheEnemyLeftLeg()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : наносит дополнительный урон по правой ноге.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : inflict additional damage to the right leg.";
        ActionLog(DisplayActionLog);
    }

    public void PotionDrink(string log)
    {
        ActionLog(log);
    }

    public void lOG()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = HeroName + " : при попытки нанести удар, что-то пошло не так.";
        if (generalSettings.Language == "en") DisplayActionLog = HeroName + " : when you try to strike, something went wrong.";
        ActionLog(DisplayActionLog);
    }

    public void LoadingAltarValue(float bonusMaxArmor, float bonusMaxAttack, float bonusMaxAbility)
    {
        attack = attack + bonusMaxAttack;
        ability = ability + bonusMaxAbility;
        armor = armor + bonusMaxArmor;

        OutputToDisplayBuffAndDebuffAttack(bonusMaxAttack);
        OutputToDisplayBuffAndDebuffArmor(bonusMaxArmor);
        OutputToDisplayBuffAndDebuffAbility(bonusMaxAbility);
    }

    public void ADDTextHeroName()
    {
        if (characteristicsHero == true) HeroName = characteristicsHero.Name;
        if (characteristicsHero == true) TextHeroName.text = HeroName;
    }

    public void ErrorArcher()
    {
        if (generalSettings.Language == "ru") DisplayActionLog = "Чтобы стрелять из лука, вы должны иметь при себе лук.";
        if (generalSettings.Language == "en") DisplayActionLog = "To shoot from a bow, you must have a bow with you.";
    }
}