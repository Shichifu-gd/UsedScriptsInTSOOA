using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/IKSFCH")]
public class IKSFCH : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        if (PrintedText.Length == 2)
        {
            if (PrintedText[0] == "я")  inputManager.roomManager.CheckingTheKeyToSelectTheCharacteristicsOfTheHero(PrintedText[0], PrintedText[1]);           
        }
        else inputManager.IfTheWrongKey();
        if (PrintedText.Length >= 2)
        {
            if (PrintedText[0] == "i" && PrintedText[1] == "am")  inputManager.roomManager.CheckingTheKeyToSelectTheCharacteristicsOfTheHero(PrintedText[0], PrintedText[2]);
            if (PrintedText[0] == "меня" || PrintedText[0] == "my") inputManager.roomManager.AcceptInputPlayerName(PrintedText[0], PrintedText[1], PrintedText[2]);
        }
        else inputManager.IfTheWrongKey();
    }
}