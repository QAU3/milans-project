using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pointsScript : MonoBehaviour
{
    private Camera camera;
    private Transform[] pts;
    //public GameObject TranPhone;
    //public GameObject CamPhone;
    //public GameObject TranTab;
    //public GameObject CamTab;
    public GameObject target;
    private int n;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        pts = transform.GetComponentsInChildren<Transform>();
        n= pts.Length;
        /*for (int i = 1; i < n; i++)
        // i not from 0 because 0 is whole array pts
        {
            //pts[i].GetComponent<Renderer>().material.color = Color.blue;
            //Debug.Log(pts[i].gameObject.name+" "+ i +"\n");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        search();
    }

    void search()
    {
        float range = 20;

        Ray ray = new Ray(camera.transform.position, 
            target.transform.position - camera.transform.position);

        var hits = Physics.RaycastAll(ray, range);

        foreach (var hit in hits)
        {
            for (int i = 1; i < n; i++)
            {
                //if (hit.collider == target)

                if(hit.collider.CompareTag("point") && hit.collider.name == pts[i].name )
                {
                    Debug.Log("true");
                    pts[i].GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
    }
}