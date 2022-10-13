using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class renderTra : MonoBehaviour
{
    private Camera camera1;
    public GameObject screen;
    public Transform group;
    //private GameObject []directions;
    //public GameObject pingvin;=


    // Start is called before the first frame update
    void Start()
    {
        camera1 = Camera.main;
        //directions = group.GetComponentsInChildren<GameObject> ();
    }

    // Update is called once per frame
    void Update()
    {
        //Render();
        Search();
    }

    private void Search()
    {
        //for(int i = 1; i < directions.Length; i++) {
        foreach (Transform x in group)
        {
            GameObject go = x.gameObject;
            
            //GameObject go = pingvin;
            //Debug.Log(go.transform.name);

            if(go.layer == 6)
            {
                go.SetActive(false);
            }
            else
                go.SetActive(true);

            if (Physics.Linecast(camera1.transform.position, go.GetComponentInChildren<Renderer>().bounds.center, out var hit))
            {

                //Debug.Log("Check in");
                if (hit.collider.gameObject != go.gameObject)
                {
                    //Debug.Log("Nesto izmedju");
                    if (go.gameObject.layer == 6)
                    {
                        //Debug.Log("On screen hidden");
                        //go.gameObject.layer = 8;
                        go.SetActive(true);
                        //Debug.Log("set active" + go.transform.name + " " + go.gameObject.layer+ " go.activeSelf;
                    }
                    else if (go.gameObject.layer == 7)
                    {
                        //go.gameObject.layer = 9;
                        //Debug.Log("On desk hidden with layer"+ go.gameObject.layer);
                        go.SetActive(false);
                        //Debug.Log("set active"+ go.transform.name + " "+  go.gameObject.layer);
                    }
                }

                else
                {
                    if (go.gameObject.layer == 7)
                    {
                        //Debug.Log("On desk");
                        //go.gameObject.layer = 9;
                        go.SetActive(true);
                    }
                    else if (go.gameObject.layer == 6)
                    {
                        //Debug.Log("On screen");
                        //go.gameObject.layer = 8;
                        go.SetActive(false);
                    }
                }
            }
        }
    }

    void Render()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(camera1);
        var objCollider = GetComponent<Collider>();

        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds)
            && objCollider.tag=="direction")
        {
            Debug.Log("I am inside the camera frustrum!");

            if (Physics.Linecast(camera1.transform.position, objCollider.GetComponentInChildren<Renderer>().bounds.center, out var hit))
            {
                if (hit.collider.CompareTag("direction"))
                {
                    if (hit.collider.gameObject != objCollider.gameObject)
                    {
                        Debug.Log("..but something else is in the way..");
                    }
                    else
                    {
                        //Debug.Log("Now you see me, muhaha!");
                    }
                }

            }
        }
    }
}