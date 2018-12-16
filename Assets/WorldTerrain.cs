using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain : MonoBehaviour {
    bool MouseOver = true, windowOpen=false, onWindow = false, pressedExit = false/*, MouseOverS=true*/;
    public bool esTuTerreno = true;
    public GUISkin gUIstyle;
    //bool MouseFollow = false;
    //bool wait = true;
    //public bool autorized = true, first = true; 
    //float timePassed;
    //public Sprite MouseOn, MouseOff;
    //public Sprite SpriteC;
    SpriteRenderer spriteRenderer;
    Transform[] transforms;
    //WorldTerrainInfo worldinfo;
    public Sprite[] cacota = new Sprite[2];
    public Vivienda vivienda;
    float anteriorBalance;
    int type;
    GameObject x;
    CameraMov2 pers;
    public Rect windowRect;
    private Vector2 scrollViewVector = Vector2.zero;
    private string[] edificios = { "Random", "Unifamiliar", "Edificio apartamentos" };//add the rest
    int n, i, edificio;
    void OnGUI()
    {
        GUI.skin = gUIstyle;
        if (windowOpen)
        {
            // Register the window.
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
            Rect rect = new Rect(windowRect.position.x, (float)Screen.height - windowRect.y - windowRect.height+10,windowRect.width,windowRect.height+20);
            if (rect.Contains(Input.mousePosition))
            {
                onWindow = true;
            }
            else
            {
                onWindow = false;
            }
        }
    }

    // Make the contents of the window
    void DoMyWindow(int windowID)
    {
        // Make a very long rect that is 20 pixels tall.
        // This will make the window be resizable by the top
        // title bar - no matter how wide it gets.
        if (GUI.Button(new Rect(180, 0, 20, 20), "x"))
        {
            pressedExit = true;
        }
        GUI.Label(new Rect(25, 25, 150, 30), "M2: "+ vivienda.m2.ToString("F2"));
        GUI.Label(new Rect(25, 50, 150, 30), "Habitaciones: " + vivienda.habs);
        GUI.Label(new Rect(25, 75, 150, 30), "Baños: " + vivienda.baths);
        GUI.Label(new Rect(25, 100, 150, 30), "Pisos: " + vivienda.pisosonum);
        GUI.Label(new Rect(25, 125, 150, 30), "Beneficios: " + vivienda.beneficios.ToString("F2"));
        GUI.Label(new Rect(25, 150, 150, 30), "Costo por m2: " + vivienda.costom2.ToString("F2"));
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
        
        if (GUI.Button(new Rect(25, 180, 150, 20), "Randomizar beneficios"))
        {
            randomizar();
        }
        if (GUI.Button(new Rect(25, 210, 150, 20), "Randomizar tipo de edificio"))
        {
            type = Random.Range(0, 2);
            randomizar();
            spriteRenderer.sprite = cacota[type];
        }
        dropdown();
    }
    // Use this for initialization
    public Renderer rend;
    void Awake() {
        n = 0; i = 0; edificio = 0;
        windowRect = new Rect(20, 20, 200, 350);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        transforms = gameObject.GetComponentsInChildren<Transform>();
        //worldinfo = gameObject.GetComponentInChildren<WorldTerrainInfo>();
        rend = GetComponent<Renderer>();
        type = Random.Range(0, 2);
        x = GameObject.FindGameObjectWithTag("Player");
        pers = x.GetComponent<CameraMov2>();
        spriteRenderer.sprite = cacota[type];

        randomizar();
        anteriorBalance = vivienda.beneficios;
        pers.balance += anteriorBalance;

        pers.money = 5000f;
    }
	
	// Update is called once per frame
	void Update () {
        if(anteriorBalance!=vivienda.beneficios)
        {
            pers.balance -= anteriorBalance;
            anteriorBalance = vivienda.beneficios;
            pers.balance += anteriorBalance;
        }
        if (MouseOver&&Input.GetMouseButton(0))
        {

            windowOpen = true;
        }
        if ((!MouseOver&&Input.GetMouseButton(0)&&!onWindow)||pressedExit)
        {

            windowOpen = false;
            pressedExit = false;
        }
    }
    void OnMouseEnter() {
        MouseOver = true;

    }
    private void OnMouseExit()
    {
        MouseOver = false;
    }
    void randomizar()
    {
        switch (type)
        {
            case 1:

                vivienda = new Vivienda(Random.Range(50f, 150f), Random.Range(1, 6), Random.Range(1, 6), Random.Range(4, 30), Random.Range(1f, 10f), esTuTerreno);
                break;
            case 0:
                vivienda = new Vivienda(Random.Range(70f, 400f), Random.Range(2, 10), Random.Range(2, 10), Random.Range(1, 3), Random.Range(5f, 15f), esTuTerreno);
                break;
        }
    }
    void dropdown()
    {
        if (GUI.Button(new Rect(125, 235, 25, 25), ""))
        {
            if (n == 0) n = 1;
            else n = 0;
        }

        if (n == 1)
        {

            scrollViewVector = GUI.BeginScrollView(new Rect(25, 235, 100, 115), scrollViewVector, new Rect(0, 0, 300, 500));
            GUI.Box(new Rect(0, 0, 300, 500), "");
            for (i = 0; i < 4; i++)
            {
                if (GUI.Button(new Rect(0, i * 25, 300, 25), ""))
                {
                    n = 0; edificio = i;
                    type = edificio == 0 ? (type = Random.Range(0, 2)) : (edificio - 1);
                    spriteRenderer.sprite = cacota[type];
                    randomizar();

                }
                GUI.Label(new Rect(5, i * 25, 300, 25), edificios[i]);
            }
            GUI.EndScrollView();
        }
        else
        {
            GUI.Label(new Rect(30, 235, 300, 25), edificios[edificio]);
        }
    }
}


/*
        if (Input.GetMouseButtonDown(0)&&wait==true)
        {
            first = true;
            MouseFollow = true;
            
            
        }
        if (Input.GetMouseButtonUp(0)){
            MouseFollow = false;
            timePassed = Time.time;
        }
        if (timePassed+0.1f<Time.time)
        {
            wait = true;
        }
        else
        {
            wait = false;
        }
        if (worldinfo.drag)
        {
            MouseOverS = true;
        }
        else
        {

            MouseOverS = false;
        }
        if ((MouseOver||MouseOverS) && Input.GetMouseButton(0))
        {
            //worldinfo.highPress = true;
            Vector3 temp = transform.position;
            temp.z += -2f; // Set this to be the distance you want the object to be placed in front of the camera
            transforms[1].position = temp;
        }

        if((!MouseOver && !MouseOverS) && Input.GetMouseButton(0))
        {

            //worldinfo.highPress = false;
        }*/
