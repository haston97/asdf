using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMov2 : MonoBehaviour {
    float speed = 5;
    public float Fspeed, Sspeed;
    public Camera cam;
    Rigidbody2D rigidbody2D;
    public float money=5000;
    public float balance=100;
	// Use this for initialization
	void Start () {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2D.velocity = movement * speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Fspeed * cam.orthographicSize;
        }
        else
        {
            speed = Sspeed * cam.orthographicSize;
        }
    }

}
