using UnityEngine;

public class OpenWebLink : MonoBehaviour
{
    // URL to open
    public string url = "https://github.com/B00160255/Alpha";

    // Method to open the URL
    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL is empty or invalid.");
        }
    }
}
