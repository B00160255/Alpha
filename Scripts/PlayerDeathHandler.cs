using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PlayerDeathHandler : MonoBehaviour
{
    // This method will be called when the player dies
    public void HandlePlayerDeath()
    {
        Debug.Log("Player has died!");

        // Load the "DeathMenu" scene
        SceneManager.LoadScene("DeathMenu");
    }
}
