using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class EditorScriptableObjects : Editor
{
    public string text;

    public override void OnInspectorGUI()
    {
        Item ItemCurrent = (Item)target;
        ItemCurrent.ItemName =  EditorGUILayout.TextField("Item name:", ItemCurrent.ItemName);        
        ItemCurrent.AltarOrTrap = (Item.AltarOrTrapWeaponTypeList)EditorGUILayout.EnumPopup("Item type:", ItemCurrent.AltarOrTrap);
        if (ItemCurrent.AltarOrTrap == Item.AltarOrTrapWeaponTypeList.Altar)
        {
            EditorGUILayout.LabelField("Time since start: ");
            text = ItemCurrent.ItemDescription;
            text = GUILayout.TextArea(text);
            ItemCurrent.ItemDescription = text;
            ItemCurrent.ItemType = (Item.ItemTypeList)EditorGUILayout.EnumPopup("Item type:", ItemCurrent.ItemType);
            if (ItemCurrent.ItemType == Item.ItemTypeList.buff)
            {
                ItemCurrent.FoeHealthCurrent = EditorGUILayout.TextField("Item name:", ItemCurrent.FoeHealthCurrent);
                ItemCurrent.FoeHealthFull = EditorGUILayout.TextField("Item name:", ItemCurrent.FoeHealthFull);
            }
            else
            {
                ItemCurrent.FoeName = EditorGUILayout.TextField("Item name:", ItemCurrent.FoeName);
            }
        }
    }
}