using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadInventory : MonoBehaviour
{
    public static void SaveDataToInventoryAltar(CharacteristicsHero characteristicsHero)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/InvAL.sav", FileMode.Create);
        DataToInventoryAltar data = new DataToInventoryAltar(characteristicsHero);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadDataToInventoryAltar()
    {
        if (File.Exists(Application.dataPath + "/data/InvAL.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/InvAL.sav", FileMode.Open);
            DataToInventoryAltar data = bf.Deserialize(stream) as DataToInventoryAltar;
            stream.Close();
            return data.Altar;
        }
        else return new string[0];
    }

    public static void SaveUnlockingObjects(CharacteristicsHero characteristicsHero)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/InvUO.sav", FileMode.Create);
        DataToUnlockingObjects data = new DataToUnlockingObjects(characteristicsHero);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadUnlockingObjects()
    {
        if (File.Exists(Application.dataPath + "/data/InvUO.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/InvUO.sav", FileMode.Open);
            DataToUnlockingObjects data = bf.Deserialize(stream) as DataToUnlockingObjects;
            stream.Close();
            return data.UnlockingObjects;
        }
        else return new string[0];
    }

    public static void SaveTTWU(CharacteristicsHero characteristicsHero)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/TTWU.sav", FileMode.Create);
        DataToThingsThatWereUsed data = new DataToThingsThatWereUsed(characteristicsHero);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadTTWU()
    {
        if (File.Exists(Application.dataPath + "/data/TTWU.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/TTWU.sav", FileMode.Open);
            DataToThingsThatWereUsed data = bf.Deserialize(stream) as DataToThingsThatWereUsed;
            stream.Close();
            return data.TTWU;
        }
        else return new string[0];
    }
}

[Serializable]
public class DataToInventoryAltar
{
    public string[] Altar;
    public DataToInventoryAltar(CharacteristicsHero characteristicsHero)
    {
        Altar = new string[2];
        Altar[0] = characteristicsHero.SlotsActivatedAltars[0].name;
        Altar[1] = characteristicsHero.SlotsActivatedAltars[1].name;
    }
}

[Serializable]
public class DataToUnlockingObjects
{
    public string[] UnlockingObjects;
    public DataToUnlockingObjects(CharacteristicsHero characteristicsHero)
    {
        UnlockingObjects = new string[15];
        for (int index = 0; index < characteristicsHero.SlotsDoorUnlockingObjects.Count; index++)
        {
            UnlockingObjects[index] = characteristicsHero.SlotsDoorUnlockingObjects[index].name;
        }
    }
}

[Serializable]
public class DataToThingsThatWereUsed
{
    public string[] TTWU;
    public DataToThingsThatWereUsed(CharacteristicsHero characteristicsHero)
    {
        TTWU = new string[15];
        for (int index = 0; index < characteristicsHero.SlotForThingsThatWereUsed.Count; index++)
        {
            TTWU[index] = characteristicsHero.SlotForThingsThatWereUsed[index].name;
        }
    }
}