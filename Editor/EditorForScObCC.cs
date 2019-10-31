using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScObHeroClass))]
public class EditorForScObCC : Editor
{
    private ScObHeroClass scOb;

    private void Awake()
    {
        scOb = (ScObHeroClass)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("RemoveAll")) scOb.ClearDatabase();
        if (GUILayout.Button("Remove")) scOb.RemoveCurrentElement();
        if (GUILayout.Button("Add")) scOb.AddElementToList();
        if (GUILayout.Button("<=")) scOb.GetPrevValue();
        if (GUILayout.Button("=>")) scOb.GetNextValue();
        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}