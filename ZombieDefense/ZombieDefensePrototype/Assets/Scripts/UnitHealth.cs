using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float health = 100f; // Initial health of the unit

    public void TakeDamage(float amount)
    {
        Debug.Log(gameObject.name + " health before damage: " + health);

        health -= amount;

        Debug.Log(gameObject.name + " took " + amount + " damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Destroy the unit when health reaches 0
    }
}
