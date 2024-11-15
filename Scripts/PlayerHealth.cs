using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement; // For scene management (e.g., restart)

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health
    public float currentHealth; // Current health

    public TextMeshProUGUI healthText; // UI element to display health

    private void Start()
    {
        // Initialize health to maxHealth at the start
        currentHealth = maxHealth;

        // Update the health display
        UpdateHealthDisplay();
    }

    // Function to reduce health when taking damage
    public void TakeDamage(float damageAmount)
    {
        // Reduce health by the damage amount
        currentHealth -= damageAmount;

        // Clamp health to prevent it from going below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health display
        UpdateHealthDisplay();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to update the health display UI
    private void UpdateHealthDisplay()
    {
        // Update the UI text to show current health
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    // Function to handle player's death and transition to the DeathMenu scene
    private void Die()
    {
        Debug.Log("Player has died!");

        // Pause the game
        Time.timeScale = 0f; // Stops the game

        // Load the DeathMenu scene
        SceneManager.LoadScene("DeathMenu");
    }

    // Function to restart the game (call this from a UI button)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    // Function to quit the game (call this from a UI button)
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Exits the application
    }
}
