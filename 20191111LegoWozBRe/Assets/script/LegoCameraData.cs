//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//using System;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class LegoCameraData : MonoBehaviour
//{
//    private CSVReader LegoData = new CSVReader();
//    GameObject LegoObj;
//    int x;
//    float y;
//    int z;
//    int w;
//    int h;
//    float posx;
//    float posz;
//    Quaternion rote = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
//    int screanX = 600;
//    int screanY = 450;
//    int SplitX = 36;
//    int SplitY = 30;


//    GameObject target = null; //始点距離最短オブジェクト
//    float tmpDis = 0;           //距離用一時変数
//    GameObject[] LegoObjcts; //整理用格納変数
//    GameObject[] ResultLegoObjcts;//比較用格納変数

//    string[,] ResultLegoObj;
//    float DisX;
//    float DisY;
//    float DisZ;
//    GameObject obj;
//    GameObject Legos;
//    int count = 0;
//    GameObject[] ColorObj;
//    int correctcount;
//    GameObject Evaluation;
//    public GameObject Button1;
//    public GameObject Button2;
//    [SerializeField] Toggle toggle1;
//    [SerializeField] Text text;
//    GameObject del;
//    GameObject del4;

//    // Start is called before the first frame update
//    void Start()
//    {
//        //LegoData.CsvRead("test");
//        LegoData.CsvReadAndroid("20191023");
//        //LegoData.CsvReadAndroid(Main.filename);
//        //LegoData.CsvRead("20191023");
//        obj = Instantiate((GameObject)Resources.Load("obj/0"));
//        del = (GameObject)Resources.Load("obj/delete");
//        del4 = (GameObject)Resources.Load("obj/delete2x4");
//        OnClick();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        text.text = "結果 " + (toggle1.isOn ? "ON" : "OFF");
//        if (toggle1.isOn)
//        {
//            Evaluation.SetActive(true);
//        }
//        else
//        {
//            Evaluation.SetActive(false);
//        }
//    }
//    public void OnClick()
//    {
//        //Lego出力
//        for (int i = 0; i < LegoData.csvDatas.Count; i++)
//        {
//            LegoObj = (GameObject)Resources.Load("obj/" + LegoData.csvDatas[i][0]);
//            x = int.Parse(LegoData.csvDatas[i][1]);
//            y = float.Parse(LegoData.csvDatas[i][6])*0.6f;
//            z = int.Parse(LegoData.csvDatas[i][2]);
//            w = int.Parse(LegoData.csvDatas[i][3]);
//            h = int.Parse(LegoData.csvDatas[i][4]);
//            rote = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

//            if (LegoData.csvDatas[i][0].Contains("2x2"))
//            {
//                posx = (x / (screanX / SplitX)) * 0.45f;
//                posz = -(z / (screanY / SplitY)) * 0.45f;
//            }
//            else if (LegoData.csvDatas[i][0].Contains("2x4"))
//            {
//                posx = ((x / (screanX / SplitX)) * 0.45f) + 0.45f;
//                posz = -((z / (screanY / SplitY)) * 0.45f);
//                if (w < h)
//                {
//                    posx = ((x / (screanX / SplitX)) * 0.45f);
//                    posz = -((z / (screanY / SplitY)) * 0.45f) - 0.45f;
//                    rote = new Quaternion(0.0f, 1.0f, 0.0f, 1.0f);
//                }
//            }
//            Instantiate(LegoObj, new Vector3(posx, y, posz), rote);
//        }
//        //Lego整理
//        target = serchTag("NewLego");
//        DisX = target.transform.position.x - obj.transform.position.x;
//        DisY = target.transform.position.y - obj.transform.position.y;
//        DisZ = target.transform.position.z - obj.transform.position.z;
//        target.transform.position = obj.transform.position;
//        LegoObjcts = GameObject.FindGameObjectsWithTag("NewLego");
//        Legos = Instantiate((GameObject)Resources.Load("obj/Lego"));
//        for (int i = 0; i < LegoObjcts.Length; i++)
//        {
//            LegoObjcts[i].transform.position = new Vector3(LegoObjcts[i].transform.position.x - DisX, LegoObjcts[i].transform.position.y - DisY, LegoObjcts[i].transform.position.z - DisZ);
//            if (LegoObjcts[i].transform.position.x < 0)
//            {
//                LegoObjcts[i].tag = "OldLego";
//                Destroy(LegoObjcts[i]);
//            }
//            if (i != 0)
//            {
//                for (int j = i - 1; j >= 0; j--)
//                {
//                    if (LegoObjcts[i].transform.position == LegoObjcts[j].transform.position)
//                    {
//                        LegoObjcts[i].tag = "OldLego";
//                        Destroy(LegoObjcts[i]);
//                    }
//                }
//            }
//        }
//    }
//    public void OnClickComparison()
//    {
//        correctcount = 0;
//        ResultLegoObjcts = GameObject.FindGameObjectsWithTag("NewLego");
//        ResultLegoObj = new string[ResultLegoObjcts.Length, 2];
//        target = serchTag("NewLego");
//        //Debug.Log(target + ":" + target.transform.position);
//        //StreamWriter sw = new StreamWriter("Assets/Resources/text/LegoTestData.txt", false);// TextData.txtというファイルを新規で用意
//        StreamWriter sw = new StreamWriter(Application.persistentDataPath+"/LegoTestData.txt", false);
//        //StreamWriter sw = new StreamWriter("lego/LegoTestData.txt", false);
//        for (int i = 0; i < ResultLegoObjcts.Length; i++)
//        {
//            //自身と取得したオブジェクトの距離を取得
//            tmpDis = Vector3.Distance(ResultLegoObjcts[i].transform.position, target.transform.position);
//            ResultLegoObj[i, 0] = ResultLegoObjcts[i].name;
//            ResultLegoObj[i, 1] = tmpDis.ToString();
//            sw.WriteLine(ResultLegoObj[i, 0] + "," + ResultLegoObjcts[i].transform.position.x + "," + ResultLegoObjcts[i].transform.position.y + "," + ResultLegoObjcts[i].transform.position.z + "," + ResultLegoObj[i, 1]);// ファイルに書き出したあと改行
//            // Debug.Log(ResultLegoObj[i, 0] + "," + ResultLegoObjcts[i].transform.position.x + "," + ResultLegoObjcts[i].transform.position.y + "," + ResultLegoObjcts[i].transform.position.z + "," + ResultLegoObj[i, 1]);
//            ResultLegoObjcts[i].transform.parent = Legos.transform;

