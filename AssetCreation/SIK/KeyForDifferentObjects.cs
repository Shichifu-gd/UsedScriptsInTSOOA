using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Interaction with the altar")]

public class KeyForDifferentObjects : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        if (PrintedText.Length > 1)
        {
            if (PrintedText[0] == "активировать" && PrintedText[1] == "алтарь") inputManager.roomManager.KeyVerificationToAltar(PrintedText[0], PrintedText[1]);
        }
        else inputManager.IfTheWrongKey();
    }
}