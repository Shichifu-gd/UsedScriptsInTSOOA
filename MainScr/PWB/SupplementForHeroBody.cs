using UnityEngine;

public class SupplementForHeroBody : MonoBehaviour
{
    public DisplayBattleValues displayBattleValues;
    public BattleScript battleScript;
    public CharacteristicsHero characteristicsHero;
    public PatrsBodyHero patrsBodyHero;

    public bool SwichBlowToTheHeadZero;
    public bool SwichBlowToTheHeadOne;
    public bool SwichBlowToTheHeadTwo;
    public bool SwichBlowToTheBodyZero;
    public bool SwichBlowToTheBodyOne;
    public bool SwichBlowToTheBodyTwo;
    public bool SwichBlowToTheLHandZero;
    public bool SwichBlowToTheLHandOne;
    public bool SwichBlowToTheLHandTwo;
    public bool SwichBlowToTheRHandZero;
    public bool SwichBlowToTheRHandOne;
    public bool SwichBlowToTheRHandTwo;
    public bool SwichBlowToTheLLegZero;
    public bool SwichBlowToTheLLegOne;
    public bool SwichBlowToTheLLegTwo;
    public bool SwichBlowToTheRLegZero;
    public bool SwichBlowToTheRLegOne;
    public bool SwichBlowToTheRLegTwo;

    float NumberForBlowToTheHead;
    float NumberForBlowToTheBody;
    float NumberForBlowToTheLHand;
    float NumberForBlowToTheRHand;
    float NumberForBlowToTheLLeg;
    float NumberForBlowToTheRLeg;
    float DebuffForHeroBlock;

    string state;
    string StateBody;
    string StateLeftHand;
    string StateRightHand;

    bool BlockMoreThanAHalf;
    bool BlockLessThanHalf;
    bool BlockEqualsZero;

    private static System.Random RandomAttackEnemy = new System.Random();

    public void load()
    {
        BlowToTheHeadForLoad();
        BlowToTheBodyForLoad();
        BlowToTheLHandForLoad();
        BlowToTheRHandForLoad();
        BlowToTheLLegForLoad();
        BlowToTheRLegForLoad();
    }

    void BlowToTheHeadForLoad()
    {
        float NumberToCount = (characteristicsHero.Head / 2) / 2;
        if (characteristicsHero.CurrentHead == characteristicsHero.Head) state = "Не поврежденный";
        if (characteristicsHero.CurrentHead > NumberToCount && characteristicsHero.CurrentHead != characteristicsHero.Head) SwitchBlowToTheHead(state = "Больше половины");
        if (characteristicsHero.CurrentHead <= NumberToCount &&
            characteristicsHero.CurrentHead > 0) SwitchBlowToTheHead(state = "Меньше половины");
        if (characteristicsHero.CurrentHead == 0) SwitchBlowToTheHead(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "голова");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние головы", NumberForBlowToTheHead);
    }

