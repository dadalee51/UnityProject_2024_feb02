using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float smoothSpeed = 10.0f;

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = playerTransform.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            
            // Set the new position of the camera
            transform.position = smoothedPosition;

            // Look at the player
            transform.LookAt(playerTransform);
        }
    }
}
