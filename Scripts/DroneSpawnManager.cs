using UnityEngine;

public class DroneSpawnManager : MonoBehaviour
{
    public GameObject Drone;  // gets the model for the drone
    public float spawnDistanceMin = 20f; // minimum distance the drones will spawn from the player
    public float spawnDistanceMax = 30f; // maximum distance the drones will spawn from the player
    public float spawnHeightMin = 5f;   // minimum height where the drones will spawn
    public float spawnHeightMax = 10f;  // maximum height where the drones will spawn

    private Transform player;  // gets the players position

    void Start()
    {
        // find the player in the scene
        player = GameObject.FindWithTag("Player").transform;

        // start spawning drones repeatedly
        InvokeRepeating("SpawnDrone", 2f, 3f); // spawn drones every 3 seconds after 2 seconds delay
    }

    // this makes drones spawn near the player
    void SpawnDrone()
    {
        // ensure the player exists
        if (player != null)
        {
            // spawn drones at a random position further away from the player
            float spawnX = player.position.x + Random.Range(spawnDistanceMin, spawnDistanceMax); // random spawn X position away from player
            float spawnY = Random.Range(spawnHeightMin, spawnHeightMax); // random height between the min and max Y range
            float spawnZ = player.position.z; // this keeps Z the same as the player, or modifies it if needed

            // this will create the spawn position
            Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);

            // instantiate the drone at the random spawn position
            Instantiate(Drone, spawnPos, Quaternion.identity);
        }
    }
}
