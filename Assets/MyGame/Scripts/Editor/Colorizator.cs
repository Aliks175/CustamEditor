using UnityEditor;
using UnityEngine;

public class Colorizator : EditorWindow
{
    private Color _color;

    [MenuItem("Tools/ColorChanger _F4")]
    public static void ShowWindow()
    {
        GetWindow<Colorizator>("Color Changer");
    }

    public void OnGUI()
    {
        _color = EditorGUILayout.ColorField("Color",_color);

        if (GUILayout.Button("Colors"))
        {
            foreach (var item in Selection.gameObjects)
            {
               var rend = item.GetComponent<Renderer>();

                if (rend != null)
                {
                    rend.sharedMaterial.color = _color;
                }
            }
        }
    }
}
