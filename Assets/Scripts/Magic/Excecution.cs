using UnityEngine;

[CreateAssetMenu(fileName = "NewExecution", menuName = "Magic/Execution")]
public class ExecutionSO : ScriptableObject
{
    [Header("Execution Data")]
    public string executionName;

    [Header("Base Stats")]
    public float baseDamage = 10f;        // Base damage
    public float baseSpeed = 5f;          // Projectile speed
    public float baseSize = 1f;           // Projectile size/scale
    public float baseManaCost = 20f;      // Base mana cost

    [Header("Associated Prefab")]
    public GameObject projectilePrefab;   // Prefab to instantiate
}
