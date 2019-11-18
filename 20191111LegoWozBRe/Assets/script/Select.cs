using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public static string GoalName;
    public static int mincolor;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Main.filename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickCake()
    {
        Music.MusicPlay1();
        GoalName = "Sample";
        SceneManager.LoadScene("Goal");
    }
    public void OnClickBird()
    {
        Music.MusicPlay1();
        GoalName = "Bird";
        SceneManager.LoadScene("Goal");
    }
    public void OnClicChair()
    {
        Music.MusicPlay1();
        GoalName = "Chair";
        SceneManager.LoadScene("Goal");
    }
    public void ButtonClick(string text)
    {
        Music.MusicPlay1();
        GoalName = text;
        SceneManager.LoadScene("Goal");
    }
    public void MinColorNum(int num)
    {
        mincolor = num;
    }
    public void onClickFinish()
    {
    UnityEngine.Application.Quit();
    }

}
