using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab
    public Transform firePoint; // Assign the FirePoint transform
    public float attackRange = 10f; // Range at which zombies can attack
    public float attackCooldown = 2f; // Time between attacks

    private float attackTimer = 0f;

    void Update()
    {
        attackTimer += Time.deltaTime;

        // Find all units within attack range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Unit") && attackTimer >= attackCooldown)
            {
                ShootProjectile(collider.transform);
                attackTimer = 0f; // Reset the cooldown
                break; // Only attack one unit per cooldown
            }
        }
    }

    private void ShootProjectile(Transform target)
    {
        if (projectilePrefab == null || firePoint == null) return;

        // Spawn the projectile at the FirePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Set the projectile to move toward the target
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (target.position - firePoint.position).normalized;
            rb.linearVelocity = direction * 10f; // Adjust speed as needed
        }

        // Optionally: Add some rotation to face the target
        projectile.transform.LookAt(target);
    }
}
