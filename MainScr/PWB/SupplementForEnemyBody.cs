using UnityEngine;

public class SupplementForEnemyBody : MonoBehaviour
{
    public DisplayBattleValues displayBattleValues;
    public BattleScript battleScript;
    public CharacteristicsEnemy characteristicsEnemy;
    public PatrsBodyEnemy patrsBodyEnemy;

    bool SwichBlowToTheHeadZero;
    bool SwichBlowToTheHeadOne;
    bool SwichBlowToTheHeadTwo;
    bool SwichBlowToTheBodyZero;
    bool SwichBlowToTheBodyOne;
    bool SwichBlowToTheBodyTwo;
    bool SwichBlowToTheLHandZero;
    bool SwichBlowToTheLHandOne;
    bool SwichBlowToTheLHandTwo;
    bool SwichBlowToTheRHandZero;
    bool SwichBlowToTheRHandOne;
    bool SwichBlowToTheRHandTwo;
    bool SwichBlowToTheLLegZero;
    bool SwichBlowToTheLLegOne;
    bool SwichBlowToTheLLegTwo;
    bool SwichBlowToTheRLegZero;
    bool SwichBlowToTheRLegOne;
    bool SwichBlowToTheRLegTwo;
    float NumberForBlowToTheHead;
    float NumberForBlowToTheBody;
    float NumberForBlowToTheLHand;
    float NumberForBlowToTheRHand;
    float NumberForBlowToTheLLeg;
    float NumberForBlowToTheRLeg;
    float DebuffForEnemyBlock;

    string state;
    string InformationForSwitchForOutputToDisplay;
    string StateBody;
    string StateLeftHand;
    string StateRightHand;

    bool BlockMoreThanAHalf;
    bool BlockLessThanHalf;
    bool BlockEqualsZero;

    private static System.Random RandomAttackEnemy = new System.Random();

