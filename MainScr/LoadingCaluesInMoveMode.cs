using UnityEngine;
using UnityEngine.UI;

public class LoadingCaluesInMoveMode : MonoBehaviour
{
    public Text MinAndMaxHealthHero;
    public Text MinAndMaxAttackHero;
    public Text MinAndMaxAbilityHero;
    public Text MinAndMaxArmorHero;
    public Text MinAndMaxBlockHero;
    public Text BuffAndDebuffForAttack;
    public Text BuffAndDebuffForAbility;
    public Text BuffAndDebuffForArmor;
    public Text BuffAndDebuffForBlock;

    float LeftHand;
    float RightHand;

    public CharacteristicsHero characteristicsHero;
    public SupplementForHeroBody supplementForHeroBody;

    public void SwitchForOutputToDisplayToLoad(string InformationForSwitchForOutputToDisplay, float Bonus)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние головы") OutputToDisplayBuffAndDebuffAbility(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние тела") OutputToDisplayBuffAndDebuffArmor(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки") AssigningValuesLHand(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки") AssigningValuesRHand(Bonus);
    }

    public void SwitchForOutputToDisplay(string InformationForSwitchForOutputToDisplay, float Bonus)
    {
        if (InformationForSwitchForOutputToDisplay == "состояние головы") OutputToDisplayBuffAndDebuffAbility(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние тела") OutputToDisplayBuffAndDebuffArmor(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние левой руки") AssigningValuesLHand(Bonus);
        if (InformationForSwitchForOutputToDisplay == "состояние правой руки") AssigningValuesRHand(Bonus);
    }

    void OutputToDisplayBuffAndDebuffAbility(float Bonus)
    {
        float TemporaryVariable = Bonus;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (Bonus > 0) NegativeAandPositive = "+";
        if (Bonus < 1) NegativeAandPositive = "-";
        if (Bonus == 0) NegativeAandPositive = "";

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
        float TemporaryVariable = Bonus;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (Bonus > 0) NegativeAandPositive = "+";
        if (Bonus < 1) NegativeAandPositive = "-";
        if (Bonus == 0) NegativeAandPositive = "";
        BuffAndDebuffForAttack.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void OutputToDisplayBuffAndDebuffArmor(float Bonus)
    {
        float TemporaryVariable = Bonus;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (Bonus > 0) NegativeAandPositive = "+";
        if (Bonus < 1) NegativeAandPositive = "-";
        if (Bonus == 0) NegativeAandPositive = "";
        BuffAndDebuffForArmor.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }

    void OutputToDisplayBuffAndDebuffBlock(float Bonus)
    {
        float TemporaryVariable = Bonus;
        if (TemporaryVariable < 0) TemporaryVariable = Mathf.Abs(TemporaryVariable);
        string NegativeAandPositive = "";
        if (Bonus > 1) NegativeAandPositive = "+";
        if (Bonus < 1) NegativeAandPositive = "-";
        if (Bonus == 0) NegativeAandPositive = "";
        BuffAndDebuffForBlock.text = NegativeAandPositive + "(" + TemporaryVariable + ")";
    }
}