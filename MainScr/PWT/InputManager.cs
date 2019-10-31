using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public LocalizationCheck localizationCheck;
    public BattleScript battleScript;
    public RoomManager roomManager;
    public Menu menu;
    public AudioForRandomEvent audioForRandomEvent;
    public AudioForStep audioForStep;
    public StartAnimation startAnimation;
    public KeyList keyList;
    public GameObject Information;

    public Text DisplayText;

    [HideInInspector] public List<AcceptsInputKey> GeneralListOfKeys;
    [HideInInspector] public List<string> InteractionDescriptionsInRoom = new List<string>();

    [HideInInspector]
    public string logText;
    List<string> ActionLog = new List<string>();

    string Narrator;
    bool SwitchInformation;
    bool DisableItemsOnSart;

    public List<AcceptsInputKey> ListOfKeysForTravel;
    public List<AcceptsInputKey> ListOfKeysForBattle;
    public List<AcceptsInputKey> ListOfKeysForInteractiveObjects;

    public void StartInputManager()
    {
        if (menu) menu.StartMenu();
        AdditionalSettings();
        DisplaysRoomInformationOnTheDisplay();
        DisplaysTheEnteredText();
        localizationCheck.StartLocalizationCheck(roomManager.currentRoom.WhatIsTheRoomUsedFor);
        MergesListsIntoOneList();
    }

    void AdditionalSettings()
    {
        if (roomManager.generalSettings.Language == "ru") Narrator = "Рассказчик: ";
        else Narrator = "Narrator: ";
    }

    public void DisplaysRoomInformationOnTheDisplay()
    {
        string CombinedText = "";
        ClearCollectionForNewRoom();
        UnpacksTheExitsFromTheRoom();
        string JoinedInteractionDescriptions = string.Join("\n", InteractionDescriptionsInRoom.ToArray());
        if (JoinedInteractionDescriptions == "") CombinedText = Narrator + roomManager.currentRoom.DescriptionRoom + "" + JoinedInteractionDescriptions;
        else CombinedText = Narrator + roomManager.currentRoom.DescriptionRoom;
        DisplayTheEnteredText(CombinedText);
        if (roomManager.currentRoom.AltarInTheRoom.Length > 0 && roomManager.currentRoom.AltarInTheRoom[0] == true) DisplayTheEnteredText("\n" + Narrator + roomManager.currentRoom.AltarInTheRoom[0].Description);
        if (roomManager.currentRoom.ObjectsInTheRoom.Length > 0 && roomManager.currentRoom.ObjectsInTheRoom[0] == true) CheckWhetherWePickedUpTheItem();
        if (audioForStep != null && DisableItemsOnSart == false) LaunchAudio();
        else DisableItemsOnSart = false;
    }

    void ClearCollectionForNewRoom()
    {
        InteractionDescriptionsInRoom.Clear();
        roomManager.ClearExits();
    }

    void UnpacksTheExitsFromTheRoom()
    {
        roomManager.UnpackExitsFromTheCurrentRoomToInteractWithIt();
    }

    public void DisplayTheEnteredText(string StringToAdd)
    {
        ActionLog.Add(StringToAdd + "\n");
    }

    void LaunchAudio()
    {
        if (roomManager.currentRoom.name != "start" && roomManager.currentRoom.WhatIsTheRoomUsedFor == "travel")
        {
            audioForStep.SelectAudiForStep();
            audioForRandomEvent.ChooseTheNumberOfLayers();
        }
    }

    public void DisplaysTheEnteredText()
    {
        string LogText = string.Join("", ActionLog.ToArray());
        DisplayText.text = LogText;
        TextLimit();
    }

    void TextLimit()
    {
        var Quantity = DisplayText.text.Length;
        int Limit = 3000;
        if (Quantity > Limit)
        {
            int DynamicIndex = Quantity;
            DynamicIndex = DynamicIndex - Limit;
            DisplayText.text = DisplayText.text.Remove(0, DynamicIndex);
        }
    }

    void MergesListsIntoOneList()
    {
        int asd = ListOfKeysForTravel.Count;
        for (int a = 0; a < asd; a++)
        {
            GeneralListOfKeys.Add(ListOfKeysForTravel[a]);
        }

        asd = ListOfKeysForBattle.Count;
        for (int a = 0; a < asd; a++)
        {
            GeneralListOfKeys.Add(ListOfKeysForBattle[a]);
        }

        asd = ListOfKeysForInteractiveObjects.Count;
        for (int a = 0; a < asd; a++)
        {
            GeneralListOfKeys.Add(ListOfKeysForInteractiveObjects[a]);
        }
    }

    void CheckWhetherWePickedUpTheItem()
    {
        bool SwitchForOutput = false;
        for (int index = 0; index < 15; index++)
        {
            if (roomManager.characteristicsHero.SlotsDoorUnlockingObjects[index] == roomManager.currentRoom.ObjectsInTheRoom[0] ||
                roomManager.characteristicsHero.SlotForThingsThatWereUsed[index] == roomManager.currentRoom.ObjectsInTheRoom[0])
            {
                SwitchForOutput = true;
                index = 15;
            }
        }
        if (SwitchForOutput == false) DisplayTheEnteredText("\n" + Narrator + roomManager.currentRoom.ObjectsInTheRoom[0].Description);
    }

    public void DescriptionOutput(string description)
    {
        DisplayTheEnteredText(description);
    }

    public void DisableOrEnable(string key)
    {
        if (key == "инф" || key == "информация") keyList.RuKey();
        if (key == "inf" || key == "information") keyList.EnKey();
        if (SwitchInformation == false)
        {
            Information.SetActive(true);
            SwitchInformation = true;
        }
        else
        {
            SwitchInformation = false;
            Information.SetActive(false);
        }
    }

    public void IfTheWrongKey()
    {
        if (roomManager.currentRoom.Level == "Class selection") roomManager.IfTheWrongKeyThenUseTheAlternative();
        if (roomManager.currentRoom.WhatIsTheRoomUsedFor == "travel")
        {
            if (roomManager.generalSettings.Language == "ru") DisplayTheEnteredText("\n" + roomManager.characteristicsHero.Name + ": " + "эм");
            else DisplayTheEnteredText("\n" + roomManager.characteristicsHero.Name + ": " + "Em");
        }
    }

    public void AcceptsAKeyForExit(string Key)
    {
        if (Key == "выйти" || Key == "exit")
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit ();
#endif
        }
    }
}