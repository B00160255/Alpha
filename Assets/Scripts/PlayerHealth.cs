using UnityEngine;
using TMPro; // For TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // maximum health
    public float currentHealth; // current health

    public TextMeshProUGUI healthText; // UI element to display health

    private void Start()
    {
        // initialize health to maxHealth at the start
        currentHealth = maxHealth;

        // update the health display
        UpdateHealthDisplay();
    }

    // Function to reduce health when taking damage
    public void TakeDamage(float damageAmount)
    {
        // reduce health by the damage amount
        currentHealth -= damageAmount;

        // clamp health to prevent it from going below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // update the health display
        UpdateHealthDisplay();

        // check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to update the health display UI
    private void UpdateHealthDisplay()
    {
        // update the UI text to show current health
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    // Function to handle player's death
    private void Die()
    {
        Debug.Log("Player has died!");
        // handle player death (e.g., game over logic)
    }
}
