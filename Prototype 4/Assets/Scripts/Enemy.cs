using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lockDirection = (player.transform.position - transform.position).normalized;

        if (transform.position.y >= 0)
            enemyRb.AddForce(lockDirection * speed);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
