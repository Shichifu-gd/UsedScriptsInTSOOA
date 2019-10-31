using UnityEngine.UI;
using UnityEngine;

public class AcceptsTextInput : MonoBehaviour
{
    public InputField InputField;
    InputManager inputManager;
    bool WhetherTheTextPassedTheTest = false;

    string[] ArrayWithSplitText;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        InputField.onEndEdit.AddListener(AcceptsTheInputTextAndComparesItWithTheKeysInTheList);
    }

    /* преобразует в строчные символы  
     * разделят вводимое на ячейки, и добавляет в массив
     * проверяет вводимый текст на наличие ключа, для последовательного использования */
    void AcceptsTheInputTextAndComparesItWithTheKeysInTheList(string userInput)
    {
        userInput = userInput.ToLower();
        char[] SplitsInputTextIntoParts = { ' ' };
        ArrayWithSplitText = userInput.Split(SplitsInputTextIntoParts);
        CheckTheSimilarityInputTextInTheKeyList();
        if (WhetherTheTextPassedTheTest == false) testIfThereIsNoKey();
        TakesTheInputText();
    }

    void CheckTheSimilarityInputTextInTheKeyList()
    {
        for (int i = 0; i < inputManager.GeneralListOfKeys.Count; i++)
        {
            AcceptsInputKey acceptsInputKey = inputManager.GeneralListOfKeys[i];
            if (acceptsInputKey.TypedKeyword == ArrayWithSplitText[0])
            {
                acceptsInputKey.RespondsToTextInput(inputManager, ArrayWithSplitText);
                WhetherTheTextPassedTheTest = true;
            }
        }
    }

    void testIfThereIsNoKey()
    {
        inputManager.IfTheWrongKey();
    }

    /* обновляет журнал
     * после активирует вводимый ключ, если он есть
     * и чистит поле ввода */
    void TakesTheInputText()
    {
        inputManager.DisplaysTheEnteredText();
        InputField.ActivateInputField();
        InputField.text = null;
        WhetherTheTextPassedTheTest = false;
    }
}