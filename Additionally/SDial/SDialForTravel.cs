using UnityEngine;

public class SDialForTravel : MonoBehaviour
{
    public string SelectedDialogue;

    private static System.Random RandomForDialogFearInTheRoom = new System.Random();

    public void SwitchingBetweenLanguagesForDialogFearInTheRoom(string Language)
    {
        if (Language == "ru") DialogFearInTheRoomRu();
        if (Language == "en") DialogFearInTheRoomEn();
    }

    void DialogFearInTheRoomRu()
    {
        int DialogueNumber = RandomForDialogFearInTheRoom.Next(0, 2);
        if (DialogueNumber == 0) SelectedDialogue = "Мне страшно..";
        if (DialogueNumber == 1) SelectedDialogue = "Мне неприятно здесь находится..";
        if (DialogueNumber == 2) SelectedDialogue = "Мне кажется я уже здесь был";
        if (DialogueNumber == 3) SelectedDialogue = "Я где-то видел эту комнату, но не могу вспомнить где.";
    }

    void DialogFearInTheRoomEn()
    {
        int DialogueNumber = RandomForDialogFearInTheRoom.Next(0, 2);
        if (DialogueNumber == 0) SelectedDialogue = "I'm scared..";
        if (DialogueNumber == 1) SelectedDialogue = "It’s unpleasant for me to be here ..";
        if (DialogueNumber == 2) SelectedDialogue = "I think I was already here";
        if (DialogueNumber == 3) SelectedDialogue = "I saw this room somewhere, but I can’t remember where.";
    }
}