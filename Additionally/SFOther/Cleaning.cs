using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public CharacteristicsHero characteristicsHero;
    public TransitionBetweenModes transitionBetweenModes;

    public void CleanAllSave()
    {
        CleanCharacteristicsHero();
        CleaningPath();
    }
    
    void CleanCharacteristicsHero()
    {        
        characteristicsHero.Name = "Лисенок убрался";
        characteristicsHero.Race = "лис";
        characteristicsHero.StoryClass = "веселый";
        characteristicsHero.Class = "охотник";
        characteristicsHero.FullHealth = 0;
        characteristicsHero.CurrentHealth = 0;
        characteristicsHero.MaxArmor = 0;
        characteristicsHero.MinArmor = 0;
        characteristicsHero.MaxAttack = 0;
        characteristicsHero.MinAttack = 0;
        characteristicsHero.MaxAbility = 0;
        characteristicsHero.MinAbility = 0;
        characteristicsHero.CurrentHead = 0;
        characteristicsHero.CurrentBody = 0;
        characteristicsHero.CurrentLHand = 0;
        characteristicsHero.CurrentRHand = 0;
        characteristicsHero.CurrentLLeg = 0;
        characteristicsHero.CurrentRLeg = 0;
        characteristicsHero.IndexForUO = 0;
        characteristicsHero.ClianingList();
        characteristicsHero.SaveACH();
    }

    void CleaningPath()
    {
        for (int index = 0; index < 89; index++)
        {
            transitionBetweenModes.ListNameRooms[index] = "";
            transitionBetweenModes.ListRoomsNumbers[index] = "";
        }
        transitionBetweenModes.PathToLevels = "";
        transitionBetweenModes.PathNameRoom = "";
        transitionBetweenModes.RoomCheck = "";
        transitionBetweenModes.IndexRoomForlist = 0;
        transitionBetweenModes.CheckOnTheEnemy = 0;
        transitionBetweenModes.LastPoint = "";
        transitionBetweenModes.SaveList();
        transitionBetweenModes.SaveLP();
    }
}