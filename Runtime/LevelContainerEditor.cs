using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelContainer))]
public class LevelContainerEditor : Editor
{
    SerializedProperty levelsProperty;

    private void OnEnable()
    {
        levelsProperty = serializedObject.FindProperty("Levels");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(levelsProperty, new GUIContent("Levels"), true);

        if (GUILayout.Button("Add Level"))
        {
            levelsProperty.arraySize++;
            levelsProperty.GetArrayElementAtIndex(levelsProperty.arraySize - 1).objectReferenceValue = CreateNewLevel();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private LevelData CreateNewLevel()
    {
        LevelData newLevel = CreateInstance<LevelData>();
        newLevel.name = "New Level";

        AssetDatabase.AddObjectToAsset(newLevel, target);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        return newLevel;
    }
}
