using UnityEngine;

public class DroneSpawnManager : MonoBehaviour
{
    public GameObject dronePrefab;  // Reference to the Drone prefab
    public float spawnDistance = 5f; // How close or far the drones spawn from the player
    public float spawnHeight = 5f;   // The height where the drones will spawn

    private Transform player;  // Reference to the player's transform

    // Start is called before the first frame update
    void Start()
    {
        // Find the player in the scene
        player = GameObject.FindWithTag("Player").transform;

        // Start spawning drones repeatedly
        InvokeRepeating("SpawnDrone", 2f, 3f); // Spawn every 3 seconds after 2 seconds delay
    }

    // Spawn drone near the player
    void SpawnDrone()
    {
        // Ensure the player exists
        if (player != null)
        {
            // Spawn drone at a random position close to the player
            float spawnX = player.position.x + Random.Range(-spawnDistance, spawnDistance); // Random spawn X position near player
            Vector3 spawnPos = new Vector3(spawnX, spawnHeight, player.position.z); // Keep Z the same, modify Y for height

            // Instantiate the drone at the random spawn position
            Instantiate(dronePrefab, spawnPos, Quaternion.identity);
        }
    }
}
