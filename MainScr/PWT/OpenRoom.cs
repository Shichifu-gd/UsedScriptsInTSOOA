using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OpenRoom : MonoBehaviour
{
    public List<string> CurrentNameRoom;

    int indexFOR = 0;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            CurrentNameRoom.Add("солнечный кролик");
        }
        if (File.Exists(Application.dataPath + "/data/OR.sav")) LoadList();
    }

    public void AddToListOR(string RoomName)
    {
        if (indexFOR < 15)
        {
            CurrentNameRoom[indexFOR] = RoomName;
            indexFOR++;
        }
        else
        {
            indexFOR = 0;
            CurrentNameRoom[indexFOR] = RoomName;
        }
    }

    public void SaveList()
    {
        SaveAndLoadOR.SaveOpenRoom(this);
    }

    public void LoadList()
    {
        string[] ListOpenRoom = SaveAndLoadOR.LoadOpenRoom();
        for (int index = 0; index < 15; index++)
        {
            CurrentNameRoom[index] = ListOpenRoom[index];
        }
    }
}