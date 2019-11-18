using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj;
    public static string filename;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void textinput()
    {
        //filename = obj.GetComponent<InputField>().text;
    }
    public void OnClick()
    {
        Music.MusicPlay1();
        obj1.SetActive(false);
        obj2.SetActive(true);
    }
    public void OnClickGame()
    {
        filename = obj.GetComponent<InputField>().text;
        Music.MusicPlay1();
        SceneManager.LoadScene("Start");
    }
    public void OnClickTest()
    {
        Music.MusicPlay1();
        SceneManager.LoadScene("multiTest");
    }
}
