using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScObEnemy))]
public class EditorForScObEnemy : Editor
{
    private ScObEnemy characteristicsEnemy;

    private void Awake()
    {
        characteristicsEnemy = (ScObEnemy)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("RemoveAll")) characteristicsEnemy.ClearDatabase();
        if (GUILayout.Button("Remove")) characteristicsEnemy.RemoveCurrentElement();
        if (GUILayout.Button("Add")) characteristicsEnemy.AddElementToList();
        if (GUILayout.Button("<=")) characteristicsEnemy.GetPrevValue();
        if (GUILayout.Button("=>")) characteristicsEnemy.GetNextValue();
        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}