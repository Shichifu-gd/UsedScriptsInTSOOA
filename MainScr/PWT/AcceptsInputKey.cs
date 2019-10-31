using UnityEngine;

public abstract class AcceptsInputKey : ScriptableObject
{    
    //ввод
    public string TypedKeyword;
    //принимает ввод
    public abstract void RespondsToTextInput(InputManager inputManager, string[] PrintedText);
}