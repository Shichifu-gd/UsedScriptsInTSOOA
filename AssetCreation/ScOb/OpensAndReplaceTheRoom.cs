using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Objects/Replaces closed room")]
public class OpensAndReplaceTheRoom : ActionResponse
{
    public Room roomToChangeTo;

    public override bool DoActionResponse(InputManager inputManager)
    {
        if (inputManager.roomManager.currentRoom.name == requiredString)
        {
            inputManager.roomManager.currentRoom = roomToChangeTo;
            inputManager.DisplaysRoomInformationOnTheDisplay();
            return true;
        }
        return false;
    }
}