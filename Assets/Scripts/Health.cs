using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Settings")]
    public bool destroyOnDeath = true; // enemies
    public bool isPlayer = false;

    public float CurrentHealth => currentHealth; // lectura pública

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log($"{gameObject.name} took {amount} damage. Remaining health: {currentHealth}");

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");

        if (isPlayer)
        {
            Debug.Log("💀 Player died. Implement Game Over here.");
        }
        else if (destroyOnDeath)
        {
            Destroy(gameObject);
        }
    }
}
