using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera will follow (e.g., UnitManager)
    public Vector3 offset = new Vector3(0, 5, -30); // Default offset
    //public Vector3 offset = new Vector3(0, 5, -30); // Default offset

    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement

    void LateUpdate()
    {
        if (target == null)
        {
            //Debug.LogWarning("Target not assigned to CameraFollow!");
            return;
        }

        // Calculate the desired position based on the target's position and the offset
        Vector3 desiredPosition = target.position + offset;
        //Debug.Log("Target Position: " + target.position);
        //Debug.Log("Camera Desired Position: " + desiredPosition);

        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the smoothed position to the camera
        transform.position = smoothedPosition;
    }
}
