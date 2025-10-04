using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "Magic/Element")]
public class ElementSO : ScriptableObject
{
    [Header("Element Data")]
    public string elementName;
    public Color particleColor;   // Particle color for visual effects
}
