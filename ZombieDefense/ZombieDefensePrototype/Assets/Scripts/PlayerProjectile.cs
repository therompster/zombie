using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float damage = 10f; // Damage dealt by the projectile
    public float lifetime = 5f; // Maximum time the projectile exists

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Projectile collided with {other.gameObject.name}.");

        if (other.CompareTag("Zombie"))
        {
            ZombieHealth zombieHealth = other.GetComponent<ZombieHealth>();
            if (zombieHealth != null)
            {
                Debug.Log($"Zombie {other.gameObject.name} health before damage: {zombieHealth.health}");
                zombieHealth.TakeDamage(damage);
                Debug.Log($"Zombie {other.gameObject.name} health after damage: {zombieHealth.health}");
            }

            Destroy(gameObject); // Destroy the projectile on collision
        }
    }




}
