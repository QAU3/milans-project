using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switching : MonoBehaviour
{
    public GameObject TranPhone;
    public GameObject CamPhone;
    public GameObject TranTab;
    public GameObject CamTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("p"))
        {
            if (TranPhone.activeSelf)
            {
                TranPhone.SetActive(false);
                CamPhone.SetActive(true);
            }
            else if (CamPhone.activeSelf)
            {
                CamPhone.SetActive(false);
                TranPhone.SetActive(true);
            }
            else if (TranTab.activeSelf)
            {
                TranTab.SetActive(false);
                CamTab.SetActive(true);
            }
            else if (CamTab.activeSelf)
            {
                CamTab.SetActive(false);
                TranTab.SetActive(true);
            }
        }
        if (Input.GetKeyUp("d"))
        {
            if (TranPhone.activeSelf)
            {
                TranPhone.SetActive(false);
                TranTab.SetActive(true);
            }
            else if (CamPhone.activeSelf)
            {
                CamPhone.SetActive(false);
                CamTab.SetActive(true);
            }
            else if (TranTab.activeSelf)
            {
                TranTab.SetActive(false);
                TranPhone.SetActive(true);
            }
            else if (CamTab.activeSelf)
            {
                CamTab.SetActive(false);
                CamPhone.SetActive(true);
            }
        }
    }

    // gameObject.activeInHierarchy
}
