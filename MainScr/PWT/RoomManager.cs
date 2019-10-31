using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class RoomManager : MonoBehaviour
{
    public Room currentRoom;
    public Room RuRoom;
    public Room EnRoom;
    public OpenRoom openRoom;

    public TransitionBetweenModes transitionBetweenModes;
    public GeneralSettings generalSettings;
    public CharacteristicsHero characteristicsHero;
    public CharacterCustomization characterCustomization;
    public BattleScript battleScript;
    public SupplementForHeroBody supplementForHero;
    public ShowsDirection showsDirection;
    public Score score;
    public Attenuation attenuation;
    public SDialForTravel sDialForTravel;
    InputManager inputManager;

    public Text RoomName;
    public GameObject SetActivTRN;

    string DescriptionOfTheTransition;
    string Language;
    string CharacterNameOutput;

    int NumberDialogForName = 0;
    int NumberForSDUO = 0;
    int IndexForListToAltar;

    bool SwitchForActivatingTheAltar;
    bool SwitchForActivatingTheInteractiveObject;
    bool CheckingIfThePlayerHasAccessToThePassage;
    bool CheckForOpenPassages;
    bool CheckWhetherItIsPossibleToUse;
    bool KeyVerificationForTransition;
    bool CheckForOpponentsInLocation;

    Dictionary<string, Room> ExitDictionary = new Dictionary<string, Room>();

    private static System.Random WhetherTheEnemyWillBeChosenInTheRoom = new System.Random();
    private static System.Random randomForDC = new System.Random();

    void Start()
    {
        if (attenuation) attenuation.AttenuationObject();
        generalSettings.StartGeneralSettings();
        transitionBetweenModes.StartTBM();
        Language = generalSettings.Language;
        LevelLoading();
    }

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    void LevelLoading()
    {
        if (currentRoom.WhatIsTheRoomUsedFor != "Class selection" && characteristicsHero == true) characteristicsHero.LoadCharacteristicsHero();
        if (characteristicsHero) CharacterNameOutput = "\n" + characteristicsHero.Name + ": ";
        if (battleScript == true)
        {
            if (currentRoom.boss == false) battleScript.characteristicsEnemy.ChoosingTheEnemy(Language);
            else battleScript.characteristicsEnemy.ChoosingTheEnemyBoss(Language);
            battleScript.LaunchBattle();
        }
        if (supplementForHero == true) supplementForHero.load();
        if (currentRoom.SwitchBetweenBattleAndTravel == false) LoadTBSAnd();
        else NewGame();
    }

    void LoadTBSAnd()
    {
        if (File.Exists(Application.dataPath + "/data/path.sav"))
        {
            if (transitionBetweenModes.PathToLevels != "") LoadsavedRoom();
            else NewGame();
        }
        else NewGame();
    }

    void NewGame()
    {
        if (generalSettings.Language == "ru")
        {
            Language = "ru";
            currentRoom = RuRoom;
        }
        else
        {
            Language = "en";
            currentRoom = EnRoom;
        }
        inputManager.StartInputManager();
    }

    void LoadsavedRoom()
    {
        AddToCurrentRoom();
    }

    void AddToCurrentRoom()
    {
        string localPath = "ScriptableObjects/" + generalSettings.Language +
                           "/Rooms/" + transitionBetweenModes.PathToLevels +
                           "/" + transitionBetweenModes.PathNameRoom;
        currentRoom = Resources.Load<Room>(localPath);
        inputManager.StartInputManager();
    }

    /* Распаковка выходов     
     * проверяет наличие переходов в другие комнаты 
     * если текущая комната для путешествия, то данные о комнате присваиваются в TBM и сохраняются
     * проверяет текущую комнату на наличие врага */
    public void UnpackExitsFromTheCurrentRoomToInteractWithIt()
    {
        for (int i = 0; i < currentRoom.DirectionOfMovementInTheRoom.Length; i++)
        {
            ExitDictionary.Add(currentRoom.DirectionOfMovementInTheRoom[i].KeyToEnterTheRoom, currentRoom.DirectionOfMovementInTheRoom[i].RoomToMove);
        }
        if (currentRoom.WhatIsTheRoomUsedFor != "menu")
        {
            inputManager.DisplayTheEnteredText("");
            if (currentRoom.OpponentsInLocation == true) IfThereIsAnEnemyInTheRoom();
        }
            if (showsDirection == true) VerificationAndRedirection();
    }

    void SavaeValueCurrentRoom()
    {
        transitionBetweenModes.LastPoint = currentRoom.WhatIsTheRoomUsedFor;
        transitionBetweenModes.SaveLP();
        AddElementToListTBM();
        SaveTransitionBetweenModes();
        if (score == true) score.CountsTransitions();
        if (RoomName) RoomName.text = currentRoom.name;       
    }

    void AddElementToListTBM()
    {
        transitionBetweenModes.RoomNumberFSAL = currentRoom.RoomNumber;
        transitionBetweenModes.CurrentNameRoom = currentRoom.name;
        transitionBetweenModes.CheckWhatIsInTheRoom(currentRoom.OpponentsInLocation);
        transitionBetweenModes.PathToLevels = currentRoom.Level;
        transitionBetweenModes.AddToList();
    }

    void SaveTransitionBetweenModes()
    {
        transitionBetweenModes.SaveList();
    }

    void VerificationAndRedirection()
    {
        bool S = false;
        bool N = false;
        bool E = false;
        bool W = false;
        for (int index = 0; index < currentRoom.DirectionOfMovementInTheRoom.Length; index++)
        {
            if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "север" ||
                currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "подземелье") N = true;
            if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "юг") S = true;
            if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "восток") E = true;
            if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "запад") W = true;
        }
        showsDirection.DirectionSelection(S, N, E, W);
    }

    void IfThereIsAnEnemyInTheRoom()
    {
        int num = Random.Range(0, 5);
        if (num == 1) attenuation.SwitcTheAppearanceForCharacteristicsHero = true;
        CheckOnTheEnemy();
        if (CheckForOpponentsInLocation == true)
        {
            if (transitionBetweenModes.CheckOnTheEnemy > 2) transitionBetweenModes.CheckOnTheEnemy = WhetherTheEnemyWillBeChosenInTheRoom.Next(0, 5);
            OpponentsInLocation();
            if (score == true) score.SaveTransitions();
        }
        else
        {
            sDialForTravel.SwitchingBetweenLanguagesForDialogFearInTheRoom(Language);
            inputManager.DisplayTheEnteredText(CharacterNameOutput + sDialForTravel.SelectedDialogue + "\n");
        }        
    }

    void CheckOnTheEnemy()
    {
        CheckForOpponentsInLocation = true;
        for (int index = 0; index < transitionBetweenModes.ListRoomsNumbers.Count; index++)
        {
            if (transitionBetweenModes.ListRoomsNumbers[index] == currentRoom.RoomNumber)
            {
                CheckForOpponentsInLocation = false;
                index = transitionBetweenModes.ListRoomsNumbers.Count;
            }
        }
    }

    void OpponentsInLocation()
    {
        if (currentRoom.boss == true) attenuation.TheAppearanceOfObject("Boss");        
        else attenuation.TheAppearanceOfObject("Ambush");
    }

    public void TranslateInputKeyForTransition(string Key, string KeyOne, string KeyTwo)
    {
        if (KeyTwo == "north") KeyTwo = "север";
        if (KeyTwo == "south") KeyTwo = "юг";
        if (KeyTwo == "east") KeyTwo = "восток";
        if (KeyTwo == "west") KeyTwo = "запад";
        if (Key == "go") Key = "идти";
        CheckTheEnteredKeyAndThenUnpackTheRoomWeNeed(Key, KeyOne, KeyTwo);
    }

    /* для начала проверяем ключ для перехода "Key"
     * затем проверяем закрыт ли проход 
     * если оказывается, что проход закрыт мы начинаем проверку "CheckIfThePassageIsOpen" где пытаемся узнать использовали ли мы ключ для прохода
     * после чего мы распаковываем комнату и выводим нужные нам данные */
    void CheckTheEnteredKeyAndThenUnpackTheRoomWeNeed(string Key, string KeyOne, string KeyTwo)
    {
        if (Key == "идти")
        {
            if (currentRoom.DirectionOfMovementInTheRoom.Length > 0)
            {
                KeyCheck(KeyTwo);
                if (KeyVerificationForTransition == true)
                {
                    ChecksIfThereIsALockInTheAisle(KeyTwo);
                    if (CheckForOpenPassages == true)
                    {
                        currentRoom = ExitDictionary[KeyTwo];
                        inputManager.DisplaysRoomInformationOnTheDisplay();
                        inputManager.startAnimation.StartingTheAnimation();
                        if (currentRoom.WhatIsTheRoomUsedFor == "travel") SavaeValueCurrentRoom();
                    }
                    else OutputTransitionDialog("если проход закрыт");
                }
                else WrongWay(KeyTwo);
            }
            else OutputTransitionDialog("если попал в ловушку");
        }
        else OutputTransitionDialog("если потерялся");
    }

    void OutputTransitionDialog(string Dialog)
    {
        if (Dialog == "если проход закрыт")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + "Проход закрыт.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + "The passage is closed.");
        }
        if (Dialog == "если попал в ловушку")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Вы попали в ловушку, и наверное умерли.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "You are trapped, and you must have died.");
        }
        if (Dialog == "если потерялся")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Я же не потерялся?");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "I'm not lost?");
        }
    }

    void KeyCheck(string KeyTwo)
    {
        KeyVerificationForTransition = false;
        for (int index = 0; index < currentRoom.DirectionOfMovementInTheRoom.Length; index++)
        {
            if (KeyTwo == currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom)
            {
                KeyVerificationForTransition = true;
                index = currentRoom.DirectionOfMovementInTheRoom.Length;
            }
        }
    }

    void ChecksIfThereIsALockInTheAisle(string KeyTwo)
    {
        for (int index = 0; index < currentRoom.DirectionOfMovementInTheRoom.Length; index++)
        {
            if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == KeyTwo)
            {
                if (currentRoom.DirectionOfMovementInTheRoom[index].KeyToOpenTheDoor == true) CheckIfThePassageIsOpen(index);                
                else CheckForOpenPassages = true;
                index = currentRoom.DirectionOfMovementInTheRoom.Length;
            }
        }
    }

    void CheckIfThePassageIsOpen(int indexRoom)
    {
        for (int index = 0; index < openRoom.CurrentNameRoom.Count; index++)
        {
            if (openRoom.CurrentNameRoom[index] == currentRoom.TransitionNumber)
            {
                CheckForOpenPassages = true;
                index = openRoom.CurrentNameRoom.Count;
            }
            else CheckForOpenPassages = false;
        }
    }

    void WrongWay(string KeyTwo)
    {
        if (Language == "ru")
        {
            if (KeyTwo == "север") inputManager.DisplayTheEnteredText(CharacterNameOutput + "На севере нет прохода.");
            if (KeyTwo == "юг") inputManager.DisplayTheEnteredText(CharacterNameOutput + "На юге нет прохода.");
            if (KeyTwo == "восток") inputManager.DisplayTheEnteredText(CharacterNameOutput + "На востоке нет прохода.");
            if (KeyTwo == "запад") inputManager.DisplayTheEnteredText(CharacterNameOutput + "На западе нет прохода.");
        }
        if (Language == "en")
        {
            if (KeyTwo == "север") inputManager.DisplayTheEnteredText(CharacterNameOutput + "There is no passage in the north.");
            if (KeyTwo == "юг") inputManager.DisplayTheEnteredText(CharacterNameOutput + "There is no passage in the south.");
            if (KeyTwo == "восток") inputManager.DisplayTheEnteredText(CharacterNameOutput + "There is no passage in the east.");
            if (KeyTwo == "запад") inputManager.DisplayTheEnteredText(CharacterNameOutput + "There is no passage in the west.");
        }
        if (KeyTwo == "" || KeyTwo == " " || KeyTwo == "  " || KeyTwo == "  " || KeyTwo == "  ") DirectionCheck();
    }

    void DirectionCheck()
    {
        int index = 0;
        if (currentRoom.DirectionOfMovementInTheRoom.Length > 0) index = randomForDC.Next(0, currentRoom.DirectionOfMovementInTheRoom.Length);
        bool SwitchDCZ = false;
        bool SwitchDCO = false;
        bool SwitchDCT = false;
        bool SwitchDCTR = false;
        OutputDialogueIfLost("потерялся");
        if (index == 0 && currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "север" && currentRoom.DirectionOfMovementInTheRoom[index].KeyToOpenTheDoor == false)
        {
            currentRoom = ExitDictionary["север"];
            OutputDialogueIfLost("север");
            SwitchDCZ = true;
        }
        if (index == 1 && currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "юг" && currentRoom.DirectionOfMovementInTheRoom[index].KeyToOpenTheDoor == false)
        {
            currentRoom = ExitDictionary["юг"];
            OutputDialogueIfLost("юг");
            SwitchDCO = true;
        }
        if (index == 2 && currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "восток" && currentRoom.DirectionOfMovementInTheRoom[index].KeyToOpenTheDoor == false)
        {
            currentRoom = ExitDictionary["восток"];
            OutputDialogueIfLost("восток");
            SwitchDCT = true;
        }
        if (index == 3 && currentRoom.DirectionOfMovementInTheRoom[index].KeyToEnterTheRoom == "запад" && currentRoom.DirectionOfMovementInTheRoom[index].KeyToOpenTheDoor == false)
        {
            currentRoom = ExitDictionary["запад"];
            OutputDialogueIfLost("запад");
            SwitchDCTR = true;
        }
        if (SwitchDCZ == true || SwitchDCO == true || SwitchDCT == true || SwitchDCTR == true) AssignValueForDC(true);
        else AssignValueForDC(false);
    }

    void OutputDialogueIfLost(string Dialog)
    {
        if (Dialog == "потерялся")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Вы потерялись....");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "You are lost ....");
        }
        if (Dialog == "север")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Потерявшись, вы пошли на север.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "Lost, you went north.");
        }
        if (Dialog == "юг")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Потерявшись, вы пошли на юг.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "Lost, you went south.");
        }
        if (Dialog == "восток")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Потерявшись, вы пошли на восток.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "Lost, you went east.");
        }
        if (Dialog == "запад")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Потерявшись, вы пошли на запад.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "Lost, you went west.");
        }
    }

    void AssignValueForDC(bool SwitchDC)
    {
        if (SwitchDC == true) inputManager.DisplaysRoomInformationOnTheDisplay();
        else
        {
            currentRoom = currentRoom.DirectionOfMovementInTheRoom[0].RoomToMove;
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + "Потерявшись, вы пошли в неизвестную сторону.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + "Lost, you went in an unknown direction.");
            inputManager.DisplaysRoomInformationOnTheDisplay();
        }
    }

    public void KeyVerificationToAltar(string Key, string KeyOne)
    {
        if (currentRoom.AltarInTheRoom.Length > 0)
        {
            if (IndexForListToAltar < 2)
            {
                CheckForTheUseOfTheAltar();
                if (SwitchForActivatingTheAltar == true) AddToListAltar();
                else OutputTheAltarUseDialog("опустошен");
            }
            else IndexForListToAltar = 0;
        }
        else OutputTheAltarUseDialog("комната пуста");
    }

    void AddToListAltar()
    {
        OutputTheAltarUseDialog("активация");
        if (IndexForListToAltar < 2) characteristicsHero.SlotsActivatedAltars[IndexForListToAltar] = currentRoom.AltarInTheRoom[0];
        characteristicsHero.SaveCurrentInventoryOfAltar();
        characteristicsHero.ActivationOpportunitiesAltar();
        IndexForListToAltar++;
    }

    void OutputTheAltarUseDialog(string Dialog)
    {
        if (Dialog == "активация")
        {
            if (Language == "ru")
            {
                inputManager.DisplayTheEnteredText("\n" + "Подойдя ближе к алтарю, вы протягиваете руку, и делаете надрез на запястье. Ваша кровь начинает капать на расписанный алтарь.");
                inputManager.DisplayTheEnteredText("Во время обряда, вы чувствовали некий прилив сил.");
            }
            if (Language == "en")
            {
                inputManager.DisplayTheEnteredText("\n" + "Stepping closer to the altar, you reach out and make an incision on your wrist. Your blood begins to drip onto the painted altar.");
                inputManager.DisplayTheEnteredText("While you were doing the ceremony, you felt a certain influx of strength.");
            }
        }
        if (Dialog == "опустошен")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "Алтарь опустошен..");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "The altar is devastated..");
        }
        if (Dialog == "комната пуста")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "Здесь нет никакого алтаря, наверное мне пора валить отсюда. Уже алтари мерещатся.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "There is no altar here, I guess it's time for me to get out of here. Already the altars seem.");
        }
    }

    void CheckForTheUseOfTheAltar()
    {
        SwitchForActivatingTheAltar = true;
        for (int index = 0; index < 2; index++)
        {
            if (characteristicsHero.SlotsActivatedAltars[index] == currentRoom.AltarInTheRoom[0]) SwitchForActivatingTheAltar = false;
        }
    }

    public void KeyCheckForToEnterTheRoom(string Key, string KeyOne, string KeyTwo)
    {
        if (Key == "войти" && KeyTwo == "подземелье" || Key == "enter" && KeyTwo == "dungeon")
        {
            if (KeyTwo == "dungeon") KeyTwo = "подземелье";
            KeyCheck(KeyTwo);
            if (KeyVerificationForTransition == true)
            {
                if (currentRoom.DirectionOfMovementInTheRoom.Length > 0)
                {
                    currentRoom = ExitDictionary[KeyTwo];
                    inputManager.DisplaysRoomInformationOnTheDisplay();
                }
                else OutputDungeonEntryDialog("тупик");
            }
        }
        else OutputDungeonEntryDialog("нет входа");
    }

    void OutputDungeonEntryDialog(string Dialog)
    {
        if (Dialog == "тупик")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "Вы попали в ловушку, и наверное умерли.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "You are trapped, and you must have died.");
        }
        if (Dialog == "нет входа")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "Там нет входа.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "There's no entrance.");
        }
    }

    public void KeyCheckForWillGoDown(string Key, string KeyOne)
    {
        if (Key == "will") Key = "спустится";
        KeyCheck(Key);
        if (KeyVerificationForTransition == true)
        {
            if (currentRoom.DirectionOfMovementInTheRoom.Length > 0)
            {
                currentRoom = ExitDictionary[Key];
                inputManager.DisplaysRoomInformationOnTheDisplay();
            }
            else OutputDescentDialog("нет спуска");
        }
    }

    void OutputDescentDialog(string Dialog)
    {
        if (Dialog == "нет спуска")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "Здесь нет спуска вниз.");
            if (Language == "en") inputManager.DisplayTheEnteredText("\n" + CharacterNameOutput + "There is no descent down.");
        }
    }

    public void KeyCheckForUseInteractingObjects(string Key, string KeyOne)
    {
        if (Key == "взять" || Key == "take")
        {
            if (KeyOne == currentRoom.ObjectsInTheRoom[0].ObjectKey) CheckWhetherItIsPossibleToTakeAnItem();
            else OutputDialogueOfInteractionWithTheSubject("нельзя взять");
        }
        if (Key == "использовать" || Key == "use")
        {
            if (characteristicsHero.SlotsDoorUnlockingObjects.Count > 0) CheckWhetherItIsPossibleToUseAnItem(KeyOne);
            else OutputDialogueOfInteractionWithTheSubject("нет предмета в комнате 1");
        }
        if (Key == "изучить" || Key == "study")
        {
            if (characteristicsHero.SlotsDoorUnlockingObjects.Count > 0) CheckWhetherItIsPossibleToExamineAnItem(KeyOne);
            else OutputDialogueOfInteractionWithTheSubject("нет предмета в инвентаре");
        }
    }

    void CheckWhetherItIsPossibleToTakeAnItem()
    {
        if (currentRoom.ObjectsInTheRoom.Length > 0)
        {
            SwitchForActivatingTheInteractiveObject = true;
            CheckForDuplicateItemToInventory();
            if (SwitchForActivatingTheInteractiveObject == true)
            {
                if (NumberForSDUO < 15)
                {
                    characteristicsHero.SlotsDoorUnlockingObjects[NumberForSDUO] = currentRoom.ObjectsInTheRoom[0];
                    NumberForSDUO++;
                }
                else
                {
                    NumberForSDUO = 0;
                    characteristicsHero.SlotsDoorUnlockingObjects[NumberForSDUO] = currentRoom.ObjectsInTheRoom[0];
                }
                OutputDialogueOfInteractionWithTheSubject("подобран");
                characteristicsHero.SaveSlotsDoorUnlockingObjects();
            }
            else OutputDialogueOfInteractionWithTheSubject("нет предмета в комнате 2");
        }
    }

    void CheckForDuplicateItemToInventory()
    {
        for (int index = 0; index < characteristicsHero.SlotsDoorUnlockingObjects.Count; index++)
        {
            if (characteristicsHero.SlotsDoorUnlockingObjects[index].ObjectName == currentRoom.ObjectsInTheRoom[0].ObjectName)
            {
                SwitchForActivatingTheInteractiveObject = false;
                index = characteristicsHero.SlotsDoorUnlockingObjects.Count;
            }
        }
    }

    void CheckWhetherItIsPossibleToUseAnItem(string KeyOne)
    {
        bool ForLogDisplay = false;

        for (int index = 0; index < characteristicsHero.SlotsDoorUnlockingObjects.Count; index++)
        {
            if (characteristicsHero.SlotsDoorUnlockingObjects[index].ObjectKey == KeyOne)
            {
                for (int indexA = 0; indexA < currentRoom.DirectionOfMovementInTheRoom.Length; indexA++)
                {
                    if (currentRoom.DirectionOfMovementInTheRoom[indexA].KeyToOpenTheDoor == characteristicsHero.SlotsDoorUnlockingObjects[index])
                    {
                        if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + characteristicsHero.SlotsDoorUnlockingObjects[index].ObjectName + " использован.");
                        if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + characteristicsHero.SlotsDoorUnlockingObjects[index].ObjectName + " used.");
                        characteristicsHero.ElementTransferForUO(characteristicsHero.SlotsDoorUnlockingObjects[index]);
                        openRoom.AddToListOR(currentRoom.TransitionNumber);
                        openRoom.SaveList();
                        ForLogDisplay = true;
                        indexA = currentRoom.DirectionOfMovementInTheRoom.Length;
                    }
                }
            }
        }
        if (ForLogDisplay == false) OutputDialogueOfInteractionWithTheSubject("нельзя использовать");
    }

    void CheckWhetherItIsPossibleToExamineAnItem(string KeyOne)
    {
        bool SOD = false;
        for (int index = 0; index < characteristicsHero.SlotsDoorUnlockingObjects.Count; index++)
        {
            if (characteristicsHero.SlotsDoorUnlockingObjects[index].ObjectKey == KeyOne)
            {
                inputManager.DisplayTheEnteredText(CharacterNameOutput + characteristicsHero.SlotsDoorUnlockingObjects[index].DescriptionForExamine);
                index = characteristicsHero.SlotsDoorUnlockingObjects.Count;
                SOD = true;
            }
        }
        if (SOD == false) OutputDialogueOfInteractionWithTheSubject("нет предмета в инвентаре");
    }

    void OutputDialogueOfInteractionWithTheSubject(string Dialog)
    {
        if (Dialog == "нет предмета в комнате 1")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + "у меня нет этого.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + "i do not have this.");
        }
        if (Dialog == "нельзя взять")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + "я не могу найти это в комнате.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + "i can not find it in the room.");
        }
        if (Dialog == "нет предмета в инвентаре")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + "я бы хотел изучить это, но у меня не тэтого.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + "i would like to study this, but I do not have it.");
        }
        if (Dialog == "подобран")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + currentRoom.ObjectsInTheRoom[0].ObjectName + " подобран.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + currentRoom.ObjectsInTheRoom[0].ObjectName + " picked up.");
        }
        if (Dialog == "нет предмета в комнате 2")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + "Жалко что в комнате нет предметов, чтобы я мог взять их.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + "It’s a pity that there are no objects in the room so that I can take them.");
        }
        if (Dialog == "нельзя использовать")
        {
            if (Language == "ru") inputManager.DisplayTheEnteredText(CharacterNameOutput + " я не могу это сделать.");
            if (Language == "en") inputManager.DisplayTheEnteredText(CharacterNameOutput + " i can not do it.");
        }
    }

    public void KeyCheckForToDrinkPotions(string key, string Potion)
    {
        if (key == "выпить" && Potion == "зелье" ||
            key == "drink" && Potion == "potion")
        {
            if (battleScript == true) battleScript.InputActions("зелье", "", "");
            else characteristicsHero.DrinkAPotion();
        }
    }

    public void AcceptInputPlayerName(string Key, string KeyOne, string KeyTwo)
    {
        if (Key == "меня" && KeyOne == "зовут" && KeyTwo != "" || Key == "my" && KeyOne == "name" && KeyTwo != "")
        {
            characterCustomization.Name = KeyTwo;
            characterCustomization.DataTransferAndSaveData();
            currentRoom = ExitDictionary[KeyOne];
            inputManager.DisplaysRoomInformationOnTheDisplay();
        }
        else OutputDialogCreationCharacter("как вас зовут");
    }

    void OutputDialogCreationCharacter(string Dialog)
    {
        if (Dialog == "как вас зовут")
        {
            if (Language == "ru") inputManager.logText = "хорошо, я повторю как вас зовут?";
            if (Language == "en") inputManager.logText = "ok, i will repeat what is your name?";
        }       
    }

    public void CheckingTheKeyToSelectTheCharacteristicsOfTheHero(string Key, string KeyOne)
    {
        if (Key == "я" || Key == "i")
        {
            if (ExitDictionary.ContainsKey(KeyOne))
            {
                currentRoom = ExitDictionary[KeyOne];
                inputManager.DisplaysRoomInformationOnTheDisplay();
                characterCustomization.SwitchingBetweenCustomization(KeyOne);
            }
        }        
    }

    public void KeyCheckForToBattle(string key, string KeyOne, string KeyTwo)
    {
        if (key == "ударить" && KeyTwo == "мечом" ||
            key == "поставить" && KeyTwo == "блок" ||
            key == "воспользоваться" && KeyTwo == "магией" ||
            key == "натянуть" && KeyTwo == "тетиву" ||
            key == "sword" && KeyTwo == "attack" ||
            key == "put" && KeyTwo == "block" ||
            key == "attack" && KeyOne == "with" && KeyTwo == "magic" ||
            key == "pull" && KeyOne == "the" && KeyTwo == "bow")
        {
            inputManager.DisplaysRoomInformationOnTheDisplay();
            battleScript.InputActions(key, KeyOne, KeyTwo);
        }
        else
        {
            battleScript.SDFASF();
            battleScript.IfThePlayerHasNotEnteredTheSecondKey();
        }
    }

    public void ClearExits()
    {
        ExitDictionary.Clear();
    }

    public void IfTheWrongKeyThenUseTheAlternative()
    {
        if (currentRoom.WhatIsTheRoomUsedFor == "Class selection")
        {
            DalogsIfTheEnteredKeyDidNotFit();
            NumberDialogForName++;
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "RoomBattlе")
        {
            if (Language == "ru") inputManager.logText = " вы промахнулись...";
            if (Language == "en") inputManager.logText = " you missed...";
        }
    }

    void DalogsIfTheEnteredKeyDidNotFit()
    {
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName == 0)
        {
            if (Language == "ru") inputManager.logText = "Разве я у вас это спросил?";
            if (Language == "en") inputManager.logText = "Did I ask you this?";
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName == 1)
        {
            if (Language == "ru") inputManager.logText = "ВЫ издеваетесь?";
            if (Language == "en") inputManager.logText = "Are you kidding me?";
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName == 2)
        {
            if (Language == "ru") inputManager.logText = "ЛАДНО, вот же прислали мне авантюриста. как вас зовут?";
            if (Language == "en") inputManager.logText = "OK, they sent me an adventurer. what is your name?";
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName == 3)
        {
            if (Language == "ru") inputManager.logText = "Ты можешь что нибудь сказать, а не просто смотреть на меня";
            if (Language == "en") inputManager.logText = "You can say something, and not just look at me";
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName == 4)
        {
            if (Language == "ru") inputManager.logText = "Хорошо, раз гильдия мне не прислала нормального авантюриста, придется работать с тобой.";
            if (Language == "en") inputManager.logText = "Well, since the guild didn’t send me a normal adventurer, i’ll have to work with you.";
        }
        if (currentRoom.WhatIsTheRoomUsedFor == "Name" && NumberDialogForName > 4)
        {
            if (Language == "ru") inputManager.logText = "...";
            else inputManager.logText = "...";
        }
    }

    public void GoToTheMainMenu()
    {
        attenuation.TheAppearanceOfObject("Menu");
    }

    public void OnOrOffRoomName()
    {
        if (RoomName == true)
        {
            if (SetActivTRN.activeInHierarchy) SetActivTRN.SetActive(false);
            else SetActivTRN.SetActive(true);
        }
    }
}