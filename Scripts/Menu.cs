using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuCanvas;      // Reference to the Main Menu Canvas
    public GameObject settingsMenuCanvas;  // Reference to the Settings Menu Canvas

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1); 
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    // Open the Settings menu and hide the main menu
    public void OpenSettings()
    {
        mainMenuCanvas.SetActive(false);          // Hide the main menu
        settingsMenuCanvas.SetActive(true);       // Show the settings menu
    }

    // Close the Settings menu and show the main menu
    public void CloseSettings()
    {
        settingsMenuCanvas.SetActive(false);      // Hide the settings menu
        mainMenuCanvas.SetActive(true);           // Show the main menu
    }
}

