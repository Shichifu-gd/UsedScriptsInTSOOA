using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum AltarOrTrapWeaponTypeList
    {
        Altar,
        Trap
    }

    public enum ItemTypeList
    {
        buff,
        debuff
    }

    public string ItemId;
    public string ItemName;
    public string ItemDescription;

    public string FoeName;
    public string FoeHealthFull;
    public string FoeHealthCurrent;

    public AltarOrTrapWeaponTypeList AltarOrTrap;
    public ItemTypeList ItemType;

    public string PathPrefab;
}