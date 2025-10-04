using UnityEngine;

[CreateAssetMenu(menuName = "Magic/Spell")]
public class Spell : ScriptableObject
{
    [Header("Components of the spell")]
    public ElementSO element;      // <--- debe coincidir con ElementSO
    public ExecutionSO execution;  // <--- debe coincidir con ExecutionSO
    public ModifierSO modifier;    // <--- debe coincidir con ModifierSO

    [Header("Calculated stats (readonly)")]
    public float damage;
    public float speed;
    public float manaCost;
    public float size;

    public void Initialize()
    {
        if (element == null || execution == null || modifier == null)
        {
            Debug.LogError("? Spell incomplete: missing Element, Execution, or Modifier.");
            return;
        }

        damage = execution.baseDamage * modifier.damageMultiplier;
        speed = execution.baseSpeed * modifier.speedMultiplier;
        manaCost = execution.baseManaCost * modifier.manaCostMultiplier;
        size = execution.baseSize * modifier.sizeMultiplier;

        Debug.Log($"? Spell initialized: {element.elementName} + {execution.executionName}");
    }
}
