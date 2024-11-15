using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // health for the enemy drone
    public float health = 100f;

    // movement speeds for chasing and patrolling
    public float chaseSpeed = 5f;

    // detection range and attack range for the drone
    public float detectionRange = 90f;
    public float attackRange = 2f;

    // damage settings (how much damage per second and how often)
    public float damageAmount = 1f;
    public float damageInterval = 1f;
    private float nextDamageTime = 0f;

    // reference to the player and player health script
    private Transform player;
    private PlayerHealth playerHealth;

    // navmesh obstacle component to stop movement during attack
    private NavMeshObstacle navObstacle;

    // flag to check if the drone is attacking
    private bool isAttacking = false;

    private void Start()
    {
        // find the player in the scene and get their health script
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();

        // get the navmesh obstacle component and make sure carving is enabled
        navObstacle = GetComponent<NavMeshObstacle>();
        if (navObstacle != null)
        {
            navObstacle.carving = true;
        }
    }

    private void Update()
    {
        // calculate distance between the drone and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // if the player is within detection range, chase them
        if (distanceToPlayer < detectionRange)
        {
            ChasePlayer(distanceToPlayer);

            // if the player is within attack range, start attacking
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }
        else
        {
            // if the player is out of range, stop chasing
            StopChasing();
        }
    }

    // start chasing the player
    private void ChasePlayer(float distanceToPlayer)
    {
        // only move towards the player if not attacking
        if (!isAttacking)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);

            // enable navmesh obstacle for movement
            if (navObstacle != null)
            {
                navObstacle.enabled = true;
            }
        }
    }

    // stop chasing the player and stop movement
    private void StopChasing()
    {
        // disable navmesh obstacle to stop the drone from moving
        if (navObstacle != null)
        {
            navObstacle.enabled = false;
        }
    }

    // attack the player when within range
    private void AttackPlayer()
    {
        // stop moving while attacking by disabling the navmesh obstacle
        if (navObstacle != null)
        {
            navObstacle.enabled = false; // prevent drone from moving while attacking
        }

        // apply damage to the player over time
        if (Time.time >= nextDamageTime && playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); // deal damage
            nextDamageTime = Time.time + damageInterval; // set next damage time
        }

        // set flag to true to indicate the drone is attacking
        isAttacking = true;
    }

    // function to take damage
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        // if health is zero or below, destroy the drone
        if (health <= 0)
        {
            Die();
        }
    }

    // function to handle the drone's death
    private void Die()
    {
        Debug.Log("enemy died!");
        Destroy(gameObject); // destroy the drone
    }

    // call this function to stop attacking and allow movement again
    public void StopAttacking()
    {
        isAttacking = false; // drone is no longer attacking

        // re-enable navmesh obstacle to allow movement
        if (navObstacle != null)
        {
            navObstacle.enabled = true;
        }
    }
}
