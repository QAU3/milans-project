using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backScript : MonoBehaviour
{
    private Camera camera;
    public GameObject screen;
    public GameObject backside;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FixBackSide();    
    }
        
    private bool ScreenIsCloser()
    {
        var cameraPoint = camera.transform.position;
        var screenPoint = screen.transform.position;
        var backPoint = backside.transform.position;

        float toScreen = Vector3.Magnitude(cameraPoint - screenPoint);
        float toBackside = Vector3.Magnitude(cameraPoint - backPoint);
        //Debug.Log(toScreen + " to screen and to backside " + toBackside);
        if (toScreen <= toBackside)
            return true;
        else
            return false;
    }

    private void FixBackSide()
    {
        if (ScreenIsCloser())
        {
            //Debug.Log("It should venish");

            Color c = backside.GetComponent<Renderer>().material.color;
            c.a = .0f;
            backside.GetComponent<Renderer>().material.SetColor("_Color", c);
        }
        else
        {
            Color c = backside.GetComponent<Renderer>().material.color;
            c.a = 1.0f;
            backside.GetComponent<Renderer>().material.SetColor("_Color", c);
        }
    }
}
