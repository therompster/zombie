using UnityEngine;

public class ZombieProjectile : MonoBehaviour
{
    public float damage = 10f; // Damage dealt by the projectile
    public float speed = 15f; // Speed of the projectile
    public float lifetime = 5f; // Maximum time the projectile exists

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destroy after lifetime expires
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move forward
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerUnit")) // Replace "PlayerUnit" with your tag for player-controlled units
        {
            UnitHealth unitHealth = other.GetComponent<UnitHealth>();
            if (unitHealth != null)
            {
                unitHealth.TakeDamage(damage); // Apply damage
            }
            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
