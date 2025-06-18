using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class SettingsInspector : Editor
{
    private string[] listSettings;
    private string[] listName;
    private int indexSelected;

    public override void OnInspectorGUI()
    {
        listSettings = AssetDatabase.FindAssets("t:Settings");
        listName = new string[listSettings.Length];

        EditorGUILayout.HelpBox("This is a Chosse Settings", MessageType.Info);

        for (int i = 0; i < listSettings.Length; i++)
        {
            Settings settings = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(listSettings[i]));
            listName[i] = settings.name;
        }

        var newSelectedBinding = EditorGUILayout.Popup("Settings", indexSelected, listName);
        if (newSelectedBinding != indexSelected)
        {
            Settings settings = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(listSettings[newSelectedBinding]));
            Enemy enemy = (Enemy)target;
            SetUp(enemy, settings);
            indexSelected = newSelectedBinding;
        }
    }

    /// <summary>
    /// Установка новых значений
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="settings"></param>
    public void SetUp(Enemy enemy, Settings settings)
    {
        enemy.transform.localScale = settings.Size;

        Renderer renderer = enemy.GetComponent<Renderer>(); // запрашиваем компонент Renderer 
        if (renderer != null) // если он не пустой то 
        {
            renderer.sharedMaterial.color = settings.Color; // изменяем его цвет на выбраный  
        }
    }
}



