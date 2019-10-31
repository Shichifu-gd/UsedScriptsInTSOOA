using UnityEngine;

public class CharacteristicsEnemy : MonoBehaviour
{
    public BattleScript battleScript;
    public ScObEnemy scObEnemyRu;
    public ScObEnemy scObEnemyEn;
    ScObEnemy scObEnemy;

    public string NameEnemy;
    public string EnemyClass;

    public float FullHealthEnemy;
    public float MaxAttackEnemy;
    public float MaxArmorEnemy;
    public float BlockEnemy;

    [HideInInspector]
    public float Head;
    public float CurrentHead;
    [HideInInspector]
    public float Body;
    public float CurrentBody;
    [HideInInspector]
    public float LHand;
    public float CurrentLHand;
    [HideInInspector]
    public float RHand;
    public float CurrentRHand;
    [HideInInspector]
    public float LLeg;
    public float CurrentLLeg;
    [HideInInspector]
    public float RLeg;
    public float CurrentRLeg;

    int count;
    private static System.Random RandomOpponentSelection = new System.Random();

    public void ChoosingTheEnemy(string Language)
    {
        if (Language == "ru") scObEnemy = scObEnemyRu;
        else scObEnemy = scObEnemyEn;
        AssignsVariables();
    }

    void AssignsVariables()
    {
        count = RandomOpponentSelection.Next(0, scObEnemy.EnemyList.Count);
        NameEnemy = scObEnemy.EnemyList[count].NameEnemy;
        FullHealthEnemy = scObEnemy.EnemyList[count].FullHealth;
        MaxAttackEnemy = scObEnemy.EnemyList[count].MaxAttack;
        MaxArmorEnemy = scObEnemy.EnemyList[count].MaxArmor;
        BlockEnemy = scObEnemy.EnemyList[count].Block;
        Head = scObEnemy.EnemyList[count].Head;
        CurrentHead = Head;
        Body = scObEnemy.EnemyList[count].Body;
        CurrentBody = Body;
        LHand = scObEnemy.EnemyList[count].LHand;
        CurrentLHand = LHand;
        RHand = scObEnemy.EnemyList[count].RHand;
        CurrentRHand = RHand;
        LLeg = scObEnemy.EnemyList[count].LLeg;
        CurrentLLeg = LLeg;
        RLeg = scObEnemy.EnemyList[count].RLeg;
        CurrentRLeg = RLeg;
    }

    public void ChoosingTheEnemyBoss(string Language)
    {
        if (Language == "ru") scObEnemy = scObEnemyRu;
        else scObEnemy = scObEnemyEn;
        AssignsVariablesBoss();
    }

    void AssignsVariablesBoss()
    {
        count = RandomOpponentSelection.Next(0, scObEnemy.EnemyList.Count);
        NameEnemy = scObEnemy.EnemyList[count].NameEnemy;
        EnemyClass = scObEnemy.EnemyList[count].Class;
        FullHealthEnemy = scObEnemy.EnemyList[count].FullHealth;
        MaxAttackEnemy = scObEnemy.EnemyList[count].MaxAttack;
        MaxArmorEnemy = scObEnemy.EnemyList[count].MaxArmor;
        BlockEnemy = scObEnemy.EnemyList[count].Block;
        Head = scObEnemy.EnemyList[count].Head;
        CurrentHead = Head;
        Body = scObEnemy.EnemyList[count].Body;
        CurrentBody = Body;
        LHand = scObEnemy.EnemyList[count].LHand;
        CurrentLHand = LHand;
        RHand = scObEnemy.EnemyList[count].RHand;
        CurrentRHand = RHand;
        LLeg = scObEnemy.EnemyList[count].LLeg;
        CurrentLLeg = LLeg;
        RLeg = scObEnemy.EnemyList[count].RLeg;
        CurrentRLeg = RLeg;
    }
}