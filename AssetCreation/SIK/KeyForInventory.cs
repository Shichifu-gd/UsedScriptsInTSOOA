using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Inventory")]
public class KeyForInventory : AcceptsInputKey
{
    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        //inputManager.interactableItems.DisplayInventory();
    }
}