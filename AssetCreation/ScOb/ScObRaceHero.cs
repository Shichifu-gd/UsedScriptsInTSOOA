using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/Race Hero")]
public class ScObRaceHero : ScriptableObject
{
    [SerializeField] public List<CharacteristicsRace> ListCharacteristicsRace;
    [SerializeField] public CharacteristicsRace CurrentScriptableObjectsCR;

    public int currentIndex = 0;
    int CountList;

    public void ClearDatabase()
    {
        ListCharacteristicsRace.Clear();
        ListCharacteristicsRace.Add(new CharacteristicsRace());
        CurrentScriptableObjectsCR = ListCharacteristicsRace[0];
        currentIndex = 0;
    }

    public void RemoveCurrentElement()
    {
        if (currentIndex > 0)
        {
            CurrentScriptableObjectsCR = ListCharacteristicsRace[--currentIndex];
            ListCharacteristicsRace.RemoveAt(++currentIndex);
        }
        else
        {
            ListCharacteristicsRace.Clear();
            CurrentScriptableObjectsCR = null;
        }
    }

    public void AddElementToList()
    {
        if (ListCharacteristicsRace == null) ListCharacteristicsRace = new List<CharacteristicsRace>();
        CurrentScriptableObjectsCR = new CharacteristicsRace();
        ListCharacteristicsRace.Add(CurrentScriptableObjectsCR);
        currentIndex = ListCharacteristicsRace.Count - 1;
    }

    public CharacteristicsRace GetPrevValue()
    {
        if (currentIndex > 0) currentIndex--;
        CurrentScriptableObjectsCR = this[currentIndex];
        CountList = ListCharacteristicsRace.Count;
        if (currentIndex == 0) currentIndex = CountList;
        return CurrentScriptableObjectsCR;
    }

    public CharacteristicsRace GetNextValue()
    {
        if (currentIndex < ListCharacteristicsRace.Count) currentIndex++;
        CountList = ListCharacteristicsRace.Count;
        if (currentIndex == CountList) currentIndex = 0;
        CurrentScriptableObjectsCR = this[currentIndex];
        return CurrentScriptableObjectsCR;
    }

    public CharacteristicsRace this[int index]
    {
        get
        {
            if (ListCharacteristicsRace != null && index >= 0 && index < ListCharacteristicsRace.Count)
                return ListCharacteristicsRace[index];
            return null;
        }
        set
        {
            if (ListCharacteristicsRace == null) ListCharacteristicsRace = new List<CharacteristicsRace>();
            if (index >= 0 && index < ListCharacteristicsRace.Count && value != null)
                ListCharacteristicsRace[index] = value;
        }
    }
}

[System.Serializable]
public class CharacteristicsRace
{ 
    public string Race;
    public float FullHealth;
    public float MaxAttack;
    public float MaxArmor;
    public float MaxAbility;
    public float Block;    
}