using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    public static int HitCount=0;
    string color;
    public GameObject del;
    public GameObject del4;
    public GameObject joinobj;
    GameObject parentobj;

    // Start is called before the first frame update
    void Start()
    {
        HitCount = 0;
        del = (GameObject)Resources.Load("obj/delete");
        del4 = (GameObject)Resources.Load("obj/delete2x4");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Replace")
        {
 
            if (this.gameObject.transform.parent.name.Contains("2x2"))
            {
                //Debug.Log("AAa");
                color = this.gameObject.transform.parent.name.Replace("2x2_", "");
                joinobj = (GameObject)Resources.Load("obj/delete");
            }
            if (this.gameObject.transform.parent.name.Contains("2x4"))
            {
                //Debug.Log("BBb");
                color = this.gameObject.transform.parent.name.Replace("2x4_", "");
                joinobj = (GameObject)Resources.Load("obj/delete2x4");
            }
            //Debug.Log(joinobj);
            //Debug.Log(color);
            if (other.gameObject.transform.parent.name.Contains(color))
            {
                //joinobj = Instantiate(joinobj, new Vector3(this.gameObject.transform.parent.transform.position.x, this.gameObject.transform.parent.transform.position.y, this.gameObject.transform.parent.transform.position.z), this.gameObject.transform.parent.transform.rotation);
                //joinobj.transform.parent = this.gameObject.transform.parent.transform;
                Replace.Hitcount++;
            }

        }
    }
}
