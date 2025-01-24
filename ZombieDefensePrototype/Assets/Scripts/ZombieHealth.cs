using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float startingHealth = 100f; // Initial health of the zombie
    public float currentHealth; // Current health of the zombie

    void Start()
    {
        currentHealth = startingHealth; // Set current health to starting health at the start
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(gameObject.name + " health before damage: " + currentHealth);

        currentHealth -= amount;

        Debug.Log(gameObject.name + " took " + amount + " damage. Remaining health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Destroy the zombie when health reaches 0
    }
}
