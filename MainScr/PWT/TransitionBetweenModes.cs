using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TransitionBetweenModes : MonoBehaviour
{
    public string LastPoint;
    public string CurrentNameRoom;
    public string RoomCheck;
    public string PathToLevels;
    public string PathNameRoom;
    public string RoomNumberFSAL;

    public int IndexRoomForlist;
    public int CheckOnTheEnemy;

    public List<string> ListNameRooms;
    public List<string> ListRoomsNumbers;

    public void StartTBM()
    {
        for (int i = 0; i < 90;)
        {
            ListNameRooms.Add(CurrentNameRoom);
            ListRoomsNumbers.Add("");
            i++;
        }
        if (File.Exists(Application.dataPath + "/data/path.sav")) LoadList();
        else IndexRoomForlist = 0;
    }

    public void AddToList()
    {
        if (IndexRoomForlist < 90)
        {
            PathNameRoom = CurrentNameRoom;
            ListNameRooms[IndexRoomForlist] = PathNameRoom;
            ListRoomsNumbers[IndexRoomForlist] = RoomNumberFSAL;
        }
        else
        {
            IndexRoomForlist = 0;
            PathNameRoom = CurrentNameRoom;
            ListNameRooms[IndexRoomForlist] = PathNameRoom;
            ListRoomsNumbers[IndexRoomForlist] = RoomNumberFSAL;
        }
        IndexRoomForlist++;
    }

    public void CheckWhatIsInTheRoom(bool OpponentsInLocation)
    {
        if (OpponentsInLocation == false) RoomCheck = "комната пуста";
        else RoomCheck = "в комнате есть враг";
    }

    public void LoadList()
    {
        string[] LP = SaveAndLoadTBM.LoadIndexToLP();
        LastPoint = LP[0];
        int indexOne = 3;
        int[] IndexToList = SaveAndLoadTBM.LoadIndexToList();
        IndexRoomForlist = IndexToList[0];
        CheckOnTheEnemy = IndexToList[1];

        string[] LogForDTBM = SaveAndLoadTBM.LoadTBM();
        PathToLevels = LogForDTBM[0];
        PathNameRoom = LogForDTBM[1];
        RoomCheck = LogForDTBM[2];

        for (int index = 0; index < 89; index++)
        {
            indexOne++;
            ListNameRooms[index] = LogForDTBM[indexOne];
        }

        string[] SaveRN = SaveAndLoadTBM.LoadRoomNumber();
        for (int index = 0; index < 89; index++)
        {
            ListRoomsNumbers[index] = SaveRN[index];
        }
    }

    public void SaveList()
    {
        SaveAndLoadTBM.SaveRoomNumber(this);
        SaveAndLoadTBM.SaveTBM(this);
        SaveAndLoadTBM.SaveIndexToList(this);
    }

    public void SaveLP()
    {
        SaveAndLoadTBM.SaveIndexToLP(this);
    }
}