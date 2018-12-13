using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainInfo : MonoBehaviour {
    Renderer renderer;
    BoxCollider2D boxCollider;
    SpriteRenderer[] spriteRenderer;
    public bool drag, highPress;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (spriteRenderer[0].enabled)
        {
            foreach(SpriteRenderer i in spriteRenderer)
            {
                i.enabled = true;
            }
        }
        else
        {
            foreach (SpriteRenderer i in spriteRenderer)
            {
                i.enabled = false;
            }
        }
        if (Input.GetMouseButton(0) && drag)
        {

            boxCollider.edgeRadius = 30;
            Vector3 temp = Input.mousePosition;
            temp.z = 2f; // Set this to be the distance you want the object to be placed in front of the camera
            transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
        else
        {
            if (drag)
            {

                boxCollider.edgeRadius = 5;
            }
            else
            {

                boxCollider.edgeRadius = 0;
            }
            
        }
    }
    void OnMouseEnter()
    {
        drag = true;
    }
    void OnMouseExit()
    {
        drag = false;
    }
}
