using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/Story Hero")]
public class ScObHeroStory : ScriptableObject
{
    [SerializeField] public List<CharacteristicsStory> ListCharacteristicsStory;
    [SerializeField] public CharacteristicsStory CurrentScriptableObjectsCS;

    public int currentIndex = 0;
    int CountList;

    public void ClearDatabase()
    {
        ListCharacteristicsStory.Clear();
        ListCharacteristicsStory.Add(new CharacteristicsStory());
        CurrentScriptableObjectsCS = ListCharacteristicsStory[0];
        currentIndex = 0;
    }

    public void RemoveCurrentElement()
    {
        if (currentIndex > 0)
        {
            CurrentScriptableObjectsCS = ListCharacteristicsStory[--currentIndex];
            ListCharacteristicsStory.RemoveAt(++currentIndex);
        }
        else
        {
            ListCharacteristicsStory.Clear();
            CurrentScriptableObjectsCS = null;
        }
    }

    public void AddElementToList()
    {
        if (ListCharacteristicsStory == null) ListCharacteristicsStory = new List<CharacteristicsStory>();
        CurrentScriptableObjectsCS = new CharacteristicsStory();
        ListCharacteristicsStory.Add(CurrentScriptableObjectsCS);
        currentIndex = ListCharacteristicsStory.Count - 1;
    }

    public CharacteristicsStory GetPrevValue()
    {
        if (currentIndex > 0) currentIndex--;
        CurrentScriptableObjectsCS = this[currentIndex];
        CountList = ListCharacteristicsStory.Count;
        if (currentIndex == 0) currentIndex = CountList;
        return CurrentScriptableObjectsCS;
    }

    public CharacteristicsStory GetNextValue()
    {
        if (currentIndex < ListCharacteristicsStory.Count) currentIndex++;
        CountList = ListCharacteristicsStory.Count;
        if (currentIndex == CountList) currentIndex = 0;
        CurrentScriptableObjectsCS = this[currentIndex];
        return CurrentScriptableObjectsCS;
    }

    public CharacteristicsStory this[int index]
    {
        get
        {
            if (ListCharacteristicsStory != null && index >= 0 && index < ListCharacteristicsStory.Count)
                return ListCharacteristicsStory[index];
            return null;
        }
        set
        {
            if (ListCharacteristicsStory == null) ListCharacteristicsStory = new List<CharacteristicsStory>();
            if (index >= 0 && index < ListCharacteristicsStory.Count && value != null)
                ListCharacteristicsStory[index] = value;
        }
    }
}

[System.Serializable]
public class CharacteristicsStory
{
    public string StoryClass;

    public float FullHealthBonus;
    public float MaxAttackBonus;
    public float MaxArmorBonus;
    public float MaxAbilityBonus;
    public float BlockBonus;
}