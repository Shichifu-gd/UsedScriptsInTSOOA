using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadTBM : MonoBehaviour
{
    public static void SaveTBM(TransitionBetweenModes transitionBetweenModes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/path.sav", FileMode.Create);
        DataTransitionBetweenModes data = new DataTransitionBetweenModes(transitionBetweenModes);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadTBM()
    {
        if (File.Exists(Application.dataPath + "/data/path.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/path.sav", FileMode.Open);
            DataTransitionBetweenModes data = bf.Deserialize(stream) as DataTransitionBetweenModes;
            stream.Close();
            return data.LogForDTBM;
        }
        else return new string[0];
    }

    public static void SaveIndexToList(TransitionBetweenModes transitionBetweenModes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/ITL.sav", FileMode.Create);
        SaveIndexList data = new SaveIndexList(transitionBetweenModes);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadIndexToList()
    {
        if (File.Exists(Application.dataPath + "/data/ITL.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/ITL.sav", FileMode.Open);
            SaveIndexList data = bf.Deserialize(stream) as SaveIndexList;
            stream.Close();
            return data.IndexToList;
        }
        else return new int[0];
    }

    public static void SaveIndexToLP(TransitionBetweenModes transitionBetweenModes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/LastPoint.sav", FileMode.Create);
        SaveLP data = new SaveLP(transitionBetweenModes);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadIndexToLP()
    {
        if (File.Exists(Application.dataPath + "/data/LastPoint.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/LastPoint.sav", FileMode.Open);
            SaveLP data = bf.Deserialize(stream) as SaveLP;
            stream.Close();
            return data.IndexToLP;
        }
        else return new string[0];
    }

    public static void SaveScore(Score score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/Score.sav", FileMode.Create);
        SaveScore data = new SaveScore(score);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadScore()
    {
        if (File.Exists(Application.dataPath + "/data/Score.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/Score.sav", FileMode.Open);
            SaveScore data = bf.Deserialize(stream) as SaveScore;
            stream.Close();
            return data.DataScore;
        }
        else return new int[0];
    }

    public static void SaveRoomNumber(TransitionBetweenModes transitionBetweenModes)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/RN.sav", FileMode.Create);
        DataRoomNumber data = new DataRoomNumber(transitionBetweenModes);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadRoomNumber()
    {
        if (File.Exists(Application.dataPath + "/data/RN.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/RN.sav", FileMode.Open);
            DataRoomNumber data = bf.Deserialize(stream) as DataRoomNumber;
            stream.Close();
            return data.SaveRN;
        }
        else return new string[0];
    }
}

[Serializable]
public class DataTransitionBetweenModes
{
    public string[] LogForDTBM;
    public DataTransitionBetweenModes(TransitionBetweenModes transitionBetweenModes)
    {
        int indexOne = 3;
        LogForDTBM = new string[95];
        LogForDTBM[0] = transitionBetweenModes.PathToLevels;
        LogForDTBM[1] = transitionBetweenModes.PathNameRoom;
        LogForDTBM[2] = transitionBetweenModes.RoomCheck;
        for (int index = 0; index < 89; index++)
        {
            indexOne++;
            LogForDTBM[indexOne] = transitionBetweenModes.ListNameRooms[index];
        }
    }
}

[Serializable]
public class DataRoomNumber
{
    public string[] SaveRN;
    public DataRoomNumber(TransitionBetweenModes transitionBetweenModes)
    {
        SaveRN = new string[89];
        for (int index = 0; index < 89; index++)
        {
            SaveRN[index] = transitionBetweenModes.ListRoomsNumbers[index];
        }
    }
}

[Serializable]
public class SaveIndexList
{
    public int[] IndexToList;
    public SaveIndexList(TransitionBetweenModes transitionBetweenModes)
    {
        IndexToList = new int[2];
        IndexToList[0] = transitionBetweenModes.IndexRoomForlist;
        IndexToList[1] = transitionBetweenModes.CheckOnTheEnemy;
    }
}

[Serializable]
public class SaveLP
{
    public string[] IndexToLP;
    public SaveLP(TransitionBetweenModes transitionBetweenModes)
    {
        IndexToLP = new string[1];
        IndexToLP[0] = transitionBetweenModes.LastPoint;
    }
}

[Serializable]
public class SaveScore
{
    public int[] DataScore;
    public SaveScore(Score score)
    {
        DataScore = new int[1];
        DataScore[0] = score.CurrentScoreTransitions;
    }
}