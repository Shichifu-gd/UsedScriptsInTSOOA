using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Objects/Room")]
public class Room : ScriptableObject
{
    public string WhatIsTheRoomUsedFor;
    public string Localization;
    public string Level;
    public string RoomNumber;
    public string TransitionNumber;

    public bool OpponentsInLocation = false;
    public bool boss;
    public bool SwitchBetweenBattleAndTravel = false;
    public bool СlearTransitionDescription = false;

    [TextArea] public string DescriptionRoom;

    public AvailableTransitionsITR[] DirectionOfMovementInTheRoom;
    public InteractableObject[] ObjectsInTheRoom;
    public ObjectsAffectingCharacteristic[] AltarInTheRoom;
}