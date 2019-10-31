using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Menu : MonoBehaviour
{
    public Text FirstLine;
    public Text SecondLine;
    public Text ThirdLine;
    public Text FourthLine;

    public Text resolution;
    public Text volume;
    public Text TrueAndFalse;

    public AudioManager audioManager;
    public Attenuation attenuation;
    public GeneralSettings generalSettings;
    public Cleaning cleaning;

    string VolumeMixer;
    string ActionPoint;

    public bool SwitchFSG;

    public void StartMenu()
    {
        if (SwitchFSG == false)
        {
            if (!File.Exists(Application.dataPath + "/data/Language.sav") && FirstLine == true)
            {
                Directory.CreateDirectory(Application.dataPath + "/data");
                SceneManager.LoadSceneAsync("SG");
            }
            ActionPoint = "Главное меню";
            TransitionsToTheMenu();
            Cursor.visible = false;
        }
    }

    public void AcceptsAndRedirects(string Key, string KeyOne, string KeyTwo)
    {
        if (Key == "тсл") attenuation.TheAppearanceOfObject("Level");
        if (Key == "новая" && KeyOne == "игра" || Key == "new" && KeyOne == "game") AcceptsAKeyForStart();
        if (Key == "загрузить" || Key == "loading") AcceptsAKeyForLoad();
        if (Key == "настройки" || Key == "settings")
        {
            ActionPoint = "Настройки";
            TransitionsToTheMenu();
        }
        if (Key == "назад" || Key == "back")
        {
            ActionPoint = "Главное меню";
            TransitionsToTheMenu();
        }
    }

    void AcceptsAKeyForStart()
    {
        cleaning.CleanAllSave();
        attenuation.TheAppearanceOfObject("Hero selection");
    }

    void AcceptsAKeyForLoad()
    {
        if (File.Exists(Application.dataPath + "/data/path.sav"))
        {
            if (cleaning.characteristicsHero.Name != "Лисенок убрался") attenuation.TheAppearanceOfObject("Level");
            else attenuation.TheAppearanceOfObject("Hero selection");
        }
        else attenuation.TheAppearanceOfObject("Hero selection");
    }

    void TransitionsToTheMenu()
    {
        if (generalSettings.Language == "ru")
        {
            if (ActionPoint == "Настройки")
            {
                OutputVolume();
                FirstLine.text = "Разришение экрана";
                resolution.text = "(1980x1080, 1600x900, 1280x720)";
                SecondLine.text = "Громкость звука";
                volume.text = "(" + VolumeMixer + ")";
                ThirdLine.text = "Полноэкранный режим";
                TrueAndFalse.text = "(вкл/выкл)";
                FourthLine.text = "Назад";
            }
            if (ActionPoint == "Главное меню" || ActionPoint == "")
            {
                FirstLine.text = "Новая игра";
                SecondLine.text = "загрузить";
                ThirdLine.text = "Настройки";
                FourthLine.text = "Выйти";
                resolution.text = "";
                volume.text = "";
                TrueAndFalse.text = "";
            }
        }
        if (generalSettings.Language == "en")
        {
            if (ActionPoint == "Настройки")
            {
                OutputVolume();
                FirstLine.text = "Screen resolution";
                resolution.text = "(1980x1080, 1600x900, 1280x720)";
                SecondLine.text = "Sound volume";
                volume.text = "(" + VolumeMixer + ")";
                ThirdLine.text = "Full screen mode";
                TrueAndFalse.text = "(on/off)";
                FourthLine.text = "Back";
            }
            if (ActionPoint == "Главное меню" || ActionPoint == "")
            {
                FirstLine.text = "New game";
                SecondLine.text = "Loading";
                ThirdLine.text = "Settings";
                FourthLine.text = "Exit";
                resolution.text = "";
                volume.text = "";
                TrueAndFalse.text = "";
            }
        }
    }

    void OutputVolume()
    {
        int num = (int)audioManager.ValueMixer;
        num = (num / 8 + 10) * 10;
        if (num == 10) num = 100;
        VolumeMixer = num.ToString();
    }  

    public void AcceptsAndRedirectsForSettingsR(string key, string keyOne, string KeyTwo)
    {
        if (ActionPoint == "Настройки")
        {
            if (key == "разришение" && KeyTwo == "1980/1080") ScreenResolution(0);
            if (key == "разришение" && KeyTwo == "1600/900") ScreenResolution(1);
            if (key == "разришение" && KeyTwo == "1280/720") ScreenResolution(2);
            if (keyOne == "resolution" && KeyTwo == "1980/1080") ScreenResolution(0);
            if (keyOne == "resolution" && KeyTwo == "1600/900") ScreenResolution(1);
            if (keyOne == "resolution" && KeyTwo == "1280/720") ScreenResolution(2);
        }
    }

    void ScreenResolution(int index)
    {
        if (index == 0) Screen.SetResolution(1920, 1080, Screen.fullScreen);
        if (index == 1) Screen.SetResolution(1600, 900, Screen.fullScreen);
        if (index == 2) Screen.SetResolution(1280, 720, Screen.fullScreen);
    }

    public void AcceptsAndRedirectsForSettingsFS(string key, string keyOne)
    {
        if (ActionPoint == "Настройки")
        {
            if (key == "пэр" && keyOne == "вкл") Screen.fullScreen = true;
            if (key == "пэр" && keyOne == "выкл") Screen.fullScreen = false;
            if (key == "fsm" && keyOne == "on") Screen.fullScreen = true;
            if (key == "fsm" && keyOne == "off") Screen.fullScreen = false;
        }
    }

    public void Language(string key, string keyOne)
    {
        if (key == "english" && keyOne == "language") SaveLanguage("en");
        if (key == "русский" && keyOne == "язык") SaveLanguage("ru");
        if (SwitchFSG == false) TransitionsToTheMenu();       
        else attenuation.TheAppearanceOfObject("ASG");
    }

    void SaveLanguage(string Language)
    {
        generalSettings.Language = Language;
        generalSettings.SaveLanguage();
    }

    public void SettingSoundVolume(string KeyTwo)
    {
        float SoundVolume = 0;
        if (float.TryParse(KeyTwo, out SoundVolume))
        {
            if (SoundVolume > 10) SoundVolume = 10;
            if (SoundVolume < 0) SoundVolume = 0;
            SoundVolume = (SoundVolume - 10) * 8;
        }
        audioManager.ChangesTheSoundVolume(SoundVolume);
        audioManager.SaveValueMixer();
        TransitionsToTheMenu();
    }
}