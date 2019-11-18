using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    GameObject goalobj;
    public GameObject rule;

    public static GameObject ruletoggle;
    public static Toggle toggle1;
    [SerializeField] Text text1;
    [SerializeField] GameObject Rule;
    public static int flag;
    // Start is called before the first frame update
    void Start()
    {
        
        ruletoggle = GameObject.FindGameObjectWithTag("Rule");
        toggle1 = ruletoggle.GetComponent<Toggle>();

        if (flag == 0)
        {
            toggle1.isOn = true;
            flag = 1;
        }
        else
        {
            toggle1.isOn = false;
        }
        Debug.Log(Select.GoalName);
        goalobj = this.transform.Find(Select.GoalName).gameObject;
        Debug.Log(goalobj);
        goalobj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "ルール " + (toggle1.isOn ? "ON" : "OFF");
        if (toggle1.isOn)
        {
            Rule.SetActive(true);
        }
        else
        {
            Rule.SetActive(false);

        }
    }
    public void OnClick()
    {
        Music.MusicPlay1();
        //ColorDepth.webcamTexture.Stop();
        //SceneManager.LoadScene("Play");
        SceneManager.LoadScene("Replace");
        //SceneManager.LoadScene("Result");
    }
//    public void OnClickClose()
//    {
//    rule.SetActive(false);
//}
    public void OnClickOpen()
    {
        rule.SetActive(true);
    }
    public void OnClickBack()
    {
        Music.MusicPlay1();
        //ColorDepth.webcamTexture.Stop();
        SceneManager.LoadScene("Start");
    }
    public void OnClickClose()
    {
        toggle1.isOn = false;
    }
}
