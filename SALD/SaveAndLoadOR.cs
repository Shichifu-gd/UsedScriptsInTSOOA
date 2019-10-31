using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public class SaveAndLoadOR : MonoBehaviour
{
    public static void SaveOpenRoom(OpenRoom openRoom)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/data/OR.sav", FileMode.Create);
        DataOpenRoom data = new DataOpenRoom(openRoom);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadOpenRoom()
    {
        if (File.Exists(Application.dataPath + "/data/OR.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath + "/data/OR.sav", FileMode.Open);
            DataOpenRoom data = bf.Deserialize(stream) as DataOpenRoom;
            stream.Close();
            return data.ListOpenRoom;
        }
        else return new string[0];
    }
}

[Serializable]
public class DataOpenRoom
{
    public string[] ListOpenRoom;
    public DataOpenRoom(OpenRoom openRoom)
    {
        ListOpenRoom = new string[15];
        for (int index = 0; index < openRoom.CurrentNameRoom.Count; index++)
        {
            ListOpenRoom[index] = openRoom.CurrentNameRoom[index];
        }     
    }
}