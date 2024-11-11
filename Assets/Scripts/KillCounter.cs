using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCounterText; // Reference to the Text UI element
    private int killCount = 0;   // Variable to store the number of kills

    // Method to increase the kill count and update the UI
    public void AddKill()
    {
        killCount++;
        UpdateKillCounterUI();
    }

    // Update the UI text element to display the current kill count
    private void UpdateKillCounterUI()
    {
        killCounterText.text = "Enemies Killed: " + killCount;
    }
}
