using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Objects/Altar")]
public class ObjectsAffectingCharacteristic : ScriptableObject
{
    public bool NumberObject = true;

    public string AltarSymbolTranslationDisplay = "name";
    [TextArea] public string Description = "description in room";

    public int addsHealth;
    public int addsProtection;
    public int addsDamage;
    public int addsMagicDamage;

    public InteractingWithAnInteractiveObject[] interactions;
}