//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Lego : MonoBehaviour
//{
//    int N = 100;
//    private CSVReader LegoData = new CSVReader();
//    public GameObject obj;
//    public GameObject objchild;
//    float posx;
//    float posy;
//    float posz;
//    float objw;
//    float objh;
//    int r;
//    string[,] LegoDatas;
//    int screanX = 600;
//    int screanY = 450;
//    int Split = 9;

//    bool display=true;

//    void Start()
//    {
//        LegoDatas = new string[N, N];
//        LegoCreate();
//    }
//    void LegoCreate()
//    {
//        Initialize();
//        LegoData.CsvRead("test");

//        for (int i = 0; i < LegoData.csvDatas.Count; i++)
//        {
//            Quaternion rote = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
//            for (int j = 0; j < LegoData.csvDatas[i].Length; j++)
//            {
//                Debug.Log(LegoData.csvDatas[i][0]);
//                if (!String.IsNullOrEmpty(LegoData.csvDatas[i][0]))
//                {
                    
//                    posx = (int)(float.Parse(LegoData.csvDatas[i][1]) / (screanX / Split)) *0.9f;
//                    posz = (int)(float.Parse(LegoData.csvDatas[i][2]) / (screanY / Split)) *0.9f;
//                    //posy = float.Parse(LegoData.csvDatas[i][6]) * 0.6f;

//                    if (LegoData.csvDatas[i][0] == "2x2")
//                    {
//                        objw = 0.9f;
//                        objh = 0.9f;
//                    }
//                    else
//                    {

//                        objw = float.Parse(LegoData.csvDatas[i][3]) / (screanX / Split);
//                        objh = float.Parse(LegoData.csvDatas[i][4]) / (screanY / Split);
//                        if (objw < objh)
//                        {
//                            rote = new Quaternion(0.0f, 1.0f, 0.0f, 1.0f);
//                        }
//                        else
//                        {
//                            posx = posx + 0.9f;
//                        }
//                    }
//                    //int sizeGcd = Gcd(objw,objh); // sizeX‚ÆsizeY‚ÌÅ‘åŒö–ñ”
//                    //objw = objw / sizeGcd;
//                    //objh = objh / sizeGcd;
//                    //Debug.Log(objw + ":" + objh);
//                    //if (objw == 1 && objh == 1)
//                    //{
//                    //    obj = (GameObject)Resources.Load("obj/2x2");
//                    //}
//                }
//            }
//            //if (objw < objh) rote = new Quaternion(0.0f, 1.0f, 0.0f, 1.0f);
//            if (!String.IsNullOrEmpty(LegoData.csvDatas[i][0]) && float.Parse(LegoData.csvDatas[i][1]) > 48f)
//            {
//                //for (int k = 0; k < LegoDatas.Length; k++)
//                //{
//                //    if (k == 0)
//                //    {
//                //        //posx = Creatposition(posx);
//                //        //posz = Creatposition(posz);

//                //        LegoDatas[k, 0] = LegoData.csvDatas[i][0];
//                //        LegoDatas[k, 1] = posx.ToString();
//                //        LegoDatas[k, 2] = posz.ToString();
//                //        LegoDatas[k, 3] = (posx + objw).ToString();
//                //        LegoDatas[k, 4] = (posz + objh).ToString();
//                //       // LegoDatas[k, 5] = LegoData.csvDatas[i][6];

//                //    }
//                //    for (int l = 0; l < LegoDatas.Length; l++)
//                //    {
//                //        Debug.Log(LegoDatas[k, l]);
//                //    }

//                //    if (k > 0 && LegoDatas[k - 1, 1] != posx.ToString() && LegoDatas[k - 1, 2] != posy.ToString() && LegoDatas[k - 1, 5] != LegoData.csvDatas[i][6])
//                //    {
//                //        //posx = Creatposition(posx);
//                //        //posz = Creatposition(posz);
//                //        LegoDatas[k, 0] = LegoData.csvDatas[i][0];
//                //        LegoDatas[k, 1] = posx.ToString();
//                //        LegoDatas[k, 2] = posz.ToString();
//                //        //LegoDatas[k, 3] = LegoData.csvDatas[i][6];
//                //    }
//                //}
//                obj = (GameObject)Resources.Load("obj/" + LegoData.csvDatas[i][0].Replace("(Clone)",""));
//                objchild = Instantiate(obj, new Vector3(posx, posy,-posz), rote);
//                //Debug.Log(i + "," + posz);
//            }
//        }
//    }
//    float Creatposition(float pos)
//    {
//        for (int k = 1; k <= Split; k++)
//        {
//            if (pos < k)
//            {
//                return pos = 0.9f * k;
//            }
//        }
//        return pos;
//    }

//    void Initialize()
//    {
//        LegoData = new CSVReader();
//        posx = 0;
//        posy = 0;
//        posz = 0;
//        r = 0;
//    }

//    void LegoCheck()
//    {

//    }
//    //public static int Gcd(float a, float b)
//    //{
//    //    if (a < b)
//    //    {
//    //        return Gcd(b, a); // a >= b‚Æ‚È‚é‚æ‚¤‚É
//    //    }
//    //    while (b != 0)
//    //    {
//    //        float temp = a % b;
//    //        a = b;
//    //        b = temp;
//    //    }
//    //    return a;
//    //}
//}
