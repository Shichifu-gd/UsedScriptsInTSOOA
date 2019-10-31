using UnityEngine.UI;
using UnityEngine;

public class PanelHero : MonoBehaviour
{
    public GeneralSettings generalSettings;

    public ScObRaceHero ScObRaceHeroRu;
    public ScObHeroStory ScObHeroStoryRu;
    public ScObHeroClass ScObHeroClassRu;
    public ScObRaceHero ScObRaceHeroEn;
    public ScObHeroStory ScObHeroStoryEn;
    public ScObHeroClass ScObHeroClassEn;

    public Text TextName;
    public Text TextHealth;
    public Text TextAttack;
    public Text TextArmor;
    public Text TextAbility;
    public Text TextBlock;
    public Text NumberTextHealth;
    public Text NumberTextAttack;
    public Text NumberTextArmor;
    public Text NumberTextAbility;
    public Text NumberTextBlock;

    ScObRaceHero ScObRaceHero;
    ScObHeroStory ScObHeroStory;
    ScObHeroClass ScObHeroClass;

    public bool ForStartPH;

    public void Update()
    {
        if (ForStartPH == true) LanguageText();
    }

    void LanguageText()
    {
        if (generalSettings.Language == "ru")
        {
            TextHealth.text = "Здоровье";
            TextAttack.text = "Атака";
            TextAbility.text = "Магия";
            TextArmor.text = "Защита";
            TextBlock.text = "Блок";
            SORu();
        }
        if (generalSettings.Language == "en")
        {
            TextHealth.text = "Health";
            TextAttack.text = "Attack";
            TextAbility.text = "Ability";
            TextArmor.text = "Armor";
            TextBlock.text = "Block";
            SOEn();
        }
    }

    void SORu()
    {
        if (ScObRaceHeroRu)
        {
            ScObRaceHero = ScObRaceHeroRu;
            RaceHero();
        }
        if (ScObHeroStoryRu)
        {
            ScObHeroStory = ScObHeroStoryRu;
            HeroStory();
        }
        if (ScObHeroClassRu)
        {
            ScObHeroClass = ScObHeroClassRu;
            HeroClass();
        }
        ForStartPH = false;
    }

    void SOEn()
    {
        if (ScObRaceHeroEn)
        {
            ScObRaceHero = ScObRaceHeroEn;
            RaceHero();
        }
        if (ScObHeroStoryEn)
        {
            ScObHeroStory = ScObHeroStoryEn;
            HeroStory();
        }
        if (ScObHeroClassEn)
        {
            ScObHeroClass = ScObHeroClassEn;
            HeroClass();
        }
        ForStartPH = false;
    }

    void RaceHero()
    {
        for (int index = 0; index < ScObRaceHeroRu.ListCharacteristicsRace.Count; index++)
        {
            if (TextName.text == ScObRaceHeroRu.ListCharacteristicsRace[index].Race)
            {
                TextName.text = ScObRaceHero.ListCharacteristicsRace[index].Race;
                NumberTextHealth.text = ScObRaceHero.ListCharacteristicsRace[index].FullHealth.ToString() + "/" + ScObRaceHero.ListCharacteristicsRace[index].FullHealth.ToString();
                NumberTextAbility.text = ScObRaceHero.ListCharacteristicsRace[index].MaxAbility.ToString();
                NumberTextAttack.text = ScObRaceHero.ListCharacteristicsRace[index].MaxAttack.ToString();
                NumberTextArmor.text = ScObRaceHero.ListCharacteristicsRace[index].MaxArmor.ToString();
                NumberTextBlock.text = ScObRaceHero.ListCharacteristicsRace[index].Block.ToString();
                index = ScObRaceHero.ListCharacteristicsRace.Count;
            }
        }
    }

    void HeroStory()
    {
        for (int index = 0; index < ScObHeroStoryRu.ListCharacteristicsStory.Count; index++)
        {
            if (TextName.text == ScObHeroStoryRu.ListCharacteristicsStory[index].StoryClass)
            {
                TextName.text = ScObHeroStory.ListCharacteristicsStory[index].StoryClass;
                NumberTextHealth.text = ScObHeroStory.ListCharacteristicsStory[index].FullHealthBonus.ToString();
                NumberTextAbility.text = ScObHeroStory.ListCharacteristicsStory[index].MaxAbilityBonus.ToString();
                NumberTextAttack.text = ScObHeroStory.ListCharacteristicsStory[index].MaxAttackBonus.ToString();
                NumberTextArmor.text = ScObHeroStory.ListCharacteristicsStory[index].MaxArmorBonus.ToString();
                NumberTextBlock.text = ScObHeroStory.ListCharacteristicsStory[index].BlockBonus.ToString();
                index = ScObHeroStory.ListCharacteristicsStory.Count;
            }
        }
    }

    void HeroClass()
    {
        for (int index = 0; index < ScObHeroClassRu.ListCharacteristicsClass.Count; index++)
        {
            if (TextName.text == ScObHeroClassRu.ListCharacteristicsClass[index].Class)
            {
                TextName.text = ScObHeroClass.ListCharacteristicsClass[index].Class;
                NumberTextHealth.text = ScObHeroClass.ListCharacteristicsClass[index].FullHealthBonus.ToString();
                NumberTextAbility.text = ScObHeroClass.ListCharacteristicsClass[index].MaxAbilityBonus.ToString();
                NumberTextAttack.text = ScObHeroClass.ListCharacteristicsClass[index].MaxAttackBonus.ToString();
                NumberTextArmor.text = ScObHeroClass.ListCharacteristicsClass[index].MaxArmorBonus.ToString();
                NumberTextBlock.text = ScObHeroClass.ListCharacteristicsClass[index].BlockBonus.ToString();
                index = ScObHeroClass.ListCharacteristicsClass.Count;
            }
        }
    }
}