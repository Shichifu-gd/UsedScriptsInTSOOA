using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/Enemy")]
public class ScObEnemy : ScriptableObject
{
    [SerializeField] public List<ScObCharacteristicsEnemy> EnemyList;
    [SerializeField] public ScObCharacteristicsEnemy CurrentScriptableObjects;

    public int currentIndex = 0;
    int CountList;

    public void ClearDatabase()
    {
        EnemyList.Clear();
        EnemyList.Add(new ScObCharacteristicsEnemy());
        CurrentScriptableObjects = EnemyList[0];
        currentIndex = 0;
    }

    public void RemoveCurrentElement()
    {
        if (currentIndex > 0)
        {
            CurrentScriptableObjects = EnemyList[--currentIndex];
            EnemyList.RemoveAt(++currentIndex);
        }
        else
        {
            EnemyList.Clear();
            CurrentScriptableObjects = null;
        }
    }

    public void AddElementToList()
    {
        if (EnemyList == null) EnemyList = new List<ScObCharacteristicsEnemy>();
        CurrentScriptableObjects = new ScObCharacteristicsEnemy();
        EnemyList.Add(CurrentScriptableObjects);
        currentIndex = EnemyList.Count - 1;
    }

    public ScObCharacteristicsEnemy GetPrevValue()
    {
        if (currentIndex > 0) currentIndex--;
        CurrentScriptableObjects = this[currentIndex];
        CountList = EnemyList.Count;
        if (currentIndex == 0) currentIndex = CountList;
        return CurrentScriptableObjects;
    }

    public ScObCharacteristicsEnemy GetNextValue()
    {
        if (currentIndex < EnemyList.Count) currentIndex++;
        CountList = EnemyList.Count;
        if (currentIndex == CountList) currentIndex = 0;
        CurrentScriptableObjects = this[currentIndex];
        return CurrentScriptableObjects;
    }

    public ScObCharacteristicsEnemy this[int index]
    {
        get
        {
            if (EnemyList != null && index >= 0 && index < EnemyList.Count)
                return EnemyList[index];
            return null;
        }
        set
        {
            if (EnemyList == null) EnemyList = new List<ScObCharacteristicsEnemy>();
            if (index >= 0 && index < EnemyList.Count && value != null)
                EnemyList[index] = value;
        }
    }
}

[System.Serializable]
public class ScObCharacteristicsEnemy
{
    public string NameEnemy;
    public string Class;

    public float FullHealth;
    public float MaxAttack;
    public float MaxArmor;
    public float Block;
    public float Head;
    public float Body;
    public float LHand;
    public float RHand;
    public float LLeg;
    public float RLeg;

    [TextArea] public string DescriptionWeaknessesPartOne;
    [TextArea] public string DescriptionWeaknessesPartTwo;
    [TextArea] public string DescriptionWeaknessesPartThree;
}