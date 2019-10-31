using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/InteractingWithObjectsKey")]
public class KeyForInteractingWithObject : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        if (PrintedText.Length == 2)
        {
            if (PrintedText[0] == "взять" || PrintedText[0] == "take" ||
                PrintedText[0] == "использовать" || PrintedText[0] == "use" ||
                PrintedText[0] == "изучить" || PrintedText[0] == "study") inputManager.roomManager.KeyCheckForUseInteractingObjects(PrintedText[0], PrintedText[1]);
        }
        else inputManager.IfTheWrongKey();
    }
}