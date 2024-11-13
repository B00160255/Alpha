using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float health = 100f;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float hoverHeight = 5f; // New variable for hover height

    private Transform player;
    private bool isChasing = false;
    private NavMeshObstacle navObstacle; // Switched from NavMeshAgent to NavMeshObstacle
    private KillCounter killCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize NavMeshObstacle instead of NavMeshAgent
        navObstacle = GetComponent<NavMeshObstacle>();
        if (navObstacle != null)
        {
            navObstacle.carving = true;  // Enable carving for obstacle
        }

        // Find KillCounter as before
        killCounter = GameObject.FindObjectOfType<KillCounter>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Adjust logic to use basic following without pathfinding
        if (distanceToPlayer < detectionRange && distanceToPlayer > attackRange)
        {
            StartChasing();
        }
        else if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
        else
        {
            StopChasing();
        }
    }

    private void StartChasing()
    {
        isChasing = true;

        // Target position with hover height, no pathfinding needed
        Vector3 targetPosition = player.position + Vector3.up * hoverHeight;

        // Manually move toward target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);
    }

    private void StopChasing()
    {
        isChasing = false;
        // You can add idle or patrol behavior here
    }

    private void Attack()
    {
        Debug.Log("Attacking the player!");
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (killCounter != null)
        {
            killCounter.AddKill();
        }
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
