using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InputKey/Menu")]
public class KeyForMenu : AcceptsInputKey
{
    bool SwitchFKM;

    public override void RespondsToTextInput(InputManager inputManager, string[] PrintedText)
    {
        SwitchFKM = false;
        if (PrintedText.Length == 1)
        {
            if (PrintedText[0] == "инф" || PrintedText[0] == "информация" || PrintedText[0] == "inf" || PrintedText[0] == "information") inputManager.DisableOrEnable(PrintedText[0]);
            if (PrintedText[0] == "загрузить" || PrintedText[0] == "loading") inputManager.menu.AcceptsAndRedirects(PrintedText[0], "", "");
            if (PrintedText[0] == "настройки" || PrintedText[0] == "settings") inputManager.menu.AcceptsAndRedirects(PrintedText[0], "", "");
            if (PrintedText[0] == "назад" || PrintedText[0] == "back") inputManager.menu.AcceptsAndRedirects(PrintedText[0], "", "");
            if (PrintedText[0] == "выйти" || PrintedText[0] == "exit") inputManager.AcceptsAKeyForExit(PrintedText[0]);
            if (PrintedText[0] == "тсл") inputManager.menu.AcceptsAndRedirects(PrintedText[0], "", "");
            SwitchFKM = true;
        }
        if (PrintedText.Length == 2)
        {
            if (PrintedText[0] == "новая" || PrintedText[0] == "new") inputManager.menu.AcceptsAndRedirects(PrintedText[0], PrintedText[1], "");
            if (PrintedText[0] == "русский" || PrintedText[0] == "english") if (PrintedText.Length > 1) inputManager.menu.Language(PrintedText[0], PrintedText[1]);
            if (PrintedText[0] == "главное" && PrintedText[1] == "меню" || PrintedText[0] == "main" && PrintedText[1] == "menu") inputManager.roomManager.GoToTheMainMenu();
            if (PrintedText[0] == "пэр" || PrintedText[0] == "fsm") if (PrintedText.Length > 1) inputManager.menu.AcceptsAndRedirectsForSettingsFS(PrintedText[0], PrintedText[1]);
            SwitchFKM = true;
        }
        if (PrintedText.Length == 3)
        {
            if (PrintedText[0] == "разришение" || PrintedText[0] == "screen") inputManager.menu.AcceptsAndRedirectsForSettingsR(PrintedText[0], PrintedText[1], PrintedText[2]);
            if (PrintedText[0] == "громкость" && PrintedText[2] != "" || PrintedText[0] == "sound" && PrintedText[2] != "") inputManager.menu.SettingSoundVolume(PrintedText[2]);
            SwitchFKM = true;
        }
        if (SwitchFKM == false) inputManager.IfTheWrongKey();
    }
}