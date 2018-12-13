using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextShower : MonoBehaviour {
    GameObject x;
    CameraMov2 pers;
    Text thistext;
	// Use this for initialization
	void Start () {
        x = GameObject.FindGameObjectWithTag("Player");
        pers = x.GetComponent<CameraMov2>();
        thistext = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
    
	void Update () {
        thistext.text = "Dinero: " + pers.money;
	}
}
