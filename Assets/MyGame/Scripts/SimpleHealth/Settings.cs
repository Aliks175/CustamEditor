using UnityEngine;

[CreateAssetMenu(fileName = "Simple", menuName = "Settings/Simple")]
public class Settings : ScriptableObject
{
    public Vector3 Size = Vector3.one;
    public Color Color = Color.white;
}
