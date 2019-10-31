using UnityEngine;
using System.IO;

public class GeneralSettings : MonoBehaviour
{
    public string Language;

    public ObjectsAffectingCharacteristic DummyForListAltars;
    public InteractableObject DummyForListUO;
    public CharacterCustomization characterCustomization;

    public void StartGeneralSettings()
    {
        if (File.Exists(Application.dataPath + "/data/Language.sav")) LoadLanguage();
        else Language = "ru";
        if (characterCustomization) characterCustomization.StartCharacterCustomization();
    }

    void LoadLanguage()
    {
        string[] loadLanguage = SaveAndLoadLanguage.LoadLanguage();
        Language = loadLanguage[0];
    }

    public void SaveLanguage()
    {
        SaveAndLoadLanguage.SaveLanguage(this);
    }
}