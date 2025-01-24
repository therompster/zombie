using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Check if any unit is ahead of the zombie
        if (!IsBehindAnyUnit())
        {
            // Move the zombie forward along the Z-axis
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    bool IsBehindAnyUnit()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        foreach (GameObject unit in units)
        {
            // If the zombie's Z position is less than a unit's Z position, it's behind
            if (transform.position.z <= unit.transform.position.z)
            {
                return true;
            }
        }
        return false;
    }
}
