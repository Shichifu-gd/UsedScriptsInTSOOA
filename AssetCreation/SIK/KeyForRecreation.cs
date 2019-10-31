using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Recreation")]
public class KeyForRecreation : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
       // if (PrintedText.Length > 1) inputManager.roomManager.KeyCheckForToRelax(PrintedText[0], PrintedText[1]);        
       // else  inputManager.IfTheWrongKey();        
    }
}