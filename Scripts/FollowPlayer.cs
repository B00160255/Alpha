using UnityEngine;  // Add this line at the top to include the UnityEngine namespace

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;  // Reference to the player object
    private Vector3 offset = new Vector3(0, 3, -10);  // The offset distance of the camera from the player

    void Update()
    {
        // Set the camera position to the player's position plus the offset
        transform.position = player.transform.position + offset;
    }
}
