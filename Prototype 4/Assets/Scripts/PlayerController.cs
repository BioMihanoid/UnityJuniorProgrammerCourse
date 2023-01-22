using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerOn;
    public bool hasShellUp;
    public GameObject powerupIndicator;
    public GameObject shellPrefab;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private Enemy[] enemys;
    private Rigidbody shellRb;
    private float powerupStrength = 15.0f;
    private float shellStrength = 30.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        enemys = GameObject.FindObjectsOfType<Enemy>();

        if (Input.GetKeyDown(KeyCode.F) && hasShellUp)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                Vector3 direction = (enemys[i].gameObject.transform.position - transform.position);
                Instantiate(shellPrefab, transform.position, shellPrefab.transform.rotation);
                shellRb = GameObject.Find("Shell").GetComponent<Rigidbody>();
                shellRb.AddForce(direction * shellStrength);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerOn = true;
            Destroy(other.gameObject);
            StartCoroutine(UpCountdownRoutine(hasPowerOn));
            powerupIndicator.SetActive(true);
        }
        else if (other.CompareTag("Shellup"))
        {
            hasShellUp = true;
            Destroy(other.gameObject);
            //StartCoroutine(UpCountdownRoutine(hasShellUp));
            powerupIndicator.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerOn)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator UpCountdownRoutine(bool condition)
    {
        yield return new WaitForSeconds(7);
        condition = false;
        powerupIndicator.SetActive(false);
    }
}
