using UnityEngine.UI;
using UnityEngine;

public class SDialForBattle : MonoBehaviour
{
    int IndexForCleaning;

    float TimeFD;
    float ColorA = 1f;

    string SelectedDialogue;

    bool SwitchForCleaning = true;
    bool IsItPossibleToChangeTheTextBox;

    public Text[] ArrayDialoguesOfFear;

    private static System.Random RandomForDialoguesOfFear = new System.Random();
    private static System.Random RandomForArrayDialoguesOfFear = new System.Random();

    private void FixedUpdate()
    {
        if (TimeFD < 3) TimeFD += 0.3f * Time.deltaTime;
        if (TimeFD >= 3)
        {
            if (SwitchForCleaning == true)
            {
                CleansText();
                SwitchForCleaning = false;
            }
            if (IsItPossibleToChangeTheTextBox == true) ChangeTheTextBox();
            else
            {
                TimeFD = -2;
                SwitchForCleaning = true;
            }
        }
    }

    void CleansText()
    {
        IndexForCleaning = RandomForArrayDialoguesOfFear.Next(0, ArrayDialoguesOfFear.Length);
        if (ArrayDialoguesOfFear[IndexForCleaning].text == "" ||
            ArrayDialoguesOfFear[IndexForCleaning].text == " ") IsItPossibleToChangeTheTextBox = false;
        else IsItPossibleToChangeTheTextBox = true;
    }

    void ChangeTheTextBox()
    {
        ColorA -= 0.3f * Time.deltaTime;
        ColorA = (float)System.Math.Round(ColorA, 2);
        ArrayDialoguesOfFear[IndexForCleaning].GetComponent<Text>().color = new Color(255f, 255f, 255f, ColorA);
        if (ColorA <= 0)
        {
            ArrayDialoguesOfFear[IndexForCleaning].text = "";
            ColorA = 1;
            ArrayDialoguesOfFear[IndexForCleaning].GetComponent<Text>().color = new Color(255f, 255f, 255f, ColorA);
            TimeFD = 0;
            IsItPossibleToChangeTheTextBox = false;
            SwitchForCleaning = true;
        }
    }

    public void SwitchingBetweenLanguagesForDialoguesOfFear(string Language)
    {
        if (Language == "ru") DialoguesOfFearRu();
        else DialoguesOfFearEN();
        RandomlySelectsAFieldForEnteringText();
    }

    void DialoguesOfFearRu()
    {
        int DialogueNumber = RandomForDialoguesOfFear.Next(0, 7);
        if (DialogueNumber == 0) SelectedDialogue = "Мне страшно";
        if (DialogueNumber == 1) SelectedDialogue = "не надо";
        if (DialogueNumber == 2) SelectedDialogue = "(плачет)";
        if (DialogueNumber == 3) SelectedDialogue = "Уйди";
        if (DialogueNumber == 4) SelectedDialogue = "Мне БОЛЬНО уходи";
        if (DialogueNumber == 5) SelectedDialogue = "неТ НЕТ Не НаДо";
        if (DialogueNumber == 6) SelectedDialogue = "Мамочка (плачет)";
    }

    void DialoguesOfFearEN()
    {
        int DialogueNumber = RandomForDialoguesOfFear.Next(0, 7);
        if (DialogueNumber == 0) SelectedDialogue = "I'm scared";
        if (DialogueNumber == 1) SelectedDialogue = "do not";
        if (DialogueNumber == 2) SelectedDialogue = "(crying)";
        if (DialogueNumber == 3) SelectedDialogue = "Go away";
        if (DialogueNumber == 4) SelectedDialogue = "It HURTS me to leave";
        if (DialogueNumber == 5) SelectedDialogue = "NO NO NO NEED";
        if (DialogueNumber == 6) SelectedDialogue = "Mommy (crying)";
    }

    void RandomlySelectsAFieldForEnteringText()
    {
        int IndexArrayDOF = RandomForArrayDialoguesOfFear.Next(0, ArrayDialoguesOfFear.Length);
        ArrayDialoguesOfFear[IndexArrayDOF].fontSize = Random.Range(20, 27);
        ArrayDialoguesOfFear[IndexArrayDOF].text = SelectedDialogue;
    }
}