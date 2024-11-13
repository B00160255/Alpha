using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 25f;
    public LayerMask enemyLayer;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button or other assigned button
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Check for enemies within attack range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAI>()?.TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
