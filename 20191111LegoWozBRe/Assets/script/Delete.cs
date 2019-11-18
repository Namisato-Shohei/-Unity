using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    GameObject result = null;
    public GameObject[] del;
    public GameObject List;
    private GameObject obj;
    public static int flag = 0;
    GameObject[] ColorObj;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ColorObj = GameObject.FindGameObjectsWithTag("Hit");
        for (int i = 0; i < ColorObj.Length; i++)
        {
            ColorObj[i].GetComponent<BoxCollider>().enabled = true;
        }
        if (flag == 0 && ItemList.obj == null && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                result = hit.collider.gameObject.transform.root.gameObject;
            }
            if (result != null)
            {
                if (result.tag == "OldLego")
                {
                    //del[0].SetActive(true);
                    if (result.name.Contains("2x2"))
                    {
                        obj = Instantiate(del[1], new Vector3(result.transform.position.x, result.transform.position.y, result.transform.position.z), new Quaternion(result.transform.rotation.x, result.transform.rotation.y, result.transform.rotation.z, result.transform.rotation.w));
                    }
                    if (result.name.Contains("2x4"))
                    {
                        obj = Instantiate(del[2], new Vector3(result.transform.position.x, result.transform.position.y, result.transform.position.z), new Quaternion(result.transform.rotation.x, result.transform.rotation.y, result.transform.rotation.z, result.transform.rotation.w));
                    }
                    obj.transform.parent = result.transform;
                    flag = 1;
                }
            }

        }
        if (result != null && Input.GetMouseButtonDown(1))
        {
            Destroy(result);
            flag = 0;
        }

        if (result != null && Input.GetMouseButtonDown(2))
        {
            foreach (Transform c in result.transform)
            {
                if (c.tag == "Delete") Destroy(c.gameObject);
            }
            result = null;
            Destroy(obj);
            flag = 0;
        }



    }
    public void OnClickDel()
    {
        Destroy(result);
        del[0].SetActive(false);
        flag = 0;
    }
    public void OnClickCancel()
    {
        foreach (Transform c in result.transform)
        {
            if (c.tag == "Delete") Destroy(c.gameObject);
        }
        result = null;
        Destroy(obj);
        del[0].SetActive(false);
        flag = 0;
    }

}