    public void BlowToTheHead()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentHead > 0) characteristicsHero.CurrentHead -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentHead < 0) characteristicsHero.CurrentHead = 0;
            if (characteristicsHero.CurrentHead < characteristicsHero.Head)
            {
                float NumberToCount = (characteristicsHero.Head / 2) / 2;
                if (characteristicsHero.CurrentHead > NumberToCount) SwitchBlowToTheHead(state = "Больше половины");
                if (characteristicsHero.CurrentHead <= NumberToCount &&
                    characteristicsHero.CurrentHead > 0) SwitchBlowToTheHead(state = "Меньше половины");
                if (characteristicsHero.CurrentHead <= 0) SwitchBlowToTheHead(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "голова");
                displayBattleValues.SwitchForOutputToDisplay("состояние головы", NumberForBlowToTheHead);
            }
        }
    }

    void SwitchBlowToTheHead(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheHeadZero == false)
            {
                if (SwichBlowToTheHeadOne == true)
                {
                    NumberForBlowToTheHead = 2;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility += NumberForBlowToTheHead;
                    SwichBlowToTheHeadOne = false;
                }
                if (SwichBlowToTheHeadTwo == true)
                {
                    NumberForBlowToTheHead = 3;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility += NumberForBlowToTheHead;
                    SwichBlowToTheHeadTwo = false;
                }
                NumberForBlowToTheHead = 1;
                displayBattleValues.ability -= NumberForBlowToTheHead;
                if (battleScript == true) battleScript.MaxAbilityHero -= NumberForBlowToTheHead;
                else characteristicsHero.MaxAbility -= NumberForBlowToTheHead;
                SwichBlowToTheHeadZero = true;
            }
        }
        if (state == "Меньше половины")
        {
            if (SwichBlowToTheHeadOne == false)
            {
                if (SwichBlowToTheHeadZero == true)
                {
                    NumberForBlowToTheHead = 1;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility = characteristicsHero.MaxAbility + NumberForBlowToTheHead;
                    SwichBlowToTheHeadZero = false;
                }
                if (SwichBlowToTheHeadTwo == true)
                {
                    NumberForBlowToTheHead = 3;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility += NumberForBlowToTheHead;
                    SwichBlowToTheHeadTwo = false;
                }
                NumberForBlowToTheHead = 2;
                displayBattleValues.ability -= NumberForBlowToTheHead;
                if (battleScript == true) battleScript.MaxAbilityHero -= NumberForBlowToTheHead;
                else characteristicsHero.MaxAbility -= NumberForBlowToTheHead;
                SwichBlowToTheHeadOne = true;
            }
        }
        if (state == "Равна нулю")
        {
            if (SwichBlowToTheHeadTwo == false)
            {
                if (SwichBlowToTheHeadZero == true)
                {
                    NumberForBlowToTheHead = 1;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility += NumberForBlowToTheHead;
                    SwichBlowToTheHeadZero = false;
                }
                if (SwichBlowToTheHeadOne == true)
                {
                    NumberForBlowToTheHead = 2;
                    displayBattleValues.ability += NumberForBlowToTheHead;
                    if (battleScript == true) battleScript.MaxAbilityHero += NumberForBlowToTheHead;
                    else characteristicsHero.MaxAbility += NumberForBlowToTheHead;
                    SwichBlowToTheHeadOne = false;
                }
                NumberForBlowToTheHead = 3;
                displayBattleValues.ability -= NumberForBlowToTheHead;
                if (battleScript == true) battleScript.MaxAbilityHero -= NumberForBlowToTheHead;
                else characteristicsHero.MaxAbility -= NumberForBlowToTheHead;
                SwichBlowToTheHeadTwo = true;
            }
        }
    }

    void BlowToTheBodyForLoad()
    {
        float NumberToCount = (characteristicsHero.Body / 2) / 2;

        if (characteristicsHero.CurrentBody == characteristicsHero.Body) state = "Не поврежденный";
        if (characteristicsHero.CurrentBody > NumberToCount && characteristicsHero.CurrentBody < characteristicsHero.Body) SwitchBlowToTheBody(state = "Больше половины");
        if (characteristicsHero.CurrentBody <= NumberToCount &&
            characteristicsHero.CurrentBody > 0) SwitchBlowToTheBody(state = "Меньше половины");
        if (characteristicsHero.CurrentBody == 0) SwitchBlowToTheBody(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "тело");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние тела", NumberForBlowToTheBody);
        HeroBlock(state, "состояние тела");
    }

    public void BlowToTheBody()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentBody > 0) characteristicsHero.CurrentBody -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentBody < 0) characteristicsHero.CurrentBody = 0;
            if (characteristicsHero.CurrentBody < characteristicsHero.Body)
            {
                float NumberToCount = (characteristicsHero.Body / 2) / 2;
                if (characteristicsHero.CurrentBody > NumberToCount) SwitchBlowToTheBody(state = "Больше половины");
                if (characteristicsHero.CurrentBody <= NumberToCount &&
                    characteristicsHero.CurrentBody > 0) SwitchBlowToTheBody(state = "Меньше половины");
                if (characteristicsHero.CurrentBody == 0) SwitchBlowToTheBody(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "тело");
                displayBattleValues.SwitchForOutputToDisplay("состояние тела", NumberForBlowToTheBody);
                HeroBlock(state, "состояние тела");
            }
        }
    }

    void SwitchBlowToTheBody(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheBodyZero == false)
            {
                if (SwichBlowToTheBodyOne == true)
                {
                    NumberForBlowToTheBody = 3;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyOne = false;
                }
                if (SwichBlowToTheBodyTwo == true)
                {
                    NumberForBlowToTheBody = 5;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyTwo = false;
                }
                NumberForBlowToTheBody = 1;
                displayBattleValues.armor -= NumberForBlowToTheBody;
                if (battleScript == true) battleScript.MaxArmorHero -= NumberForBlowToTheBody;
                else characteristicsHero.MaxArmor -= NumberForBlowToTheBody;
                SwichBlowToTheBodyZero = true;
            }
        }
        if (state == "Меньше половины")
        {
            if (SwichBlowToTheBodyOne == false)
            {
                if (SwichBlowToTheBodyZero == true)
                {
                    NumberForBlowToTheBody = 1;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyZero = false;
                }
                if (SwichBlowToTheBodyTwo == true)
                {
                    NumberForBlowToTheBody = 5;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyTwo = false;
                }
                NumberForBlowToTheBody = 3;
                displayBattleValues.armor -= NumberForBlowToTheBody;
                if (battleScript == true) battleScript.MaxArmorHero -= NumberForBlowToTheBody;
                else characteristicsHero.MaxArmor -= NumberForBlowToTheBody;
                SwichBlowToTheBodyOne = true;
            }
        }
        if (state == "Равна нулю")
        {
            if (SwichBlowToTheHeadTwo == false)
            {
                if (SwichBlowToTheBodyZero == true)
                {
                    NumberForBlowToTheBody = 1;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyZero = false;
                }

                if (SwichBlowToTheBodyOne == true)
                {
                    NumberForBlowToTheBody = 3;
                    displayBattleValues.armor += NumberForBlowToTheBody;
                    if (battleScript == true) battleScript.MaxArmorHero += NumberForBlowToTheBody;
                    else characteristicsHero.MaxArmor += NumberForBlowToTheBody;
                    SwichBlowToTheBodyOne = false;
                }
                NumberForBlowToTheBody = 5;
                displayBattleValues.armor -= NumberForBlowToTheBody;
                if (battleScript == true) battleScript.MaxArmorHero -= NumberForBlowToTheBody;
                else characteristicsHero.MaxArmor -= NumberForBlowToTheBody;
                SwichBlowToTheBodyTwo = true;
            }
        }
    }

    void BlowToTheLHandForLoad()
    {
        float NumberToCount = (characteristicsHero.LHand / 2) / 2;

        if (characteristicsHero.CurrentLHand == characteristicsHero.LHand) state = "Не поврежденный";
        if (characteristicsHero.CurrentLHand > NumberToCount && characteristicsHero.CurrentLHand != characteristicsHero.LHand) SwitchBlowToTheLHand(state = "Больше половины");
        if (characteristicsHero.CurrentLHand <= NumberToCount &&
            characteristicsHero.CurrentLHand > 0) SwitchBlowToTheLHand(state = "Меньше половины");

        if (characteristicsHero.CurrentLHand == 0) SwitchBlowToTheLHand(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "левая рука");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние левой руки", NumberForBlowToTheLHand);
        HeroBlock(state, "состояние левой руки");
    }

    public void BlowToTheLHand()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentLHand > 0) characteristicsHero.CurrentLHand -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentLHand < 0) characteristicsHero.CurrentLHand = 0;
            if (characteristicsHero.CurrentLHand < characteristicsHero.LHand)
            {
                float NumberToCount = (characteristicsHero.LHand / 2) / 2;
                if (characteristicsHero.CurrentLHand > NumberToCount) SwitchBlowToTheLHand(state = "Больше половины");
                if (characteristicsHero.CurrentLHand <= NumberToCount &&
                    characteristicsHero.CurrentLHand > 0) SwitchBlowToTheLHand(state = "Меньше половины");
                if (characteristicsHero.CurrentLHand <= 0) SwitchBlowToTheLHand(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "левая рука");
                displayBattleValues.SwitchForOutputToDisplay("состояние левой руки", NumberForBlowToTheLHand);
                HeroBlock(state, "состояние левой руки");
            }
        }
    }

    void SwitchBlowToTheLHand(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheLHandZero == false)
            {
                if (SwichBlowToTheLHandOne == true)
                {
                    NumberForBlowToTheLHand = 2;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandOne = false;
                }

                if (SwichBlowToTheLHandTwo == true)
                {
                    NumberForBlowToTheLHand = 4;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandTwo = false;
                }
                NumberForBlowToTheLHand = 1;
                displayBattleValues.attack -= NumberForBlowToTheLHand;
                if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheLHand;
                else characteristicsHero.MaxAttack -= NumberForBlowToTheLHand;
                SwichBlowToTheLHandZero = true;
            }
        }
        if (state == "Меньше половины")
        {
            if (SwichBlowToTheLHandOne == false)
            {
                if (SwichBlowToTheLHandZero == true)
                {
                    NumberForBlowToTheLHand = 1;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandZero = false;
                }

                if (SwichBlowToTheLHandTwo == true)
                {
                    NumberForBlowToTheLHand = 4;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandTwo = false;
                }
                NumberForBlowToTheLHand = 2;
                displayBattleValues.attack -= NumberForBlowToTheLHand;
                if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheLHand;
                else characteristicsHero.MaxAttack -= NumberForBlowToTheLHand;
                SwichBlowToTheLHandOne = true;
            }
        }
        if (state == "Равна нулю")
        {
            if (SwichBlowToTheLHandTwo == false)
            {
                if (SwichBlowToTheLHandZero == true)
                {
                    NumberForBlowToTheLHand = 1;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandZero = false;
                }
                if (SwichBlowToTheLHandOne == true)
                {
                    NumberForBlowToTheLHand = 2;
                    displayBattleValues.attack += NumberForBlowToTheLHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheLHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandOne = false;
                }
                NumberForBlowToTheLHand = 4;
                displayBattleValues.attack -= NumberForBlowToTheLHand;
                if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheLHand;
                if (battleScript == false) characteristicsHero.MaxAttack -= NumberForBlowToTheLHand;
                SwichBlowToTheLHandTwo = true;
            }
        }
    }

    void BlowToTheRHandForLoad()
    {
        float NumberToCount = (characteristicsHero.RHand / 2) / 2;

        if (characteristicsHero.CurrentRHand == characteristicsHero.RHand) state = "Не поврежденный";
        if (characteristicsHero.CurrentRHand > NumberToCount && characteristicsHero.CurrentRHand != characteristicsHero.RHand) SwitchBlowToTheRHand(state = "Больше половины");
        if (characteristicsHero.CurrentRHand <= NumberToCount &&
            characteristicsHero.CurrentRHand > 0) SwitchBlowToTheRHand(state = "Меньше половины");
        if (characteristicsHero.CurrentRHand <= 0) SwitchBlowToTheRHand(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "правая рука");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние правой руки", NumberForBlowToTheRHand);
        HeroBlock(state, "состояние правой руки");
    }

    public void BlowToTheRHand()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentRHand > 0) characteristicsHero.CurrentRHand -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentRHand < 0) characteristicsHero.CurrentRHand = 0;
            if (characteristicsHero.CurrentRHand < characteristicsHero.RHand)
            {
                float NumberToCount = (characteristicsHero.RHand / 2) / 2;
                if (characteristicsHero.CurrentRHand > NumberToCount) SwitchBlowToTheRHand(state = "Больше половины");
                if (characteristicsHero.CurrentRHand <= NumberToCount &&
                    characteristicsHero.CurrentRHand > 0) SwitchBlowToTheRHand(state = "Меньше половины");
                if (characteristicsHero.CurrentRHand <= 0) SwitchBlowToTheRHand(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "правая рука");
                displayBattleValues.SwitchForOutputToDisplay("состояние правой руки", NumberForBlowToTheRHand);
                HeroBlock(state, "состояние правой руки");
            }
        }
    }

    void SwitchBlowToTheRHand(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheRHandZero == false)
            {
                if (SwichBlowToTheRHandOne == true)
                {
                    NumberForBlowToTheRHand = 2;
                    displayBattleValues.attack += NumberForBlowToTheRHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandOne = false;
                }
                if (SwichBlowToTheRHandTwo == true)
                {
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.attack += NumberForBlowToTheRHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = false;
                }
                NumberForBlowToTheRHand = 1;
                displayBattleValues.attack -= NumberForBlowToTheRHand;
                if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheRHand;
                else characteristicsHero.MaxAttack -= NumberForBlowToTheRHand;
                SwichBlowToTheRHandZero = true;
            }
        }
        if (state == "Меньше половины")
        {
            if (SwichBlowToTheRHandOne == false)
            {
                if (SwichBlowToTheRHandZero == true)
                {
                    NumberForBlowToTheRHand = 1;
                    displayBattleValues.attack += NumberForBlowToTheRHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandZero = false;
                }
                if (SwichBlowToTheRHandTwo == true)
                {
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.attack += NumberForBlowToTheRHand;
                    if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                    else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = false;
                }
                NumberForBlowToTheRHand = 2;
                displayBattleValues.attack -= NumberForBlowToTheRHand;
                if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheRHand;
                else characteristicsHero.MaxAttack -= NumberForBlowToTheRHand;
                SwichBlowToTheRHandOne = true;
            }
        }
        if (state == "Равна нулю")
        {
            if (SwichBlowToTheRHandTwo == false)
            {
                {
                    if (SwichBlowToTheRHandZero == true)
                    {
                        NumberForBlowToTheRHand = 1;
                        displayBattleValues.attack += NumberForBlowToTheRHand;
                        if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                        else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                        SwichBlowToTheRHandZero = false;
                    }
                    if (SwichBlowToTheRHandOne == true)
                    {
                        NumberForBlowToTheRHand = 2;
                        displayBattleValues.attack += NumberForBlowToTheRHand;
                        if (battleScript == true) battleScript.MaxAttackHero += NumberForBlowToTheRHand;
                        else characteristicsHero.MaxAttack += NumberForBlowToTheRHand;
                        SwichBlowToTheRHandOne = false;
                    }
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.attack -= NumberForBlowToTheRHand;
                    if (battleScript == true) battleScript.MaxAttackHero -= NumberForBlowToTheRHand;
                    else characteristicsHero.MaxAttack -= NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = true;
                }
            }
        }
    }

    void HeroBlock(string state, string InformationForSwitchForOutputToDisplay)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние тела")
        {
            if (state == "Больше половины") StateBody = "состояние тела: больше половины";
            if (state == "Меньше половины") StateBody = "состояние тела: меньше половины";
            if (state == "Равна нулю") StateBody = "состояние тела: равна нулю";
        }
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки")
        {
            if (state == "Больше половины") StateRightHand = "состояние  правой руки: больше половины";
            if (state == "Меньше половины") StateRightHand = "состояние правой руки: меньше половины";
            if (state == "Равна нулю") StateRightHand = "состояние  правой руки: равна нулю";
        }
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки")
        {
            if (state == "Больше половины") StateLeftHand = "состояние левой руки: больше половины";
            if (state == "Меньше половины") StateLeftHand = "состояние левой руки: меньше половины";
            if (state == "Равна нулю") StateLeftHand = "состояние левой руки: равна нулю";
        }
        DebuffForBlock();
        displayBattleValues.OutputToDisplayBuffAndDebuffBlock();
    }

    void DebuffForBlock()
    {
        if (StateBody == "состояние тела: больше половины" &&
            StateRightHand == "состояние  правой руки: больше половины" &&
            StateLeftHand == "состояние левой руки: больше половины")
        {
            if (BlockMoreThanAHalf == false)
            {
                if (BlockLessThanHalf == true)
                {
                    DebuffForHeroBlock = 2;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero = battleScript.BlockHero + DebuffForHeroBlock;
                    BlockLessThanHalf = false;
                }
                if (BlockEqualsZero == true)
                {
                    DebuffForHeroBlock = 4;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero += DebuffForHeroBlock;
                    BlockEqualsZero = false;
                }
                BlockMoreThanAHalf = true;
                DebuffForHeroBlock = 1;
                displayBattleValues.HeroBlock -= DebuffForHeroBlock;
                if (battleScript == true) battleScript.BlockHero -= DebuffForHeroBlock;
            }
        }
        if (StateBody == "состояние тела: меньше половины" &&
            StateRightHand == "состояние правой руки: меньше половины" &&
            StateLeftHand == "состояние левой руки: меньше половины")
        {
            if (BlockLessThanHalf == false)
            {
                if (BlockMoreThanAHalf == true)
                {
                    DebuffForHeroBlock = 1;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero += DebuffForHeroBlock;
                    BlockMoreThanAHalf = false;
                }
                if (BlockEqualsZero == true)
                {
                    DebuffForHeroBlock = 4;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero += DebuffForHeroBlock;
                    BlockEqualsZero = false;
                }
                BlockLessThanHalf = true;
                DebuffForHeroBlock = 2;
                displayBattleValues.HeroBlock -= DebuffForHeroBlock;
                if (battleScript == true) battleScript.BlockHero -= DebuffForHeroBlock;
            }
        }
        if (StateBody == "состояние тела: равна нулю" &&
            StateRightHand == "состояние  правой руки: равна нулю" &&
            StateLeftHand == "состояние левой руки: равна нулю")
        {
            if (BlockEqualsZero == false)
            {
                if (BlockLessThanHalf == true)
                {
                    DebuffForHeroBlock = 2;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero += DebuffForHeroBlock;
                    BlockLessThanHalf = false;
                }
                if (BlockMoreThanAHalf == true)
                {
                    DebuffForHeroBlock = 1;
                    displayBattleValues.HeroBlock += DebuffForHeroBlock;
                    if (battleScript == true) battleScript.BlockHero += DebuffForHeroBlock;
                    BlockMoreThanAHalf = false;
                }
                BlockEqualsZero = true;
                DebuffForHeroBlock = 4;
                displayBattleValues.HeroBlock -= DebuffForHeroBlock;
                if (battleScript == true) battleScript.BlockHero -= DebuffForHeroBlock;
            }
        }
    }

    void BlowToTheLLegForLoad()
    {
        float NumberToCount = (characteristicsHero.LLeg / 2) / 2;
        if (characteristicsHero.CurrentLLeg == characteristicsHero.LLeg) state = "Не поврежденный";
        if (characteristicsHero.CurrentLLeg > NumberToCount && characteristicsHero.CurrentLLeg != characteristicsHero.LLeg) SwitchBlowToTheLLeg(state = "Больше половины");
        if (characteristicsHero.CurrentLLeg <= NumberToCount &&
            characteristicsHero.CurrentLLeg > 0) SwitchBlowToTheLLeg(state = "Меньше половины");
        if (characteristicsHero.CurrentLLeg <= 0) SwitchBlowToTheLLeg(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "левая нога");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние левой ноги", NumberForBlowToTheLLeg);
    }

    public void BlowToTheLLeg()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentLLeg > 0) characteristicsHero.CurrentLLeg -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentLLeg < 0) characteristicsHero.CurrentLLeg = 0;
            if (characteristicsHero.CurrentLLeg < characteristicsHero.LLeg)
            {
                float NumberToCount = (characteristicsHero.LLeg / 2) / 2;
                if (characteristicsHero.CurrentLLeg > NumberToCount) SwitchBlowToTheLLeg(state = "Больше половины");
                if (characteristicsHero.CurrentLLeg <= NumberToCount &&
                    characteristicsHero.CurrentLLeg > 0) SwitchBlowToTheLLeg(state = "Меньше половины");
                if (characteristicsHero.CurrentLLeg <= 0) SwitchBlowToTheLLeg(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "левая нога");
                displayBattleValues.SwitchForOutputToDisplay("состояние левой ноги", NumberForBlowToTheLLeg);
            }
        }
    }

    void SwitchBlowToTheLLeg(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheLLegZero == false)
            {
                if (SwichBlowToTheLLegOne == true)
                {
                    NumberForBlowToTheLLeg = 0.1f;
                    characteristicsHero.Regen -= NumberForBlowToTheLLeg;
                    SwichBlowToTheLLegOne = false;
                }
                if (SwichBlowToTheLLegTwo == true)
                {
                    NumberForBlowToTheLLeg = 0.2f;
                    characteristicsHero.Regen -= NumberForBlowToTheLLeg;
                    SwichBlowToTheLLegTwo = false;
                }
                SwichBlowToTheLLegZero = true;
            }
        }
        if (state == "Меньше половины")
        {
            if (SwichBlowToTheLLegOne == false)
            {
                if (SwichBlowToTheLLegZero == true)
                {
                    SwichBlowToTheLLegZero = false;
                }
                if (SwichBlowToTheLLegTwo == true)
                {
                    NumberForBlowToTheLLeg = 0.2f;
                    characteristicsHero.Regen -= NumberForBlowToTheLLeg;
                    SwichBlowToTheLLegTwo = false;
                }
                NumberForBlowToTheLLeg = 0.1f;
                characteristicsHero.Regen += NumberForBlowToTheLLeg;
                SwichBlowToTheLLegOne = true;
            }
        }
        if (state == "Равна нулю")
        {
            if (SwichBlowToTheLLegTwo == false)
            {
                if (SwichBlowToTheLLegZero == true)
                {
                    SwichBlowToTheLLegZero = false;
                }
                if (SwichBlowToTheLLegOne == true)
                {
                    NumberForBlowToTheLLeg = 0.1f;
                    characteristicsHero.Regen -= NumberForBlowToTheLLeg;
                    SwichBlowToTheLLegOne = false;
                }
                NumberForBlowToTheLLeg = 0.2f;
                characteristicsHero.Regen += NumberForBlowToTheLLeg;
                SwichBlowToTheLLegTwo = true;
            }
        }
    }

    void BlowToTheRLegForLoad()
    {
        float NumberToCount = (characteristicsHero.RLeg / 2) / 2;
        if (characteristicsHero.CurrentRLeg == characteristicsHero.RLeg) state = "Не поврежденный";
        if (characteristicsHero.CurrentRLeg > NumberToCount && characteristicsHero.CurrentRLeg != characteristicsHero.RLeg) SwitchBlowToTheRLeg(state = "Больше половины");
        if (characteristicsHero.CurrentRLeg <= NumberToCount &&
            characteristicsHero.CurrentRLeg > 0) SwitchBlowToTheRLeg(state = "Меньше половины");
        if (characteristicsHero.CurrentRLeg <= 0) SwitchBlowToTheRLeg(state = "Равна нулю");
        patrsBodyHero.SwitchToPartsBody(state, "правая нога");
        displayBattleValues.SwitchForOutputToDisplayToLoad("состояние правой ноги", NumberForBlowToTheRLeg);
    }

    public void BlowToTheRLeg()
    {
        float EnemyAttack;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            EnemyAttack = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsHero.CurrentRLeg > 0) characteristicsHero.CurrentRLeg -= EnemyAttack;
            if (battleScript.characteristicsHero.CurrentRLeg < 0) characteristicsHero.CurrentRLeg = 0;

            if (characteristicsHero.CurrentRLeg < characteristicsHero.RLeg)
            {
                float NumberToCount = (characteristicsHero.RLeg / 2) / 2;
                if (characteristicsHero.CurrentRLeg > NumberToCount) SwitchBlowToTheRLeg(state = "Больше половины");
                if (characteristicsHero.CurrentRLeg <= NumberToCount &&
                    characteristicsHero.CurrentRLeg > 0) SwitchBlowToTheRLeg(state = "Меньше половины");
                if (characteristicsHero.CurrentRLeg <= 0) SwitchBlowToTheRLeg(state = "Равна нулю");
                patrsBodyHero.SwitchToPartsBody(state, "правая нога");
                displayBattleValues.SwitchForOutputToDisplay("состояние правой ноги", NumberForBlowToTheRLeg);
            }
        }
    }

    void SwitchBlowToTheRLeg(string state)
    {
        if (state == "Больше половины")
        {
            if (SwichBlowToTheRLegZero == false)
            {
                if (SwichBlowToTheRLegOne == true)
                {
                    NumberForBlowToTheRLeg = 0.1f;
                    characteristicsHero.Regen += NumberForBlowToTheRLeg;
                    SwichBlowToTheRLegOne = false;
                }
                if (SwichBlowToTheRLegTwo == true)
                {
                    NumberForBlowToTheRLeg = 0.2f;
                    characteristicsHero.Regen += NumberForBlowToTheRLeg;
                    SwichBlowToTheRLegTwo = false;
                }
                SwichBlowToTheRLegZero = true;
            }
            if (state == "Меньше половины")
            {
                if (SwichBlowToTheRLegOne == false)
                {
                    if (SwichBlowToTheRLegZero == true)
                    {
                        SwichBlowToTheRLegZero = false;
                    }

                    if (SwichBlowToTheRLegTwo == true)
                    {
                        NumberForBlowToTheRLeg = 0.2f;
                        characteristicsHero.Regen -= NumberForBlowToTheRLeg;
                        SwichBlowToTheRLegTwo = false;
                    }
                    NumberForBlowToTheRLeg = 0.1f;
                    characteristicsHero.Regen += NumberForBlowToTheRLeg;
                    SwichBlowToTheRLegOne = true;
                }
            }
            if (state == "Равна нулю")
            {
                if (SwichBlowToTheRLegTwo == false)
                {
                    if (SwichBlowToTheRLegZero == true)
                    {
                        SwichBlowToTheRLegZero = false;
                    }

                    if (SwichBlowToTheRLegOne == true)
                    {
                        NumberForBlowToTheRLeg = 0.1f;
                        characteristicsHero.Regen -= NumberForBlowToTheRLeg;
                        SwichBlowToTheRLegOne = false;
                    }
                    NumberForBlowToTheRLeg = 0.2f;
                    characteristicsHero.Regen += NumberForBlowToTheRLeg;
                    SwichBlowToTheRLegTwo = true;
                }
            }
        }
    }

    public void BodyRecovery()
    {
        if (SwichBlowToTheHeadZero == true)
        {
            displayBattleValues.ability += 1;
            if (battleScript) battleScript.MaxAbilityHero += 1;
        }
        if (SwichBlowToTheHeadOne == true)
        {
            if (battleScript) displayBattleValues.ability += 2;
            battleScript.MaxAbilityHero += 2;
        }
        if (SwichBlowToTheHeadTwo == true)
        {
            displayBattleValues.ability += 3;
            if (battleScript) battleScript.MaxAbilityHero += 3;
        }
        if (SwichBlowToTheBodyZero == true)
        {
            displayBattleValues.armor += 1;
            if (battleScript) battleScript.MaxArmorHero += 1;
        }
        if (SwichBlowToTheBodyOne == true)
        {
            displayBattleValues.armor += 3;
            if (battleScript) battleScript.MaxArmorHero += 3;
        }
        if (SwichBlowToTheBodyTwo == true)
        {
            displayBattleValues.armor += 5;
            if (battleScript) battleScript.MaxArmorHero += 5;
        }
        if (SwichBlowToTheLHandZero == true)
        {
            displayBattleValues.attack += 1;
            if (battleScript) battleScript.MaxAttackHero += 1;
        }
        if (SwichBlowToTheLHandOne == true)
        {
            displayBattleValues.attack += 2;
            if (battleScript) battleScript.MaxAttackHero += 2;
        }
        if (SwichBlowToTheLHandTwo == true)
        {
            displayBattleValues.attack += 4;
            if (battleScript) battleScript.MaxAttackHero += 4;
        }
        if (SwichBlowToTheRHandZero == true)
        {
            displayBattleValues.attack += 1;
            if (battleScript) battleScript.MaxAttackHero += 1;
        }
        if (SwichBlowToTheRHandOne == true)
        {
            displayBattleValues.attack += 2;
            if (battleScript) battleScript.MaxAttackHero += 2;
        }
        if (SwichBlowToTheRHandTwo == true)
        {
            displayBattleValues.attack += 4;
            if (battleScript) battleScript.MaxAttackHero += 4;
        }
        if (SwichBlowToTheLLegOne == true)
        {
            characteristicsHero.Regen += 0.1f;
        }
        if (SwichBlowToTheLLegTwo == true)
        {
            characteristicsHero.Regen += 0.2f;
        }
        if (SwichBlowToTheRLegOne == true)
        {
            characteristicsHero.Regen += 0.1f;
        }
        if (SwichBlowToTheRLegTwo == true)
        {
            characteristicsHero.Regen += 0.2f;
        }
        if (BlockMoreThanAHalf == true)
        {
            displayBattleValues.HeroBlock += 1;
            if (battleScript) battleScript.BlockHero += 1;
        }
        if (BlockLessThanHalf == true)
        {
            displayBattleValues.HeroBlock += 2;
            if (battleScript) battleScript.BlockHero += 2;
        }
        if (BlockEqualsZero == true)
        {
            displayBattleValues.HeroBlock += 4;
            if (battleScript) battleScript.BlockHero += 4;
        }
        displayBattleValues.BodyValueRecovery();
        patrsBodyHero.RecoveryColor();
    }
}