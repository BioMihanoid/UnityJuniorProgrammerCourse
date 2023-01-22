using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -15.0f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    void Update()
    {   
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

        if (Input.GetKeyDown(KeyCode.W))
            speed *= 2;

        if (Input.GetKeyDown(KeyCode.S))
            speed /= 2;

        if (speed >= 60.0f)
            speed = 60.0f;

        if (speed <= 30.0f)
            speed = 30.0f;
    }
}
