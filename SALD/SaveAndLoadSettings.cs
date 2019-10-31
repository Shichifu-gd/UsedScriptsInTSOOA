using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadSettings : MonoBehaviour
{
    public static void SaveLocalizationTheGame(GeneralSettings generalSettings)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/.sav", FileMode.Create);
        LocalizationTheGame data = new LocalizationTheGame(generalSettings);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadLocalizationTheGame()
    {
        if (File.Exists(Application.dataPath + "/data/.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/.sav", FileMode.Open);
            LocalizationTheGame data = bf.Deserialize(stream) as LocalizationTheGame;
            stream.Close();
            return data.Language;
        }
        else return new string[0];
    }
}

[Serializable]
public class LocalizationTheGame
{
    public string[] Language;
    public LocalizationTheGame(GeneralSettings generalSettings)
    {
        Language = new string[1];
        Language[0] = generalSettings.Language;
    }
}