    public void BlowToTheHead()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentHead > 0) characteristicsEnemy.CurrentHead -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentHead < 0) characteristicsEnemy.CurrentHead = 0;
            if (characteristicsEnemy.CurrentHead < characteristicsEnemy.Head)
            {
                float NumberToCount = (characteristicsEnemy.Head / 2) / 2;
                if (characteristicsEnemy.CurrentHead > NumberToCount) SwitchBlowToTheHead(state = "Больше половины");
                if (characteristicsEnemy.CurrentHead <= NumberToCount &&
                    characteristicsEnemy.CurrentHead > 0) SwitchBlowToTheHead(state = "Меньше половины");
                if (characteristicsEnemy.CurrentHead == 0) SwitchBlowToTheHead(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "голова");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние головы", NumberForBlowToTheHead);
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
                    SwichBlowToTheHeadOne = false;
                }

                if (SwichBlowToTheHeadTwo == true)
                {
                    NumberForBlowToTheHead = 3;
                    SwichBlowToTheHeadTwo = false;
                }
                NumberForBlowToTheHead = 1;
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
                    SwichBlowToTheHeadZero = false;
                }

                if (SwichBlowToTheHeadTwo == true)
                {
                    NumberForBlowToTheHead = 3;
                    SwichBlowToTheHeadTwo = false;
                }
                NumberForBlowToTheHead = 2;
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
                    SwichBlowToTheHeadZero = false;
                }

                if (SwichBlowToTheHeadOne == true)
                {
                    NumberForBlowToTheHead = 2;
                    SwichBlowToTheHeadOne = false;
                }
                NumberForBlowToTheHead = 3;
                SwichBlowToTheHeadTwo = true;
            }
        }
    }

    public void BlowToTheBody()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentBody > 0) characteristicsEnemy.CurrentBody -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentBody < 0) characteristicsEnemy.CurrentBody = 0;

            if (characteristicsEnemy.CurrentBody < characteristicsEnemy.Body)
            {
                float NumberToCount = (characteristicsEnemy.Body / 2) / 2;
                if (characteristicsEnemy.CurrentBody > NumberToCount) SwitchBlowToTheBody(state = "Больше половины");
                if (characteristicsEnemy.CurrentBody <= NumberToCount &&
                    characteristicsEnemy.CurrentBody > 0) SwitchBlowToTheBody(state = "Меньше половины");
                if (characteristicsEnemy.CurrentBody == 0) SwitchBlowToTheBody(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "тело");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние тела", NumberForBlowToTheBody);
                EnemyBlock(state, "состояние тела");
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
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyOne = false;
                }

                if (SwichBlowToTheBodyTwo == true)
                {
                    NumberForBlowToTheBody = 5;
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyTwo = false;
                }
                NumberForBlowToTheBody = 1;
                displayBattleValues.EnemyArmor -= NumberForBlowToTheBody;
                battleScript.MaxArmorEnemy -= NumberForBlowToTheBody;
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
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyZero = false;
                }

                if (SwichBlowToTheBodyTwo == true)
                {
                    NumberForBlowToTheBody = 5;
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyTwo = false;
                }
                NumberForBlowToTheBody = 3;
                displayBattleValues.EnemyArmor -= NumberForBlowToTheBody;
                battleScript.MaxArmorEnemy -= NumberForBlowToTheBody;
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
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyZero = false;
                }

                if (SwichBlowToTheBodyOne == true)
                {
                    NumberForBlowToTheBody = 3;
                    displayBattleValues.EnemyArmor += NumberForBlowToTheBody;
                    battleScript.MaxArmorEnemy += NumberForBlowToTheBody;
                    SwichBlowToTheBodyOne = false;
                }
                NumberForBlowToTheBody = 5;
                displayBattleValues.EnemyArmor -= NumberForBlowToTheBody;
                battleScript.MaxArmorEnemy -= NumberForBlowToTheBody;
                SwichBlowToTheBodyTwo = true;
            }
        }
    }

    public void BlowToTheLHand()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentLHand > 0) characteristicsEnemy.CurrentLHand -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentLHand < 0) characteristicsEnemy.CurrentLHand = 0;
            if (characteristicsEnemy.CurrentLHand < characteristicsEnemy.LHand)
            {
                float NumberToCount = (characteristicsEnemy.LHand / 2) / 2;
                if (characteristicsEnemy.CurrentLHand > NumberToCount) SwitchBlowToTheLHand(state = "Больше половины");
                if (characteristicsEnemy.CurrentLHand <= NumberToCount &&
                    characteristicsEnemy.CurrentLHand > 0) SwitchBlowToTheLHand(state = "Меньше половины");
                if (characteristicsEnemy.CurrentLHand == 0) SwitchBlowToTheLHand(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "левая рука");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние левой руки", NumberForBlowToTheLHand);
                EnemyBlock(state, "состояние левой руки");
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
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandOne = false;
                }

                if (SwichBlowToTheLHandTwo == true)
                {
                    NumberForBlowToTheLHand = 4;
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandTwo = false;
                }
                NumberForBlowToTheLHand = 1;
                displayBattleValues.EnemyAttack -= NumberForBlowToTheLHand;
                battleScript.MaxAttackEnemy -= NumberForBlowToTheLHand;
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
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandZero = false;
                }

                if (SwichBlowToTheLHandTwo == true)
                {
                    NumberForBlowToTheLHand = 4;
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandTwo = false;
                }
                NumberForBlowToTheLHand = 2;
                displayBattleValues.EnemyAttack -= NumberForBlowToTheLHand;
                battleScript.MaxAttackEnemy -= NumberForBlowToTheLHand;
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
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandZero = false;
                }
                if (SwichBlowToTheLHandOne == true)
                {
                    NumberForBlowToTheLHand = 2;
                    displayBattleValues.EnemyAttack += NumberForBlowToTheLHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheLHand;
                    SwichBlowToTheLHandOne = false;
                }
                NumberForBlowToTheLHand = 4;
                displayBattleValues.EnemyAttack -= NumberForBlowToTheLHand;
                battleScript.MaxAttackEnemy -= NumberForBlowToTheLHand;
                SwichBlowToTheLHandTwo = true;
            }
        }
    }

    public void BlowToTheRHand()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentRHand > 0) characteristicsEnemy.CurrentRHand -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentRHand < 0) characteristicsEnemy.CurrentRHand = 0;
            if (characteristicsEnemy.CurrentRHand < characteristicsEnemy.RHand)
            {
                float NumberToCount = (characteristicsEnemy.RHand / 2) / 2;
                if (characteristicsEnemy.CurrentRHand > NumberToCount) SwitchBlowToTheRHand(state = "Больше половины");
                if (characteristicsEnemy.CurrentRHand <= NumberToCount &&
                    characteristicsEnemy.CurrentRHand > 0) SwitchBlowToTheRHand(state = "Меньше половины");
                if (characteristicsEnemy.CurrentRHand == 0) SwitchBlowToTheRHand(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "правая рука");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние правой руки", NumberForBlowToTheRHand);
                EnemyBlock(state, "состояние правой руки");
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
                    displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandOne = false;
                }

                if (SwichBlowToTheRHandTwo == true)
                {
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = false;
                }
                NumberForBlowToTheRHand = 1;
                displayBattleValues.EnemyAttack -= NumberForBlowToTheRHand;
                battleScript.MaxAttackEnemy -= NumberForBlowToTheRHand;
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
                    displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandZero = false;
                }

                if (SwichBlowToTheRHandTwo == true)
                {
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                    battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = false;
                }
                NumberForBlowToTheRHand = 2;
                displayBattleValues.EnemyAttack -= NumberForBlowToTheRHand;
                battleScript.MaxAttackEnemy -= NumberForBlowToTheRHand;
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
                        displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                        battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                        SwichBlowToTheRHandZero = false;
                    }

                    if (SwichBlowToTheRHandOne == true)
                    {
                        NumberForBlowToTheRHand = 2;
                        displayBattleValues.EnemyAttack += NumberForBlowToTheRHand;
                        battleScript.MaxAttackEnemy += NumberForBlowToTheRHand;
                        SwichBlowToTheRHandOne = false;
                    }
                    NumberForBlowToTheRHand = 4;
                    displayBattleValues.EnemyAttack -= NumberForBlowToTheRHand;
                    battleScript.MaxAttackEnemy -= NumberForBlowToTheRHand;
                    SwichBlowToTheRHandTwo = true;
                }
            }
        }
    }

    void EnemyBlock(string state, string InformationForSwitchForOutputToDisplay)
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
        displayBattleValues.OutputToDisplayBuffAndDebuffEnemyBlock();
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
                    DebuffForEnemyBlock = 2;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockLessThanHalf = false;
                }

                if (BlockEqualsZero == true)
                {
                    DebuffForEnemyBlock = 4;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockEqualsZero = false;
                }
                BlockMoreThanAHalf = true;
                DebuffForEnemyBlock = 1;
                displayBattleValues.EnemyBlock -= DebuffForEnemyBlock;
                battleScript.BlockEnemy -= DebuffForEnemyBlock;
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
                    DebuffForEnemyBlock = 1;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockMoreThanAHalf = false;
                }

                if (BlockEqualsZero == true)
                {
                    DebuffForEnemyBlock = 4;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockEqualsZero = false;
                }
                BlockLessThanHalf = true;
                DebuffForEnemyBlock = 2;
                displayBattleValues.EnemyBlock -= DebuffForEnemyBlock;
                battleScript.BlockEnemy -= DebuffForEnemyBlock;
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
                    DebuffForEnemyBlock = 2;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockLessThanHalf = false;
                }

                if (BlockMoreThanAHalf == true)
                {
                    DebuffForEnemyBlock = 1;
                    displayBattleValues.EnemyBlock += DebuffForEnemyBlock;
                    battleScript.BlockEnemy += DebuffForEnemyBlock;
                    BlockMoreThanAHalf = false;
                }
                BlockEqualsZero = true;
                DebuffForEnemyBlock = 4;
                displayBattleValues.EnemyBlock -= DebuffForEnemyBlock;
                battleScript.BlockEnemy -= DebuffForEnemyBlock;
            }
        }
    }

    public void BlowToTheLLeg()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentLLeg > 0) characteristicsEnemy.CurrentLLeg -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentLLeg < 0) characteristicsEnemy.CurrentLLeg = 0;
            if (characteristicsEnemy.CurrentLLeg < characteristicsEnemy.LLeg)
            {
                float NumberToCount = (characteristicsEnemy.LLeg / 2) / 2;
                if (characteristicsEnemy.CurrentLLeg > NumberToCount) SwitchBlowToTheLLeg(state = "Больше половины");
                if (characteristicsEnemy.CurrentLLeg <= NumberToCount &&
                    characteristicsEnemy.CurrentLLeg > 0) SwitchBlowToTheLLeg(state = "Меньше половины");
                if (characteristicsEnemy.CurrentLLeg == 0) SwitchBlowToTheLLeg(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "левая нога");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние левой ноги", NumberForBlowToTheLLeg);

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
                    SwichBlowToTheLLegOne = false;
                }
                if (SwichBlowToTheLLegTwo == true)
                {
                    NumberForBlowToTheLLeg = 0.2f;
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
                    SwichBlowToTheLLegTwo = false;
                }
                NumberForBlowToTheLLeg = 0.1f;
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
                    SwichBlowToTheLLegOne = false;
                }
                NumberForBlowToTheLLeg = 0.2f;
                SwichBlowToTheLLegTwo = true;
            }
        }
    }

    public void BlowToTheRLeg()
    {
        float AttackEnemy;
        int MinNumber = 1;
        if ((int)battleScript.AttackEnemy > MinNumber)
        {
            AttackEnemy = RandomAttackEnemy.Next(MinNumber, (int)battleScript.AttackEnemy);
            if (battleScript.characteristicsEnemy.CurrentRLeg > 0) characteristicsEnemy.CurrentRLeg -= AttackEnemy;
            if (battleScript.characteristicsEnemy.CurrentRLeg < 0) characteristicsEnemy.CurrentRLeg = 0;
            if (characteristicsEnemy.CurrentRLeg < characteristicsEnemy.RLeg)
            {
                float NumberToCount = (characteristicsEnemy.RLeg / 2) / 2;
                if (characteristicsEnemy.CurrentRLeg > NumberToCount) SwitchBlowToTheRLeg(state = "Больше половины");
                if (characteristicsEnemy.CurrentRLeg <= NumberToCount &&
                    characteristicsEnemy.CurrentRLeg > 0) SwitchBlowToTheRLeg(state = "Меньше половины");
                if (characteristicsEnemy.CurrentRLeg == 0) SwitchBlowToTheRLeg(state = "Равна нулю");
                patrsBodyEnemy.SwitchToPartsBody(state, "правая нога");
                displayBattleValues.SwitchForOutputToDisplayForEnemy("состояние правой ноги", NumberForBlowToTheRLeg);
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
                    SwichBlowToTheRLegOne = false;
                }
                if (SwichBlowToTheRLegTwo == true)
                {
                    NumberForBlowToTheRLeg = 0.2f;
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
                        SwichBlowToTheRLegTwo = false;
                    }
                    NumberForBlowToTheRLeg = 0.1f;
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
                        SwichBlowToTheRLegOne = false;
                    }
                    NumberForBlowToTheRLeg = 0.2f;
                    SwichBlowToTheRLegTwo = true;
                }
            }
        }
    }
}