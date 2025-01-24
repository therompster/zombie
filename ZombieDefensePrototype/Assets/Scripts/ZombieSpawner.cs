using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Zombie prefab
    public float spawnInterval = .5f; // Time between spawns
    public float spawnDistanceAhead = 10f; // Distance ahead of the unit group to spawn zombies
    public Transform unitManager; // Reference to the UnitManager object

    void Start()
    {
        InvokeRepeating("SpawnZombie", 0f, spawnInterval);
    }

    void SpawnZombie()
    {
        if (unitManager == null)
        {
            Debug.LogWarning("UnitManager not assigned to ZombieSpawner!");
            return;
        }

        // Get the position of the UnitManager (center of the unit group)
        Vector3 unitGroupPosition = unitManager.position;

        // Randomize the X-axis position within a certain range
        float randomX = Random.Range(-3f, 3f);

        // Spawn zombies ahead of the unit group
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, unitGroupPosition.z + spawnDistanceAhead);

        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Zombie spawned at " + spawnPosition);
    }
}
