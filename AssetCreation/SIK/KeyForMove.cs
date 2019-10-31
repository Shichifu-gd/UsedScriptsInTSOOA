using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Move")]
public class KeyForMove : AcceptsInputKey
{
    bool SwitchFKM;

    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        SwitchFKM = false;

        if (PrintedText.Length == 2)
        {
            if (PrintedText[0] == "название" && PrintedText[1] == "комнаты" ||
                       PrintedText[0] == "room" && PrintedText[1] == "name") inputManager.roomManager.OnOrOffRoomName();
            SwitchFKM = true;
        }

        if (PrintedText.Length >= 2)
        {
            if (PrintedText[0] == "спустится" && PrintedText[1] == "вниз" ||
                PrintedText[0] == "will" && PrintedText[1] == "go" && PrintedText[2] == "down") inputManager.roomManager.KeyCheckForWillGoDown(PrintedText[0], PrintedText[1]);
            SwitchFKM = true;
        }

        if (PrintedText.Length == 3)
        {
            if (PrintedText[0] == "идти" && PrintedText[1] == "на" ||
               PrintedText[0] == "go" && PrintedText[1] == "to") inputManager.roomManager.TranslateInputKeyForTransition(PrintedText[0], PrintedText[1], PrintedText[2]);
            if (PrintedText[0] == "войти" && PrintedText[1] == "в" ||
                PrintedText[0] == "enter" && PrintedText[1] == "the") inputManager.roomManager.KeyCheckForToEnterTheRoom(PrintedText[0], PrintedText[1], PrintedText[2]);
            SwitchFKM = true;
        }
        if (SwitchFKM == false) inputManager.IfTheWrongKey();
    }
}