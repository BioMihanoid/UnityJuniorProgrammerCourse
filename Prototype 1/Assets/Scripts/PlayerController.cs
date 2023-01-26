using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 20.0f;
    [SerializeField]
    float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
