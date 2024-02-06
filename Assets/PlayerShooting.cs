using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform laserStartPoint;
    public float laserMaxLength = 10f;
    public float laserWidth = 0.1f;
    public Color laserColor = Color.red;
    public float laserDuration = 0.1f;

    private LineRenderer laserLine;
    Vector3 rotatedDirection;  
    void Start()
    {
        // Create a LineRenderer component for the laser
        laserLine = gameObject.AddComponent<LineRenderer>();
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
        laserLine.material = new Material(Shader.Find("Standard"));
        laserLine.material.color = laserColor;
        laserLine.enabled = false;
        
    }

    void Update()
    {
        // Check if the player can shoot
        if (Input.GetButtonDown("Fire1"))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Enable the LineRenderer
        laserLine.enabled = true;

        // Set the starting point of the laser
        laserLine.SetPosition(0, laserStartPoint.position);
        rotatedDirection = laserStartPoint.rotation * transform.right;  
        //Debug.Log(laserStartPoint.rotation+ ""+ rotatedDirection);
        // Cast a ray in the forward direction to determine the end point of the laser
        Ray ray = new Ray(laserStartPoint.position, rotatedDirection);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, laserMaxLength))
        {
            // If the ray hits an object, set the end point to the hit point
            laserLine.SetPosition(1, hit.point);

            // Attempt to get a reference to the hit object's GameObject
            GameObject hitObject = hit.collider.gameObject;

                
            // If the hit object doesn't have a specific component, destroy it directly
            //Destroy(hitObject);
        }else{
            // If the ray doesn't hit anything, set the end point based on the max length
            laserLine.SetPosition(1, laserStartPoint.position + laserStartPoint.forward * laserMaxLength);
        }

        // Disable the LineRenderer after a short duration
        Invoke("DisableLaser", laserDuration);
    }

    void DisableLaser()
    {
        laserLine.enabled = false;
    }
}
