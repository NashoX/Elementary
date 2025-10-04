using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSlide : MonoBehaviour
{
    public Health playerHealth; // referencia al script Health del jugador
    public Slider healthSlider;
    public TMP_Text healthText; // opcional, para mostrar "50 / 100"

    void Update()
    {
        if (playerHealth == null) return;

        float currentHealth = playerHealth.CurrentHealth;

        healthSlider.value = currentHealth / playerHealth.maxHealth;

        if (healthText != null)
            healthText.text = $"{currentHealth} / {playerHealth.maxHealth}";
    }
}
