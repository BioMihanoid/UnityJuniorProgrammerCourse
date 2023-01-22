using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera camera1;
    public Camera camera2;
    public Vector3 offset = new Vector3(0, 2.5f, 2);
    
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F1)) 
        {
            camera1.enabled = true;
            camera2.enabled = false;
            offset = new Vector3(0, 2.5f, 2);
        }
        if (Input.GetKeyUp(KeyCode.F2)) 
        {
            camera1.enabled = false;
            camera2.enabled = true;
            offset = new Vector3(0, 5, -7);
        }
        transform.position = player.transform.position + offset;
    }
}
