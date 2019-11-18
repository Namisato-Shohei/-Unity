using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class Replace : MonoBehaviour
{
    private CSVReader LegoData = new CSVReader();
    CSVReader ResultData;
    private GameObject obj;
    private GameObject obj0;

    //public GameObject ReplaceButton;
    //public GameObject ResultButton;

    private GameObject[] lego;
    public static string legocolor;
    int resultcount = 0;
    GameObject Evaluation;

    AudioSource audioSource;
    GameObject Plane;
    GameObject[] ColorObj;
    int[] Remaining;

    int legopoint;
    public Text pointtext;
    public Text pointcolortext;
    public Text pointmintext;
    public Text pointpositext;
    int[] usedcolor;
    int colorcount;
    int mincolor;
    int point;
    public GameObject Resultpoint;
    public static int Hitcount;
    int[,] points = new int[3, 4];
    // Start is called before the first frame update
    void Start()
    {
        // Music.MusicPlay(7);
        Resultpoint.SetActive(false);
        //LegoData.CsvRead("LegoData");
        LegoData.CsvReadAndroid("LegoData");

        //audioSource = GetComponent<AudioSource>();
        Hitcount = 0;
        Onclick();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Onclick()
    {
        //Music.MusicPlay1();
        //Lego出力
        //for (int i = 0; i < Finish.resultdata.Length / 9; i++)
        //{
        //    if (Finish.resultdata != null)
        //    {
        //        obj = (GameObject)Resources.Load("obj/" + Finish.resultdata[i, 0].Replace("(Clone)", ""));
        //        Instantiate(obj, new Vector3(float.Parse(Finish.resultdata[i, 1]), float.Parse(Finish.resultdata[i, 2]), float.Parse(Finish.resultdata[i, 3])), new Quaternion(float.Parse(Finish.resultdata[i, 4]), float.Parse(Finish.resultdata[i, 5]), float.Parse(Finish.resultdata[i, 6]), float.Parse(Finish.resultdata[i, 7])));
        //    }
        //}
        Debug.Log(LegoData.csvDatas.Count);
        for (int i = 0; i < LegoData.csvDatas.Count; i++)
        {
            obj = (GameObject)Resources.Load("obj/" + LegoData.csvDatas[i][0]);
            Instantiate(obj, new Vector3(float.Parse(LegoData.csvDatas[i][1]), float.Parse(LegoData.csvDatas[i][2]), float.Parse(LegoData.csvDatas[i][3])), new Quaternion(float.Parse(LegoData.csvDatas[i][4]), float.Parse(LegoData.csvDatas[i][5]), float.Parse(LegoData.csvDatas[i][6]), float.Parse(LegoData.csvDatas[i][7])));

        }
        lego = GameObject.FindGameObjectsWithTag("NewLego");
        obj0 = Instantiate((GameObject)Resources.Load("obj/0"));
        for (int i = 0; i < lego.Length; i++)
        {
            lego[i].transform.parent = obj0.transform;
        }
        //ReplaceButton.SetActive(false);
        //ResultButton.SetActive(true);

        OnClickColor();

    }
    public void OnClickColor()
    {
        ColorObj = GameObject.FindGameObjectsWithTag("Hit");
        for (int i = 0; i < ColorObj.Length; i++)
        {
            ColorObj[i].GetComponent<BoxCollider>().enabled = true;
        }
        Music.MusicPlay(9);
        Invoke("OnClickResult", 2);
        Debug.Log(Hitcount);
    }
    public void OnClickResult()
    {
        for (int i = 0; i <= 1; i++)
        {
            ResultMax(Select.GoalName, i);
        }
        Debug.Log(points[0, 0] + " " + points[1, 0]);
        if (points[0, 0] >= points[1, 0] && points[0, 0] >= points[2, 0])
        {
            Result(points[0, 0], points[0, 1], points[0, 2], points[0, 3]);
        }
        else if (points[1, 0] >= points[0, 0] && points[1, 0] >= points[2, 0])
        {
            Result(points[1, 0], points[1, 1], points[1, 2], points[1, 3]);
        }
    }
    public void ResultMax(string name, int n)
    {
        ResultData = new CSVReader();
        ResultData.CsvRead(name + n);
        resultcount = 0;
        colorcount = 0;
        usedcolor = new int[5];
        Debug.Log(ResultData.csvDatas.Count);
        Debug.Log(name + n);
        if (lego.Length != 0)
        {
            for (int i = 0; i < lego.Length; i++)
            {
                for (int j = 0; j < ResultData.csvDatas.Count; j++)
                {
                    if (LegoData.csvDatas[i][0].Contains("Red"))
                    {
                        usedcolor[0] = 1;
                        if (LegoData.csvDatas[i][0].Replace("_Red", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(LegoData.csvDatas[i][8]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][8]) * 100)))
                        {
                            resultcount++;

                            //LegoData.csvDatas[i][0] = null;
                            break;
                        }
                    }
                    if (LegoData.csvDatas[i][0].Contains("Green"))
                    {
                        usedcolor[1] = 1;
                        if (LegoData.csvDatas[i][0].Replace("_Green", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(LegoData.csvDatas[i][8]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][8]) * 100)))
                        {
                            resultcount++;

                            //LegoData.csvDatas[i][0] = null;
                            break;
                        }
                    }
                    if (LegoData.csvDatas[i][0].Contains("Blue"))
                    {
                        usedcolor[2] = 1;
                        if (LegoData.csvDatas[i][0].Replace("_Blue", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(LegoData.csvDatas[i][8]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][8]) * 100)))
                        {
                            resultcount++;

                            //LegoData.csvDatas[i][0] = null;
                            break;
                        }
                    }
                    if (LegoData.csvDatas[i][0].Contains("Yellow"))
                    {
                        usedcolor[3] = 1;
                        if (LegoData.csvDatas[i][0].Replace("_Yellow", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(LegoData.csvDatas[i][8]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][8]) * 100)))
                        {
                            resultcount++;

                            //LegoData.csvDatas[i][0] = null;
                            break;
                        }
                    }
                    if (LegoData.csvDatas[i][0].Contains("White"))
                    {
                        usedcolor[4] = 1;
                        if (LegoData.csvDatas[i][0].Replace("_White", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(LegoData.csvDatas[i][8]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][8]) * 100)))
                        {
                            resultcount++;

                            //LegoData.csvDatas[i][0] = null;
                            break;
                        }
                    }

                }
            }
        }
        for (int i = 0; i < usedcolor.Length; i++)
        {
            if (usedcolor[i] == 1)
            {
                colorcount++;
            }
        }
        legopoint = 100 / lego.Length;
        point = 100 - (legopoint / 2 * Hitcount) - (legopoint / 2 * Math.Abs(ResultData.csvDatas.Count - resultcount)) - (legopoint * Math.Abs(colorcount - Select.mincolor));
        if (point < 0)
        {
            point = 0;
        }
        else if (point > 100)
        {
            point = 100;
        }
        points[n, 0] = point;
        points[n, 1] = legopoint / 2 * Hitcount;
        points[n, 2] = legopoint * Math.Abs(colorcount - Select.mincolor);
        points[n, 3] = legopoint / 2 * Math.Abs(ResultData.csvDatas.Count - resultcount);
    }
    public void Result(int maxpoint, int pointc, int pointm, int pointp)
    {
        Music.MusicPlay(11);
        pointcolortext.text = "いろが かさなっていた  -" + pointc.ToString() + "点";
        pointmintext.text = "いろの かずが ちがった  -" + pointm.ToString() + "点";
        pointpositext.text = "かたちが ちがっていた  -" + pointp.ToString() + "点";
        pointtext.text = maxpoint + "点";
        Resultpoint.SetActive(true);
        if (point == 100)
        {
            Music.MusicPlay(2);
        }
        else if (point > 80)
        {
            Music.MusicPlay(12);
        }
        else
        {
            Music.MusicPlay(3);
        }
        //Debug.Log(resultcount);
        //if (resultcount == ResultData.csvDatas.Count)
        //{
        //    Music.MusicPlay3();
        //    Evaluation = this.transform.Find(Select.GoalName + "_Good").gameObject;
        //}else
        //{
        //    Music.MusicPlay4();
        //    Evaluation = this.transform.Find(Select.GoalName + "_Bad").gameObject;
        //}
        //Evaluation.SetActive(true);
        //obj.SetActive(false);
        //Plane.SetActive(false);
        //ResultButton.SetActive(false);
    }
    public void OnClickRestart()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + Main.filename + "Score.txt", true);// TextData.txtというファイルを新規で用意
        sw.WriteLine(Select.GoalName + "," + pointtext.text);// ファイルに書き出したあと改行
        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        sw.Close();// ファイルを閉じる
        SceneManager.LoadScene("Start");
    }
    public void OnClickBack()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + Main.filename + "Score.txt", true);// TextData.txtというファイルを新規で用意
        sw.WriteLine(Select.GoalName + "," + pointtext.text);// ファイルに書き出したあと改行
        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        sw.Close();// ファイルを閉じる
        SceneManager.LoadScene("Goal");
    }
    public void OnClickRe()
    {
        legopoint = 0;
        Hitcount = 0;
        colorcount = 0;
        Destroy(obj0);
        for (int i = 0; i < lego.Length; i++)
        {
            lego[i].tag = "OldLego";
            Destroy(lego[i]);
        }
        //LegoData = new CSVReader();
        LegoData.CsvReadAndroid("LegoData");
        Onclick();
    }
    public void OnClickClose()
    {
        Resultpoint.SetActive(false);
    }
    public void OnClickOpen()
    {
        Resultpoint.SetActive(true);
    }
}
