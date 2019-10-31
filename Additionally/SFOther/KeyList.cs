using UnityEngine;
using UnityEngine.UI;

public class KeyList : MonoBehaviour
{
    public Text keyAttack;
    public Text keyBlock;
    public Text keyAbility;
    public Text keyArcher;
    public Text DrinkPotions;
    public Text UseAltar;
    public Text ToRelax;
    public Text PlayerName;
    public Text UseInteracting;
    public Text TakeInteracting;
    public Text ExaminInteracting;
    public Text RaceChoice;
    public Text ChildhoodChoice;
    public Text ClassSelection;
    public Text goOne;
    public Text goTwo; 
    public Text descent;
    public Text NewGame;
    public Text Setting;
    public Text LoadGame;
    public Text Exit;
    public Text Resolution;
    public Text MainMenu;
    public Text saud;
    public Text FullScreen;
    public Text LanguageRu;
    public Text LanguageEn;
    public Text MainMenuText;
    public Text SettingText;
    public Text BattleText;
    public Text WhenChoosingACharacter;
    public Text TravelBattle;
    public Text TravelText;
    public Text Back;
    public Text TextZ;
    public Text TextO;
    public Text TextT;
    public Text TextTr;
    public Text TextF;
    public Text TextS;
    public Text TextInf;

    public GeneralSettings generalSettings;

    public void RuKey()
    {
        RaceChoice.text = "Я [раса]";
        ChildhoodChoice.text = "Я [детство]";
        ClassSelection.text = "Я [класс]";
        keyAttack.text = "ударить мечом";
        keyBlock.text = "поставить блок";
        keyAbility.text = "воспользоваться магией";
        keyArcher.text = "натянуть тетиву";
        UseAltar.text = "активировать алтарь";
        DrinkPotions.text = "выпить зелье";
        UseInteracting.text = "использовать [предмет]";
        TakeInteracting.text = "взять [предмет]";
        ExaminInteracting.text = "изучить [предмет]";
        ToRelax.text = "";
        PlayerName.text = "меня зовут [имя]";
        goOne.text = "идти на север";
        goTwo.text = "войти в подземелье";
        NewGame.text = "новая игра";
        Setting.text = "настройки";
        LoadGame.text = "загрузить";
        descent.text = "спустится вниз";
        Exit.text = "выйти";
        Resolution.text = "разрешение [ш]/[в]";
        FullScreen.text = "пэр [вкл]или[выкл]";
        MainMenu.text = "главное меню";
        Back.text = "назад";
        LanguageRu.text = "русский язык";
        LanguageEn.text = "english language";
        TextZ.text = "Я [существительное] - Я гном";
        TextO.text = "[ш]/[в] - 1980/1080";
        saud.text = "громкость звука [число]";
        TextT.text = "[сторона] - север,юг, восток, запад";
        TextS.text = "[предмет] использовать [рычаг]";
        TextTr.text = "Для выхода введите 'инф'";
        TextF.text = "число от [0] до [10]";
        MainMenuText.text = "Главное меню:";
        SettingText.text = "Настройки:";
        BattleText.text = "Бой:";
        WhenChoosingACharacter.text = "При выборе персонажа:";
        TravelBattle.text = "Путеществие/бой:";
        TravelText.text = "Путеществие:";
        TextInf.text = "Информация:";
    }

    public void EnKey()
    {
        RaceChoice.text = "I am [race]";
        ChildhoodChoice.text = "I am [childhood]";
        ClassSelection.text = "I am [class]";
        keyAttack.text = "sword attack";
        keyBlock.text = "put block";
        keyAbility.text = "attack with magic";
        keyArcher.text = "pull the bow";
        UseAltar.text = "activate the altar";
        DrinkPotions.text = "drink a potion";
        UseInteracting.text = "use [item]";
        TakeInteracting.text = "take [item]";
        ExaminInteracting.text = "study [subject]";
        ToRelax.text = "";
        PlayerName.text = "my name [name]";
        goOne.text = "go to [side]";
        goTwo.text = "enter the dungeon";
        NewGame.text = "new game";
        Setting.text = "settings";
        LoadGame.text = "loading";
        descent.text = "will go down";
        Exit.text = "go out";
        Resolution.text = "resolution [w]/[h]";
        saud.text = "sound volume [number]";
        FullScreen.text = "fsm [on] or [off]";
        MainMenu.text = "main menu";
        Back.text = "back";
        LanguageRu.text = "русский язык";
        LanguageEn.text = "english language";
        TextZ.text = "I [noun] - I am a gnome";
        TextO.text = "[w]/[h] - 1980/1080";
        TextT.text = "[side] - north, south, east, west";
        TextS.text = "[item] use [lever] ";
        TextTr.text = "To exit, enter 'inf'";
        TextF.text = "number from [0] to [10]";
        MainMenuText.text = "Main menu:";
        SettingText.text = "Settings:";
        BattleText.text = "The battle:";
        WhenChoosingACharacter.text = "When choosing a character:";
        TravelBattle.text = "Travel/battle:";
        TravelText.text = "Travel:";
        TextInf.text = "Information:";
    }
}