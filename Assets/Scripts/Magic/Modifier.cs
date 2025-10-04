using UnityEngine;

[CreateAssetMenu(fileName = "NewModifier", menuName = "Magic/Modifier")]
public class ModifierSO : ScriptableObject
{
    [Header("Modifier Name")]
    public string modifierName;

    [Header("Stat Multipliers")]
    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float manaCostMultiplier = 1f;
    public float sizeMultiplier = 1f;
}
