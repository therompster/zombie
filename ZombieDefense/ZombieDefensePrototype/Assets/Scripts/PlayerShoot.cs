using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint; // The FirePoint where projectiles are spawned
    public float fireRate = 0.5f; // Time between shots
    public float targetRange = 20f; // Range to find zombies

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // Left mouse button
        {
            Transform closestZombie = FindClosestZombie();
            if (closestZombie != null)
            {
                Shoot(closestZombie);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private Transform FindClosestZombie()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        Transform closest = null;
        float closestDistance = targetRange;

        foreach (GameObject zombie in zombies)
        {
            float distance = Vector3.Distance(transform.position, zombie.transform.position);
            if (distance < closestDistance)
            {
                closest = zombie.transform;
                closestDistance = distance;
            }
        }

        return closest;
    }

    private void Shoot(Transform target)
    {
        if (projectilePrefab == null || firePoint == null || target == null) return;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Calculate direction to the target
        Vector3 direction = (target.position - firePoint.position).normalized;

        // Set projectile velocity
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 20f; // Adjust speed as needed
        }

        // Rotate the projectile to face the target
        projectile.transform.LookAt(target);
    }
}
