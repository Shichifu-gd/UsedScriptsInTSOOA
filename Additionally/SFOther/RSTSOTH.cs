using System.Collections.Generic;
using UnityEngine;

public class RSTSOTH : MonoBehaviour
{
    public BattleScript battleScript;

    public float FullHealthHero;
    public float CurrentHealthHero;
    public float MaxAttackHero;
    public float MinAttackHero;
    public float MaxArmorHero;
    public float MinArmorHero;
    public float MaxAbilityHero;
    public float MinAbilityHero;
    public float BlockHero;

    public string NameRace;
    public string NameStoryClass;
    public string NmaeClass;

    public List<ScObRaceHero> Race;
    public List<ScObHeroStory> Story;
    public List<ScObHeroClass> Class;

    int count;
    private static System.Random RandomHeroSelection = new System.Random();
    int countOne;
    private static System.Random RandomHeroSelectionOne = new System.Random();
    int countTwo;
    private static System.Random RandomHeroSelectionTwo = new System.Random();

    private void StartOFF()
    {
        count = Race.Count;
        count = RandomHeroSelection.Next(0, count);
        countOne = Story.Count;
        countOne = RandomHeroSelectionOne.Next(0, countOne);
        countTwo = Class.Count;
        countTwo = RandomHeroSelectionTwo.Next(0, countTwo);
        ForHero();
    }

    void ForHero()
    {
        battleScript.FullHealthHero = FullHealthHero;
        battleScript.CurrentHealthHero = FullHealthHero;
        battleScript.MaxAttackHero = MaxAttackHero;
        battleScript.MinAttackHero = MinAttackHero;
        battleScript.MaxArmorHero = MaxArmorHero;
        battleScript.MinArmorHero = MinArmorHero;
        battleScript.MaxAbilityHero = MaxAbilityHero;
        battleScript.MinAbilityHero = MinAbilityHero;
        battleScript.BlockHero = BlockHero;
    }
}