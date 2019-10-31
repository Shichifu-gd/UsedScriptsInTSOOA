using System.Collections.Generic;
using UnityEngine;

public class LocalizationCheck : MonoBehaviour
{
    public List<AcceptsInputKey> ListOfKeysForTravelForTravelRu;
    public List<AcceptsInputKey> ListOfKeysForBattleForTravelRu;
    public List<AcceptsInputKey> ListOfKeysForInteractiveObjectsForTravelRu;
    public List<AcceptsInputKey> ListOfKeysForTravelForTravelEn;
    public List<AcceptsInputKey> ListOfKeysForBattleForTravelEn;
    public List<AcceptsInputKey> ListOfKeysForInteractiveObjectsForTravelEn;
    public List<AcceptsInputKey> ListOfKeysForBattleForBattleRu;
    public List<AcceptsInputKey> ListOfKeysForBattleForBattleEn;

    public GeneralSettings generalSettings;
    public InputManager inputManager;

    public void StartLocalizationCheck(string information)
    {
        if (information == "travel" && generalSettings.Language == "ru") LoadingTravelListsRu();
        if (information == "travel" && generalSettings.Language == "en") LoadingTravelListsEn();
        if (information == "RoomBattlе" && generalSettings.Language == "ru") LoadingBattleListsRu();
        if (information == "RoomBattlе" && generalSettings.Language == "en") LoadingBattlelListsEn();
        if (information == "обучение" && generalSettings.Language == "ru") LoadingBattleListsRu();
        if (information == "обучение" && generalSettings.Language == "en") LoadingBattlelListsEn();
    }

    void LoadingTravelListsRu()
    {
        for (int a = 0; a < ListOfKeysForTravelForTravelRu.Count; a++)
        {
            inputManager.ListOfKeysForTravel.Add(ListOfKeysForTravelForTravelRu[a]);
        }
        for (int b = 0; b < ListOfKeysForBattleForTravelRu.Count; b++)
        {
            inputManager.ListOfKeysForBattle.Add(ListOfKeysForBattleForTravelRu[b]);
        }
        for (int c = 0; c < ListOfKeysForInteractiveObjectsForTravelRu.Count; c++)
        {
            inputManager.ListOfKeysForInteractiveObjects.Add(ListOfKeysForInteractiveObjectsForTravelRu[c]);
        }
    }

    void LoadingTravelListsEn()
    {
        for (int a = 0; a < ListOfKeysForTravelForTravelEn.Count; a++)
        {
            inputManager.ListOfKeysForTravel.Add(ListOfKeysForTravelForTravelEn[a]);
        }
        for (int b = 0; b < ListOfKeysForBattleForTravelEn.Count; b++)
        {
            inputManager.ListOfKeysForBattle.Add(ListOfKeysForBattleForTravelEn[b]);
        }
        for (int c = 0; c < ListOfKeysForInteractiveObjectsForTravelEn.Count; c++)
        {
            inputManager.ListOfKeysForInteractiveObjects.Add(ListOfKeysForInteractiveObjectsForTravelEn[c]);
        }
    }

    void LoadingBattleListsRu()
    {
        for (int b = 0; b < ListOfKeysForBattleForBattleRu.Count; b++)
        {
            inputManager.ListOfKeysForBattle.Add(ListOfKeysForBattleForBattleRu[b]);
        }
    }
    void LoadingBattlelListsEn()
    {
        for (int b = 0; b < ListOfKeysForBattleForBattleEn.Count; b++)
        {
            inputManager.ListOfKeysForBattle.Add(ListOfKeysForBattleForBattleEn[b]);
        }
    }
}