using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadLanguage : MonoBehaviour
{
    public static void SaveLanguage(GeneralSettings generalSettings)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/Language.sav", FileMode.Create);
        DataLanguage data = new DataLanguage(generalSettings);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadLanguage()
    {
        if (File.Exists(Application.dataPath + "/data/Language.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/Language.sav", FileMode.Open);
            DataLanguage data = bf.Deserialize(stream) as DataLanguage;
            stream.Close();
            return data.Language;
        }
        else return new string[0];
    }

    public static void SaveIndexForUO(CharacteristicsHero characteristicsHero)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/ii.sav", FileMode.Create);
        DataIndexForUO data = new DataIndexForUO(characteristicsHero);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadIndexForUO()
    {
        if (File.Exists(Application.dataPath + "/data/ii.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/ii.sav", FileMode.Open);
            DataIndexForUO data = bf.Deserialize(stream) as DataIndexForUO;
            stream.Close();
            return data.indexForUO;
        }
        else return new int[0];
    }
}

[Serializable]
public class DataLanguage
{
    public string[] Language;
    public DataLanguage(GeneralSettings generalSettings)
    {
        Language = new string[1];
        Language[0] = generalSettings.Language;
    }
}

[Serializable]
public class DataIndexForUO
{
    public int[] indexForUO;
    public DataIndexForUO(CharacteristicsHero characteristicsHero)
    {
        indexForUO = new int[1];
        indexForUO[0] = characteristicsHero.IndexForUO;
    }
}