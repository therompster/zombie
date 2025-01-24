using UnityEngine;

public class GrassApplier : MonoBehaviour
{
    public Texture2D grassTexture;

    void Start()
    {
        // Create a new material with the Standard shader
        Material grassMaterial = new Material(Shader.Find("Standard"));
        
        // Assign the grass texture to the material
        grassMaterial.mainTexture = grassTexture;

        // Find the plane in the scene
        GameObject plane = GameObject.Find("Plane");
        if (plane != null)
        {
            // Apply the grass material to the plane
            plane.GetComponent<Renderer>().material = grassMaterial;
        }
        else
        {
            Debug.LogError("Plane not found in the scene.");
        }
    }
}
