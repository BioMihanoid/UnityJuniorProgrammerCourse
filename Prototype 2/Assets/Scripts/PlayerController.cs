using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 30.0f;
    private float xRange = 20.0f;

    public GameObject projectilePrefab;

    void Update()
    {
        if (transform.position.x < -xRange) 
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
