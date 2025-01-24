using UnityEngine;

public class ZombieProjectile : MonoBehaviour
{
    public float damage = 10f; // Damage dealt by the projectile
    public float lifetime = 5f; // Time before the projectile is destroyed

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the projectile after its lifetime expires
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            UnitHealth unitHealth = other.GetComponent<UnitHealth>();
            if (unitHealth != null)
            {
                unitHealth.TakeDamage(damage);
                Debug.Log(gameObject.name + " hit " + other.gameObject.name);
            }

            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
