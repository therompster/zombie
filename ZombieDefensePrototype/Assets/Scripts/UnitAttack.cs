using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public float attackRange = 300f; // Range within which units can attack zombies
    public float attackDamage = 10f; // Damage dealt to zombies
    public float attackCooldown = 1f; // Time between attacks

    private float attackTimer = 0f; // Timer to manage cooldowns

    void Update()
    {
        attackTimer += Time.deltaTime;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Zombie"))
            {
                ZombieHealth zombieHealth = collider.GetComponent<ZombieHealth>();
                if (zombieHealth != null && attackTimer >= attackCooldown)
                {
                    zombieHealth.TakeDamage(attackDamage);
                    Debug.Log(gameObject.name + " attacked " + collider.gameObject.name);
                    attackTimer = 0f; // Reset the attack timer
                }
            }
        }
    }
}