//        }
//        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
//        sw.Close();// ファイルを閉じる

//        CSVReader ResultData = new CSVReader();
//        ResultData.CsvRead(Select.GoalName);
//        //ResultData.CsvRead("birdaaa");

//        for (int i = 0; i < ResultLegoObjcts.Length; i++)
//        {
//            for (int j = 0; j < ResultData.csvDatas.Count; j++)
//            {
//                //Debug.Log(ResultLegoObj[i,0]+"=="+ ResultData.csvDatas[j][0]);

//                if (ResultLegoObj[i,0].Contains("Red"))
//                {
//                    if (ResultLegoObj[i, 0].Replace("_Red(Clone)", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(ResultLegoObj[i, 1]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][4]) * 100)) )//ResultLegoObj[i, 1]== ResultData.csvDatas[j][4]
//                    {
//                        ResultLegoObj[i,0]= null;
//                        correctcount++;
//                        break;
//                    }
//                }
//                else if (ResultLegoObj[i, 0].Contains("Blue"))
//                {
//                    if (ResultLegoObj[i, 0].Replace("_Blue(Clone)", "") == ResultData.csvDatas[j][0] && Math.Abs(Math.Round(float.Parse(ResultLegoObj[i, 1]) * 100)) == Math.Abs(Math.Round(float.Parse(ResultData.csvDatas[j][4]) * 100)))//ResultLegoObj[i, 1] == ResultData.csvDatas[j][4])
//                    {
//                        ResultLegoObj[i, 0] = null;
//                        correctcount++;
//                        break;
//                    }
//                }
//            }
//        }
//        for(int i = 0; i < ResultLegoObjcts.Length; i++)
//        {
//            if (ResultLegoObj[i, 0] != null)
//            {
//                //Debug.Log(ResultLegoObjcts[i].transform.position);
//                if (ResultLegoObj[i,0].Contains("2x2"))
//                {
//                    Instantiate(del, ResultLegoObjcts[i].transform.position, ResultLegoObjcts[i].transform.rotation);
//                }
//                if (ResultLegoObj[i, 0].Contains("2x4"))
//                {
//                    Instantiate(del4, ResultLegoObjcts[i].transform.position, ResultLegoObjcts[i].transform.rotation);
//                }
//            }
//                //Debug.Log("abc"+ResultLegoObj[i, 0]);
//        }
//        //Debug.Log(correctcount);
//        if (correctcount == ResultData.csvDatas.Count)
//        {
//            Music.MusicPlay3();
//            Evaluation = this.transform.Find(Select.GoalName + "_Good").gameObject;
//            //Evaluation = this.transform.Find("Bird_Good").gameObject;
//        }
//        else
//        {
//            Music.MusicPlay4();
//            Evaluation = this.transform.Find(Select.GoalName + "_Bad").gameObject;
//            //Evaluation = this.transform.Find("Bird_Bad").gameObject;
//        }
//        Evaluation.SetActive(true);
//        Button2.SetActive(false);
//    }
//    public void OnClickColor()
//    {
//        ColorObj = GameObject.FindGameObjectsWithTag("Hit");
//        for (int i = 0; i < ColorObj.Length; i++)
//        {
//            ColorObj[i].GetComponent<BoxCollider>().enabled = true;
//        }
//        Button1.SetActive(false);
//        Button2.SetActive(true);
//    }
//    public void OnClickBack()
//    {
//        ColorDepth.webcamtex.Stop();
//        SceneManager.LoadScene("Start");
//    }
//    //指定されたタグの中で最も近いものを取得
//    GameObject serchTag(string tagName)
//    {
//        float tmpDis = 0;           //距離用一時変数
//        float nearDis = 0;          //最も近いオブジェクトの距離
//                                    //string nearObjName = "";    //オブジェクト名称
//        GameObject targetObj = null; //オブジェクト

//        //タグ指定されたオブジェクトを配列で取得する
//        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
//        {
//            //自身と取得したオブジェクトの距離を取得
//            tmpDis = Vector3.Distance(obs.transform.position, obj.transform.position);

//            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
//            //一時変数に距離を格納
//            if (nearDis == 0 || nearDis > tmpDis)
//            {
//                nearDis = tmpDis;
//                //nearObjName = obs.name;
//                targetObj = obs;
//            }
//        }
//        return targetObj;
//    }
//}
