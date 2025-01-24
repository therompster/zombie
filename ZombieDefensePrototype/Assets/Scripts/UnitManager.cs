using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<GameObject> units; // All units in the army
    public float unitSpeed = 2f; // Movement speed
    public float stopDistance = 3f; // Stop if zombies are within this range

    void Update()
    {
        // Check if zombies are in front
        if (IsZombieInFront())
        {
            Debug.Log("Zombie in range. Stopping units.");
            return;
        }

        // Move all units forward together
        foreach (var unit in units)
        {
            if (unit != null)
            {
                Vector3 forward = new Vector3(0, 0, 1); // Forward movement direction
                unit.transform.Translate(forward * unitSpeed * Time.deltaTime);
                Debug.Log($"{unit.name} is moving to position: {unit.transform.position}");
            }
        }
        // Move the UnitManager position forward to match the units' average position
        UpdateManagerPosition();
    }

    private bool IsZombieInFront()
    {
        // Check for zombies in front of the units
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stopDistance);
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Zombie"))
            {
                Debug.Log("Zombie " + collider.gameObject.name + " is stopping unit movement.");
                return true; // Stop movement if a zombie is within range
            }
        }
        return false; // No zombies blocking
    }

    private void UpdateManagerPosition()
    {
        // Remove any destroyed units from the list
        units.RemoveAll(unit => unit == null);

        if (units.Count == 0) return;

        // Calculate the average position of all units
        Vector3 averagePosition = Vector3.zero;
        foreach (var unit in units)
        {
            averagePosition += unit.transform.position;
        }
        averagePosition /= units.Count;

        // Update the UnitManager position to match the average
        transform.position = averagePosition;
    }


}
