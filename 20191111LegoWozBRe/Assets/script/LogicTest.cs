using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add-------------------------
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicTest : MonoBehaviour {
    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();
    public Text QuestionText;
    public Text Answer1Text;
    public Text Answer2Text;
    public Text Answer3Text;
    public Text FinishText;

    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;
    public GameObject Finish;
    public GameObject Explanation;
    List<string> TestAnswer = new List<string>();

    int count = 2;
    int AnswerCount = 0;
    // Use this for initialization
	void Start () {
        csvRead();
        QuestionText.text=csvDatas[1][1];
        Answer1Text.text = csvDatas[1][2];
        Answer2Text.text = csvDatas[1][3];
        Answer3Text.text = csvDatas[1][4];
        Debug.Log(csvDatas.Count);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(csvDatas[count][1]);
        //    QuestionText.text = csvDatas[count][1];
        //    count++;
        //}f
	}
    public void csvRead()
    {
        csvFile = Resources.Load("Logicaltest") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);


        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        //for (int i = 0; i < csvDatas.Count; i++)
        //{
        //    for (int j = 0; j < csvDatas[i].Length; j++)
        //    {
        //        Debug.Log(csvDatas[i][j]);
        //    }
        //}
    }

    public void LogSave(string AnswerDatas)
    {
        StreamWriter sw;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + "/Resources/logicaltestAnswer.csv");
        sw = fi.AppendText();
        sw.WriteLine(AnswerDatas);
        sw.Flush();
        sw.Close();
    }
    public void OnClickAnswer1()
    {
        Music.MusicPlay1();
        TextChange("1");
    }
    public void OnClickAnswer2()
    {
        Music.MusicPlay1();
        TextChange("2");
    }
    public void OnClickAnswer3()
    {
        Music.MusicPlay1();
        TextChange("3");
    }
    public void OnClickFINISH()
    {
        Music.MusicPlay1();
        Quit();
    }

    public void TextChange(string Answer)
    {
        if (count == csvDatas.Count)
        {
            LogSave(Answer);
            TestAnswer.Add(Answer);
            LogSave(" ");
            Debug.Log(TestAnswer.Count);
            for (int i = 0; i < TestAnswer.Count; i++)
            {
                if (TestAnswer[i] == csvDatas[i + 1][5])
                {
                    AnswerCount++;
                }
            }
            Answer1.SetActive(false);
            Answer2.SetActive(false);
            Answer3.SetActive(false);
            Finish.SetActive(true);
            QuestionText.text ="FINISH : "+ AnswerCount + "/" + (csvDatas.Count - 1);
            FinishText.text = "終了";
            count++;
        }
        else
        {
            LogSave(Answer);
            TestAnswer.Add(Answer);
            QuestionText.text = csvDatas[count][1];
            Answer1Text.text = csvDatas[count][2];
            Answer2Text.text = csvDatas[count][3];
            Answer3Text.text = csvDatas[count][4];
            count++;
        }

    }
    public void Quit()
    {
        Music.MusicPlay1();
        SceneManager.LoadScene("Main");
        //UnityEditor.EditorApplication.isPlaying = false;
        //UnityEngine.Application.Quit();
    }
    public void OnClick()
    {
        Music.MusicPlay1();
        Explanation.SetActive(false);
    }
}

