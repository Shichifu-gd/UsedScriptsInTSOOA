using UnityEngine.UI;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public CharacteristicsHero characteristicsHero;

    public ScObRaceHero ScObRaceHeroRu;
    public ScObHeroStory ScObHeroStoryRu;
    public ScObHeroClass ScObHeroClassRu;
    public ScObRaceHero ScObRaceHeroEn;
    public ScObHeroStory ScObHeroStoryEn;
    public ScObHeroClass ScObHeroClassEn;

    ScObRaceHero ScObRaceHero;
    ScObHeroStory ScObHeroStory;
    ScObHeroClass ScObHeroClass;

    public Attenuation attenuation;
    public GeneralSettings generalSettings;

    [HideInInspector]
    public string Name;
    string Race;
    string StoryClass;
    string Class;

    float FullHealth;
    float CurrentFullHealth;
    float MaxAttack;
    float MinAttack;
    float MaxArmor;
    float MinArmor;
    float MaxAbility;
    float MinAbility;
    float Block;
    float PotionX = 10;

    bool PrimarySwitch;
    bool boolPartZero;
    bool boolPartOne;
    bool boolPartTwo;

    string BufferTextR;
    string BufferTextSH;
    string BufferTextC;

    public GameObject partZero;
    public GameObject partOne;
    public GameObject partTwo;
    public GameObject partForText;

    public Text textFullHealth;
    public Text textMaxArmor;
    public Text textMaxAttack;
    public Text textMaxAbility;
    public Text textBlock;
    public Text textForDialogZero;
    public Text textForDialogOne;
    public Text textForDialogTwo;
    public Text textForDialogThree;

    private void Update()
    {
        textFullHealth.text = "" + FullHealth;
        textMaxArmor.text = MinArmor + "/" + MaxArmor;
        textMaxAttack.text = MinAttack + "/" + MaxAttack;
        textMaxAbility.text = MinAbility + "/" + MaxAbility;
        textBlock.text = "" + Block;
        if (PrimarySwitch == true)
        {
            attenuation.AttenuationObjectForCharacteristicsHero();
            if (partZero == true && boolPartZero == true)
            {
                if (attenuation.ColorA >= 0.98f)
                {
                    partZero.SetActive(false);
                    AssignTheValueOfRace();
                    partOne.SetActive(true);
                    PrimarySwitch = false;
                }
            }
            if (partOne == true && boolPartOne == true)
            {
                if (attenuation.ColorA >= 0.98f)
                {
                    partOne.SetActive(false);
                    AssignTheValueOfStory();
                    partTwo.SetActive(true);
                    PrimarySwitch = false;
                }
            }
            if (partTwo == true && boolPartTwo == true)
            {
                if (attenuation.ColorA >= 0.98f)
                {
                    partTwo.SetActive(false);

                    AssignTheValueOfClass();
                    partForText.SetActive(true);
                    PrimarySwitch = false;
                }
            }
        }
    }

    public void StartCharacterCustomization()
    {
        if (generalSettings.Language == "ru")
        {
            AssignListsRu();
            textForDialogZero.text = "Для регистрации в нашей гильдии вам придётся ответить на парочку вопросов. Какой вы расы?";
            textForDialogOne.text = "Расскажите о себе..";
            textForDialogTwo.text = "Какой класс вы выберите для развития?";
            textForDialogThree.text = "Ох, извини я забыла у тебя спросить как тебя зовут.";
        }
        if (generalSettings.Language == "en")
        {
            AssignListsEn();
            textForDialogZero.text = "To register in our guild, you have to answer a couple of questions. What race are you?";
            textForDialogOne.text = "Tell us about yourself..";
            textForDialogTwo.text = "Which class do you choose for development?";
            textForDialogThree.text = "Oh, sorry, I forgot to ask you what your name is.";
        }
    }

    void AssignListsRu()
    {
        ScObRaceHero = ScObRaceHeroRu;
        ScObHeroStory = ScObHeroStoryRu;
        ScObHeroClass = ScObHeroClassRu;
    }

    void AssignListsEn()
    {
        ScObRaceHero = ScObRaceHeroEn;
        ScObHeroStory = ScObHeroStoryEn;
        ScObHeroClass = ScObHeroClassEn;
    }

    public void SwitchingBetweenCustomization(string key)
    {
        if (generalSettings.Language == "ru") LanguageCCRu(key);
        if (generalSettings.Language == "en") LanguageCCEn(key);
    }

    void LanguageCCRu(string key)
    {
        if (key == "человек" ||
            key == "эльф" ||
            key == "зверолюд" ||
            key == "проклятый") ChoiceRace(key);
        if (key == "хулиган" ||
            key == "болезненный" ||
            key == "неженка") ChoiceStory(key);
        if (key == "авантюрист" ||
            key == "лучник" ||
            key == "рыцарь" ||
            key == "маг") ChoiceClass(key);
    }

    void LanguageCCEn(string key)
    {
        if (key == "human" ||
            key == "elf" ||
            key == "beastman" ||
            key == "cursed") ChoiceRace(key);
        if (key == "bully" ||
            key == "painful" ||
            key == "sissy") ChoiceStory(key);
        if (key == "adventurer" ||
            key == "archer" ||
            key == "knight" ||
            key == "magician") ChoiceClass(key);
    }

    void ChoiceRace(string CharacterCustomization)
    {
        PrimarySwitch = true;
        if (Race != "")
        {
            BufferTextR = CharacterCustomization;
            boolPartZero = true;
        }
    }

    void AssignTheValueOfRace()
    {
        for (int index = 0; index < ScObRaceHero.ListCharacteristicsRace.Count; index++)
        {
            if (BufferTextR == ScObRaceHero.ListCharacteristicsRace[index].Race.ToLower())
            {
                Race = ScObRaceHero.ListCharacteristicsRace[index].Race;
                FullHealth = ScObRaceHero.ListCharacteristicsRace[index].FullHealth;
                CurrentFullHealth = FullHealth;
                MaxAttack = ScObRaceHero.ListCharacteristicsRace[index].MaxAttack;
                MaxArmor = ScObRaceHero.ListCharacteristicsRace[index].MaxArmor;
                MaxAbility = ScObRaceHero.ListCharacteristicsRace[index].MaxAbility;
                Block = ScObRaceHero.ListCharacteristicsRace[index].Block;
                index = ScObRaceHero.ListCharacteristicsRace.Count;
            }
        }
    }

    void ChoiceStory(string CharacterCustomization)
    {
        if (Race != "")
        {
            BufferTextSH = CharacterCustomization;
            boolPartOne = true;
        }
        PrimarySwitch = true;
    }

    void AssignTheValueOfStory()
    {
        for (int index = 0; index < ScObHeroStory.ListCharacteristicsStory.Count; index++)
        {
            if (BufferTextSH == ScObHeroStory.ListCharacteristicsStory[index].StoryClass.ToLower())
            {
                StoryClass = ScObHeroStory.ListCharacteristicsStory[index].StoryClass;
                FullHealth += ScObHeroStory.ListCharacteristicsStory[index].FullHealthBonus;
                CurrentFullHealth = FullHealth;
                MaxAttack += ScObHeroStory.ListCharacteristicsStory[index].MaxAttackBonus;
                MaxArmor += ScObHeroStory.ListCharacteristicsStory[index].MaxArmorBonus;
                MaxAbility += ScObHeroStory.ListCharacteristicsStory[index].MaxAbilityBonus;
                Block += ScObHeroStory.ListCharacteristicsStory[index].BlockBonus;
                index = ScObHeroStory.ListCharacteristicsStory.Count;
            }
        }
    }

    void ChoiceClass(string CharacterCustomization)
    {
        if (StoryClass != "")
        {
            BufferTextC = CharacterCustomization;
            PrimarySwitch = true;
            boolPartTwo = true;
        }
    }

    void AssignTheValueOfClass()
    {
        for (int index = 0; index < ScObHeroClass.ListCharacteristicsClass.Count; index++)
        {
            if (BufferTextC == ScObHeroClass.ListCharacteristicsClass[index].Class.ToLower())
            {
                Class = ScObHeroClass.ListCharacteristicsClass[index].Class;
                FullHealth += ScObHeroClass.ListCharacteristicsClass[index].FullHealthBonus;
                CurrentFullHealth = FullHealth;
                MaxAttack += ScObHeroClass.ListCharacteristicsClass[index].MaxAttackBonus;
                MinAttack += ScObHeroClass.ListCharacteristicsClass[index].MinAttackBonus;
                MaxArmor += ScObHeroClass.ListCharacteristicsClass[index].MaxArmorBonus;
                MinArmor += ScObHeroClass.ListCharacteristicsClass[index].MinArmorBonus;
                MaxAbility += ScObHeroClass.ListCharacteristicsClass[index].MaxAbilityBonus;
                MinAbility += ScObHeroClass.ListCharacteristicsClass[index].MinAbilityBonus;
                Block = ScObHeroClass.ListCharacteristicsClass[index].BlockBonus;
                index = ScObHeroClass.ListCharacteristicsClass.Count;
            }
        }
    }

    public void DataTransferAndSaveData()
    {
        characteristicsHero.Name = Name;
        characteristicsHero.Race = Race;
        characteristicsHero.Class = Class;
        characteristicsHero.StoryClass = StoryClass;
        characteristicsHero.FullHealth = FullHealth;
        characteristicsHero.CurrentHealth = CurrentFullHealth;
        characteristicsHero.MaxArmor = MaxArmor;
        characteristicsHero.MinArmor = MinArmor;
        characteristicsHero.MaxAttack = MaxAttack;
        characteristicsHero.MinAttack = MinAttack;
        characteristicsHero.MaxAbility = MaxAbility;
        characteristicsHero.MinAbility = MinAbility;
        characteristicsHero.Block = Block;
        characteristicsHero.PotionX = PotionX;
        characteristicsHero.Regen = 0.5f;
        characteristicsHero.ForFirstSaveBody();
        characteristicsHero.SaveInformationsHeroes();
        characteristicsHero.SaveMaxCharacteristicsHero();
        characteristicsHero.SaveCurCharacteristicsHero();
        attenuation.TheAppearanceOfObject("Level");
    }
}