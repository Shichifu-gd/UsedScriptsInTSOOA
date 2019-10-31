using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/KFB")]
public class KeyForBattle : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        if (PrintedText.Length == 2) inputManager.roomManager.KeyCheckForToBattle(PrintedText[0], "", PrintedText[1]);
        else inputManager.IfTheWrongKey();
        if (PrintedText.Length == 3) inputManager.roomManager.KeyCheckForToBattle(PrintedText[0], PrintedText[1], PrintedText[2]);
        else inputManager.IfTheWrongKey();
    }
}