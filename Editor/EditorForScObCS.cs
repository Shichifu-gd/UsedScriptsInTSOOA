using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScObHeroStory))]
public class EditorForScObCS : Editor
{
    private ScObHeroStory scOb;
    private void Awake()
    {
        scOb = (ScObHeroStory)target;
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