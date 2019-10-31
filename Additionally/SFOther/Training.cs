using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    public Text Label;
    public Text TaskZero;
    public Text TaskOne;
    public Text TaskTwo;
    public Text TaskThree;
    public Text TaskFour;

    string LanguageFT;

    public BattleScript battleScript;

    private void Start()
    {
        LanguageFT = battleScript.localization.Language;
        if (LanguageFT == "ru") TaskLanguage(LanguageFT);
        if (LanguageFT == "en") TaskLanguage(LanguageFT);
    }

    private void Update()
    {
        if (battleScript.NumberOfActionsZero == 1)
        {
            battleScript.NumberOfActionsZero++;
            if (LanguageFT == "ru") TaskZero.text = "Ударить мечом  1/1";
            if (LanguageFT == "en") TaskZero.text = "Hit with a sword  1/1";
        }
        if (battleScript.NumberOfActionsOne == 1)
        {
            battleScript.NumberOfActionsOne++;
            if (LanguageFT == "ru") TaskOne.text = "Поставить блок  1/1";
            if (LanguageFT == "en") TaskOne.text = "Put block  1/1";
        }
        if (battleScript.NumberOfActionsTwo == 1)
        {
            battleScript.NumberOfActionsTwo++;
            if (LanguageFT == "ru") TaskTwo.text = "Воспользоваться магией  1/1";
            if (LanguageFT == "en") TaskTwo.text = "Use magic  1/1";
        }
        if (battleScript.NumberOfActionsThree == 1)
        {
            battleScript.NumberOfActionsThree++;
            if (LanguageFT == "ru") TaskThree.text = "Натянуть тетиву 1/1";
            if (LanguageFT == "en") TaskThree.text = "Pull the bow 1/1";
        }
        if (battleScript.NumberOfActionsFive == 1)
        {
            battleScript.NumberOfActionsFive++;
            if (LanguageFT == "ru") TaskFour.text = "Выпить зелье  1/1";
            if (LanguageFT == "en") TaskFour.text = "Drink a potion  1/1";
        }
        battleScript.CurrentHealthEnemy = battleScript.FullHealthEnemy;
        ForTraining();
    }

    void ForTraining()
    {
        if (battleScript.roomManager.currentRoom.WhatIsTheRoomUsedFor == "обучение" &&
             battleScript.NumberOfActionsZero > 0 &&
             battleScript.NumberOfActionsOne > 0 &&
             battleScript.NumberOfActionsTwo > 0 &&
             battleScript.NumberOfActionsThree > 0 &&
             battleScript.NumberOfActionsFive > 0) battleScript.roomManager.attenuation.TheAppearanceOfObject("Menu");
    }

    void TaskLanguage(string Language)
    {
        if (Language == "ru")
        {
            Label.text = "Задание: ";
            TaskZero.text = "Ударить мечом  1/0";
            TaskOne.text = "Поставить блок  1/0";
            TaskTwo.text = "Воспользоваться магией  1/0";
            TaskThree.text = "Натянуть тетиву 1/0";
            TaskFour.text = "Выпить зелье  1/0";
        }

        if (Language == "en")
        {
            Label.text = "Task: ";
            TaskZero.text = "Hit with a sword 1/0";
            TaskOne.text = "Put block 1/0";
            TaskTwo.text = "Use magic 1/0";
            TaskThree.text = "Pull the bow 1/0";
            TaskFour.text = "Drink a potion 1/0";
        }
    }
}