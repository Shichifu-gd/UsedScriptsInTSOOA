using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacteristicsHero : MonoBehaviour
{
    public string Name;
    public string Race;
    public string StoryClass;
    public string Class;

    public float FullHealth;
    public float CurrentHealth;
    public float MaxArmor;
    public float MinArmor;
    public float MaxAttack;
    public float MinAttack;
    public float MaxAbility;
    public float MinAbility;
    public float Block;

    public float Head = 20;
    public float CurrentHead;
    public float Body = 50; 
    public float CurrentBody;
    public float LHand = 20;
    public float CurrentLHand;
    public float RHand = 20;
    public float CurrentRHand;
    public float LLeg = 20;
    public float CurrentLLeg;
    public float RLeg = 20;
    public float CurrentRLeg;

    public float PotionX;
    public float Regen;
    bool SwitchForRegen = false;
    float IntermediateVariable;

    [HideInInspector]
    public int IndexForUO;

    float bonusMaxArmor = 0;
    float bonusMaxAttack = 0;
    float bonusMaxAbility = 0;

    public InputManager inputManager;
    public GeneralSettings generalSettings;
    public DisplayBattleValues displayBattleValues;
    public SupplementForHeroBody supplementForHero;
    public List<ObjectsAffectingCharacteristic> SlotsActivatedAltars;
    public List<InteractableObject> SlotsDoorUnlockingObjects;
    public List<InteractableObject> SlotForThingsThatWereUsed;

    private void FixedUpdate()
    {
        if (SwitchForRegen == true)
        {
            if (CurrentHealth < FullHealth)
            {
                IntermediateVariable += Regen * Time.deltaTime;
                IntermediateVariable = (float)System.Math.Round(IntermediateVariable, 2);
                CurrentHealth = IntermediateVariable;
                CurrentHealth = (float)System.Math.Round(CurrentHealth, 0);
            }
            if (CurrentHealth > FullHealth)
            {
                CurrentHealth = FullHealth;
                SwitchForRegen = false;
            }
        }
    }
       
    public void LoadCharacteristicsHero()
    {
        InflateList();
        if (inputManager.roomManager.currentRoom.WhatIsTheRoomUsedFor != "обучение")
        {
            if (File.Exists(Application.dataPath + "/data/MaxValue.sav")) LoadMaxCharacteristicsHero();
            if (File.Exists(Application.dataPath + "/data/CurValue.sav")) LoadCurCharacteristicsHero();
            if (File.Exists(Application.dataPath + "/data/InformationHero.sav")) LoadInformationsHeroes();
            if (File.Exists(Application.dataPath + "/data/InvAl.sav")) LoadInventoryOfAltar();
            if (File.Exists(Application.dataPath + "/data/InvUO.sav")) LoadSlotsDoorUnlockingObjects();
            if (File.Exists(Application.dataPath + "/data/TTWU.sav")) LoadSlotForThingsThatWereUsed();
        }
        else ForTraining();
        ActivationOpportunitiesAltar();
    }

    public void ElementTransferForUO(InteractableObject interactableObject)
    {
        for (int index = 0; index < SlotsDoorUnlockingObjects.Count; index++)
        {
            if (interactableObject == SlotsDoorUnlockingObjects[index])
            {
                if (IndexForUO < 15)
                {
                    IndexForUO++;
                    SlotForThingsThatWereUsed[IndexForUO] = SlotsDoorUnlockingObjects[index];
                    SlotsDoorUnlockingObjects[index] = generalSettings.DummyForListUO;
                    SaveSlotForThingsThatWereUsed();
                    SaveSlotsDoorUnlockingObjects();
                }
                if (IndexForUO < 15)
                {
                    IndexForUO = 0;
                    SlotForThingsThatWereUsed[IndexForUO] = SlotsDoorUnlockingObjects[index];
                    SlotsDoorUnlockingObjects[index] = generalSettings.DummyForListUO;
                    SaveSlotForThingsThatWereUsed();
                    SaveSlotsDoorUnlockingObjects();
                }
            }
        }
    }

    public void InflateList()
    {
        for (int indexA = 0; indexA < 2; indexA++)
        {
            SlotsActivatedAltars.Add(generalSettings.DummyForListAltars);
        }

        for (int indexB = 0; indexB < 15; indexB++)
        {
            SlotsDoorUnlockingObjects.Add(generalSettings.DummyForListUO);
        }

        for (int indexC = 0; indexC < 15; indexC++)
        {
            SlotForThingsThatWereUsed.Add(generalSettings.DummyForListUO);
        }
    }

    public void LoadMaxCharacteristicsHero()
    {
        float[] MaxValuesHero = SaveAndLoadDataHero.LoadMaximumValuesOfTheHero();
        FullHealth = MaxValuesHero[0];
        MaxAttack = MaxValuesHero[1];
        MinAttack = MaxValuesHero[2];
        MaxArmor = MaxValuesHero[3];
        MinArmor = MaxValuesHero[4];
        MaxAbility = MaxValuesHero[5];
        MinAbility = MaxValuesHero[6];
        Block = MaxValuesHero[7];
        Regen = MaxValuesHero[8];
    }

    public void LoadCurCharacteristicsHero()
    {
        float[] CurrentValuesHero = SaveAndLoadDataHero.LoadCurrentValuesOfTheHero();
        CurrentHealth = CurrentValuesHero[0];
        CurrentHead = CurrentValuesHero[1];
        CurrentBody = CurrentValuesHero[2];
        CurrentLHand = CurrentValuesHero[3];
        CurrentRHand = CurrentValuesHero[4];
        CurrentLLeg = CurrentValuesHero[5];
        CurrentRLeg = CurrentValuesHero[6];
        PotionX = CurrentValuesHero[7];
    }

    public void LoadInformationsHeroes()
    {
        string[] InformationHero = SaveAndLoadDataHero.LoadInfoAboutHero();
        Name = InformationHero[0];
        Race = InformationHero[1];
        StoryClass = InformationHero[2];
        Class = InformationHero[3];
    }

    public void LoadInventoryOfAltar()
    {
        string[] Altar = SaveAndLoadInventory.LoadDataToInventoryAltar();
        string LocalPathZero = "ScriptableObjects/" + generalSettings.Language + "/Objects affecting characteristic/Altar/Buff/" + Altar[0];
        string LocalPathOne = "ScriptableObjects/" + generalSettings.Language + "/Objects affecting characteristic/Altar/Buff/" + Altar[1];
        SlotsActivatedAltars[0] = Resources.Load<ObjectsAffectingCharacteristic>(LocalPathZero);
        SlotsActivatedAltars[1] = Resources.Load<ObjectsAffectingCharacteristic>(LocalPathOne);
    }

    public void LoadSlotsDoorUnlockingObjects()
    {
        string[] UnlockingObjects = SaveAndLoadInventory.LoadUnlockingObjects();
        for (int index = 0; index < SlotsDoorUnlockingObjects.Count; index++)
        {
            string LocalPath = "ScriptableObjects/" + generalSettings.Language + "/Items/" + UnlockingObjects[index];
            SlotsDoorUnlockingObjects[index] = Resources.Load<InteractableObject>(LocalPath);
        }
    }

    public void LoadSlotForThingsThatWereUsed()
    {
        if (File.Exists(Application.dataPath + "/data/ii.sav"))
        {
            int[] indexForUO = SaveAndLoadLanguage.LoadIndexForUO();
            IndexForUO = indexForUO[0];
        }
        string[] TTWU = SaveAndLoadInventory.LoadTTWU();
        for (int index = 0; index < 15; index++)
        {
            string LocalPath = "ScriptableObjects/" + generalSettings.Language + "/Items/" + TTWU[index];
            SlotForThingsThatWereUsed[index] = Resources.Load<InteractableObject>(LocalPath);
        }
    }

    public void ActivationOpportunitiesAltar()
    {
        bonusMaxArmor = 0;
        bonusMaxAttack = 0;
        bonusMaxAbility = 0;

        for (int index = 0; index < 2; index++)
        {
            FullHealth = FullHealth + SlotsActivatedAltars[index].addsHealth;
            CurrentHealth = CurrentHealth + SlotsActivatedAltars[index].addsHealth;
            MaxArmor = MaxArmor + SlotsActivatedAltars[index].addsProtection;
            MaxAttack = MaxAttack + SlotsActivatedAltars[index].addsDamage;
            MaxAbility = MaxAbility + SlotsActivatedAltars[index].addsMagicDamage;

            bonusMaxArmor = bonusMaxArmor + SlotsActivatedAltars[index].addsProtection;
            bonusMaxAttack = bonusMaxAttack + SlotsActivatedAltars[index].addsDamage;
            bonusMaxAbility = bonusMaxAbility + SlotsActivatedAltars[index].addsMagicDamage;
        }
        if (displayBattleValues == true)
        {
            displayBattleValues.LoadingAltarValue(bonusMaxArmor, bonusMaxAttack, bonusMaxAbility);
            displayBattleValues.ADDTextHeroName();
        }
    }

    public void ActivationOpportunitiesAltarForSave()
    {
        bonusMaxArmor = 0;
        bonusMaxAttack = 0;
        bonusMaxAbility = 0;

        for (int index = 0; index < 2; index++)
        {
            FullHealth = FullHealth - SlotsActivatedAltars[index].addsHealth;
            CurrentHealth = CurrentHealth - SlotsActivatedAltars[index].addsHealth;
            MaxArmor = MaxArmor - SlotsActivatedAltars[index].addsProtection;
            MaxAttack = MaxAttack - SlotsActivatedAltars[index].addsDamage;
            MaxAbility = MaxAbility - SlotsActivatedAltars[index].addsMagicDamage;

            bonusMaxArmor = bonusMaxArmor - SlotsActivatedAltars[index].addsProtection;
            bonusMaxAttack = bonusMaxAttack - SlotsActivatedAltars[index].addsDamage;
            bonusMaxAbility = bonusMaxAbility - SlotsActivatedAltars[index].addsMagicDamage;
        }
        if (displayBattleValues == true) displayBattleValues.LoadingAltarValue(bonusMaxArmor, bonusMaxAttack, bonusMaxAbility);
    }

    public void ClianingList()
    {
        for (int indexA = 0; indexA < 2; indexA++)
        {
            SlotsActivatedAltars[indexA] = generalSettings.DummyForListAltars;
        }

        for (int indexB = 0; indexB < 15; indexB++)
        {
            SlotsDoorUnlockingObjects[indexB] = generalSettings.DummyForListUO;
        }

        for (int indexC = 0; indexC < 15; indexC++)
        {
            SlotForThingsThatWereUsed[indexC] = generalSettings.DummyForListUO;
        }
    }

    public void DrinkAPotion()
    {
        if (PotionX > 0)
        {
            if (CurrentHealth >= FullHealth) OutputOutADialogueOfPotion("полное здоровье");
            else
            {
                OutputOutADialogueOfPotion("сделать глоток");
                if (CurrentHealth >= FullHealth) OutputOutADialogueOfPotion("здоровье восстановлено");
                else OutputOutADialogueOfPotion("восстановление здоровья");
                if (PotionX == 0) OutputOutADialogueOfPotion("пузырек опустошен");
            }
            if (CurrentHealth < FullHealth)
            {
                PotionX--;
                ExposureToPotion();
                supplementForHero.BodyRecovery();
            }
        }
        else OutputOutADialogueOfPotion("пузырек пуст");
    }

    void OutputOutADialogueOfPotion(string dialog)
    {
        if (dialog == "полное здоровье")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "мое тело не повреждено, не буду тратить драгоценное зелье.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "my body is not damaged, I will not spend a precious potion.");
        }
        if (dialog == "сделать глоток")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "сделал глоток из пузырька.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "i took a sip from the bubble.");
        }
        if (dialog == "здоровье восстановлено")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "я чувствую как мое тело восстановилось.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "i feel my body recover.");
        }
        if (dialog == "восстановление здоровья")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "я чувствую как мое тело восстанавливается.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "i feel my body recovering.");
        }
        if (dialog == "пузырек опустошен")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "пузырек опустошен.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "the bubble is empty.");
        }
        if (dialog == "пузырек пуст")
        {
            if (generalSettings.Language  == "ru") inputManager.DisplayTheEnteredText(Name + ": " + "пузырек пуст.");
            if (generalSettings.Language  == "en") inputManager.DisplayTheEnteredText(Name + ": " + "the bubble is empty.");
        }
    }

    void ExposureToPotion()
    {
        float TemporaryValue;
        TemporaryValue = Random.Range(50, 70);
        CurrentHealth = CurrentHealth + TemporaryValue;
        if (CurrentHealth >= FullHealth) CurrentHealth = FullHealth;
    }

    public void ForFirstSaveBody()
    {
        CurrentHead = Head;
        CurrentBody = Body;
        CurrentLHand = LHand;
        CurrentRHand = RHand;
        CurrentLLeg = LLeg;
        CurrentRLeg = RLeg;
    }

    public void SaveACH()
    {
        SaveInformationsHeroes();
        SaveMaxCharacteristicsHero();
        SaveCurCharacteristicsHero();
        SaveCurrentInventoryOfAltar();
        SaveSlotsDoorUnlockingObjects();
        SaveSlotForThingsThatWereUsed();
    }

    public void SaveInformationsHeroes()
    {
        SaveAndLoadDataHero.SaveInfoAboutHero(this);
    }

    public void SaveMaxCharacteristicsHero()
    {
        SaveAndLoadDataHero.SaveMaximumValuesOfTheHero(this);
    }

    public void SaveCurCharacteristicsHero()
    {
        SaveAndLoadDataHero.SaveCurrentValuesOfTheHero(this);
    }

    public void SaveCurrentInventoryOfAltar()
    {
        SaveAndLoadInventory.SaveDataToInventoryAltar(this);
    }

    public void SaveSlotsDoorUnlockingObjects()
    {
        SaveAndLoadInventory.SaveUnlockingObjects(this);
    }

    public void SaveSlotForThingsThatWereUsed()
    {
        SaveAndLoadInventory.SaveTTWU(this);
        SaveAndLoadLanguage.SaveIndexForUO(this);
    }

    void ForTraining()
    {
        if (generalSettings.Language == "ru") Name = "Джозеф";
        else Name = "Joseph";
        Class = "Kat";
        FullHealth = 100;
        MaxAttack = 13;
        MinAttack = 0;
        MaxArmor = 5;
        MinArmor = 1;
        MaxAbility = 6;
        MinAbility = 1;
        PotionX = 66;
        CurrentHealth = FullHealth;
        CurrentHead = Head;
        CurrentBody = Body;
        CurrentLHand = LHand;
        CurrentRHand = RHand;
        CurrentLLeg = LLeg;
        CurrentRLeg = RLeg;
    }
}