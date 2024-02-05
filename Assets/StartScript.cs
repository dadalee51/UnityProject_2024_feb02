using UnityEngine;

public class AirflowSimulation : MonoBehaviour
{
    public Vector3 windDirection = new Vector3(100f, 50f, 50f); // Set the wind direction

    void Start()
    {
        // Create a cube
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0f, 2f, 0f);
        cube.transform.localScale = new Vector3(2f, 2f, 2f); 
        // Create a sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(1f, 4f, 0f);
        sphere.transform.localScale = new Vector3(2f, 2f, 2f); 

        // Create a ground plane (quad)
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Quad);
        ground.transform.position = new Vector3(0f, 0f, 0f);
        ground.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        ground.transform.localScale = new Vector3(20f, 20f, 1f); // Adjust the scale as needed

        // Attach Rigidbody components to the cube and sphere
        Rigidbody cubeRb = cube.AddComponent<Rigidbody>();
        Rigidbody sphereRb = sphere.AddComponent<Rigidbody>();

        // Apply airflow simulation script to the cube and sphere
        ApplyWindForce(cubeRb);
        ApplyWindForce(sphereRb);
    }

    void Update()
    {
        // Get all the objects with a Rigidbody in the scene
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        // Apply wind force to each Rigidbody
        foreach (Rigidbody rb in rigidbodies)
        {
            ApplyWindForce(rb);
        }
    }

    void ApplyWindForce(Rigidbody rb)
    {
        // Apply the force to the Rigidbody
        //rb.AddForce(transform.up * 8.25f);
        rb.AddForce(new Vector3(0,1,0) * 7.25f);
    }
}
