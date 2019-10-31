using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/Class Hero")]
public class ScObHeroClass : ScriptableObject
{
    [SerializeField] public List<CharacteristicsClass> ListCharacteristicsClass;
    [SerializeField] public CharacteristicsClass CurrentScriptableObjectsCC;
    public int currentIndex = 0;
    int CountList;

    public void ClearDatabase()
    {
        ListCharacteristicsClass.Clear();
        ListCharacteristicsClass.Add(new CharacteristicsClass());
        CurrentScriptableObjectsCC = ListCharacteristicsClass[0];
        currentIndex = 0;
    }

    public void RemoveCurrentElement()
    {
        if (currentIndex > 0)
        {
            CurrentScriptableObjectsCC = ListCharacteristicsClass[--currentIndex];
            ListCharacteristicsClass.RemoveAt(++currentIndex);
        }
        else
        {
            ListCharacteristicsClass.Clear();
            CurrentScriptableObjectsCC = null;
        }
    }

    public void AddElementToList()
    {
        if (ListCharacteristicsClass == null) ListCharacteristicsClass = new List<CharacteristicsClass>();
        CurrentScriptableObjectsCC = new CharacteristicsClass();
        ListCharacteristicsClass.Add(CurrentScriptableObjectsCC);
        currentIndex = ListCharacteristicsClass.Count - 1;
    }

    public CharacteristicsClass GetPrevValue()
    {
        if (currentIndex > 0) currentIndex--;
        CurrentScriptableObjectsCC = this[currentIndex];
        CountList = ListCharacteristicsClass.Count;
        if (currentIndex == 0) currentIndex = CountList;
        return CurrentScriptableObjectsCC;
    }

    public CharacteristicsClass GetNextValue()
    {
        if (currentIndex < ListCharacteristicsClass.Count) currentIndex++;
        CountList = ListCharacteristicsClass.Count;
        if (currentIndex == CountList) currentIndex = 0;
        CurrentScriptableObjectsCC = this[currentIndex];
        return CurrentScriptableObjectsCC;
    }

    public CharacteristicsClass this[int index]
    {
        get
        {
            if (ListCharacteristicsClass != null && index >= 0 && index < ListCharacteristicsClass.Count)
                return ListCharacteristicsClass[index];
            return null;
        }
        set
        {
            if (ListCharacteristicsClass == null) ListCharacteristicsClass = new List<CharacteristicsClass>();
            if (index >= 0 && index < ListCharacteristicsClass.Count && value != null)
                ListCharacteristicsClass[index] = value;
        }
    }
}

[System.Serializable]
public class CharacteristicsClass
{ 
    public string Class;
    [TextArea] public string HeroWeapon;

    public float FullHealthBonus;
    public float MaxAttackBonus;
    public float MinAttackBonus;
    public float MaxArmorBonus;
    public float MinArmorBonus;
    public float MaxAbilityBonus;
    public float MinAbilityBonus;
    public float BlockBonus;
}
