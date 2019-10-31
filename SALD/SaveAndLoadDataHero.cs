using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadDataHero : MonoBehaviour
{
    public static void SaveMaximumValuesOfTheHero(CharacteristicsHero Characteristics)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/MaxValue.sav", FileMode.Create);
        MaximumValuesOfTheHero data = new MaximumValuesOfTheHero(Characteristics);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadMaximumValuesOfTheHero()
    {
        if (File.Exists(Application.dataPath + "/data/MaxValue.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/MaxValue.sav", FileMode.Open);
            MaximumValuesOfTheHero data = bf.Deserialize(stream) as MaximumValuesOfTheHero;
            stream.Close();
            return data.MaxValuesHero;
        }
        else return new float[0];
    }

    public static void SaveCurrentValuesOfTheHero(CharacteristicsHero Characteristics)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/CurValue.sav", FileMode.Create);
        CurrentValuesOfTheHero data = new CurrentValuesOfTheHero(Characteristics);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadCurrentValuesOfTheHero()
    {
        if (File.Exists(Application.dataPath + "/data/CurValue.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/CurValue.sav", FileMode.Open);
            CurrentValuesOfTheHero data = bf.Deserialize(stream) as CurrentValuesOfTheHero;
            stream.Close();
            return data.CurrentValuesHero;
        }
        else return new float[0];
    }

    public static void SaveInfoAboutHero(CharacteristicsHero Characteristics)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/InformationHero.sav", FileMode.Create);
        InfoAboutHeroes data = new InfoAboutHeroes(Characteristics);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadInfoAboutHero()
    {
        if (File.Exists(Application.dataPath + "/data/InformationHero.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/InformationHero.sav", FileMode.Open);
            InfoAboutHeroes data = bf.Deserialize(stream) as InfoAboutHeroes;
            stream.Close();
            return data.InformationHero;
        }
        else return new string[0];
    }
}

[Serializable]
public class MaximumValuesOfTheHero
{    
    public float[] MaxValuesHero;
    public MaximumValuesOfTheHero(CharacteristicsHero Characteristics)
    {
        MaxValuesHero = new float[9];
        MaxValuesHero[0] = Characteristics.FullHealth;
        MaxValuesHero[1] = Characteristics.MaxAttack;
        MaxValuesHero[2] = Characteristics.MinAttack;
        MaxValuesHero[3] = Characteristics.MaxArmor;
        MaxValuesHero[4] = Characteristics.MinArmor;
        MaxValuesHero[5] = Characteristics.MaxAbility;
        MaxValuesHero[6] = Characteristics.MinAbility;
        MaxValuesHero[7] = Characteristics.Block;
        MaxValuesHero[8] = Characteristics.Regen;
    }
}

[Serializable]
public class CurrentValuesOfTheHero
{
    public float[] CurrentValuesHero;
    public CurrentValuesOfTheHero(CharacteristicsHero Characteristics)
    {
        CurrentValuesHero = new float[8];
        CurrentValuesHero[0] = Characteristics.CurrentHealth;
        CurrentValuesHero[1] = Characteristics.CurrentHead;
        CurrentValuesHero[2] = Characteristics.CurrentBody;
        CurrentValuesHero[3] = Characteristics.CurrentLHand;
        CurrentValuesHero[4] = Characteristics.CurrentRHand;
        CurrentValuesHero[5] = Characteristics.CurrentLLeg;
        CurrentValuesHero[6] = Characteristics.CurrentRLeg;
        CurrentValuesHero[7] = Characteristics.PotionX;
    }
}

[Serializable]
public class InfoAboutHeroes
{
    public string[] InformationHero;
    public InfoAboutHeroes(CharacteristicsHero Characteristics)
    {
        InformationHero = new string[4];
        InformationHero[0] = Characteristics.Name;
        InformationHero[1] = Characteristics.Race;
        InformationHero[2] = Characteristics.StoryClass;
        InformationHero[3] = Characteristics.Class;
    }
}