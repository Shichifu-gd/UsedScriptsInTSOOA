using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Objects/Interactable object")]
public class InteractableObject : ScriptableObject
{
    public string ObjectName = "name";
    public string ObjectKey = "key";
    [TextArea] public string Description = "description in room";
    [TextArea] public string DescriptionForExamine = "description for Examine";

    public InteractingWithAnInteractiveObject[] ListWithInteractions;
}