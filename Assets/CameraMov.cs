using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {
    float speed = 2;
    public Camera cam;
    GameObject gameObjecte;
    // Use this for initialization
    void Start () {
        gameObjecte = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = gameObjecte.transform.position;
        temp.z = -10;
        transform.position = temp;
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && cam.orthographicSize <= 30) // forward
        {
            cam.orthographicSize += cam.orthographicSize * speed / 7;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && cam.orthographicSize > 1) // backwards
        {
            cam.orthographicSize -= cam.orthographicSize * speed / 7;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        else
        {
            speed = 2;
        }
    }
}
