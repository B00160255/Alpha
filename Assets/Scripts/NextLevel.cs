using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // next scene for it to load
    public string Level2;

    private void OnTriggerEnter(Collider other)
    {
        // see if the player touched the checkpoint
        if (other.CompareTag("Player"))
        {
            // load next level
            SceneManager.LoadScene("Level2");
        }
    }
}

