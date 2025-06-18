using UnityEditor;
using UnityEngine;

public class Test : EditorWindow
{
    private Color _color;

    [MenuItem("Tools/Test/Show ")]
    public static void ShowWindow()
    {
        GetWindow<Test>("Example");
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
