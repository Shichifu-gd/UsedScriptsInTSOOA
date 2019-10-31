using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Drink")]
public class KeyForDrink : AcceptsInputKey
{
    bool SwitchFKD;

    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        SwitchFKD = false;
        if (PrintedText.Length == 2)
        {
            if (PrintedText[1] == "зелье") inputManager.roomManager.KeyCheckForToDrinkPotions(PrintedText[0], PrintedText[1]);
            SwitchFKD = true;
        }
        if (PrintedText.Length == 3)
        {
            if (PrintedText[2] == "potion") inputManager.roomManager.KeyCheckForToDrinkPotions(PrintedText[0], PrintedText[2]);
            SwitchFKD = true;
        }
        if (SwitchFKD == false) inputManager.IfTheWrongKey();
    }
}