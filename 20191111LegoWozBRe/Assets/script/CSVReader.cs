using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{

    public List<string[]> csvDatas;
    FileInfo file;

    public void CsvRead(string csvName)
    {
        csvDatas=new List<string[]>();
        // csvをロード
        TextAsset csv = Resources.Load("text/"+csvName) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            // ','ごとに区切って配列へ格納
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }
    public void CsvReadAndroid(string csvName)
    {
        csvDatas = new List<string[]>();
        // csvをロード
        //TextAsset csv = Application.persistentDataPath+"/" + csvName;
        file = new FileInfo(Application.persistentDataPath + "/" + csvName + ".txt");
        StreamReader reader = new StreamReader(file.OpenRead());

        while (reader.Peek() > -1)
        {
            // ','ごとに区切って配列へ格納
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }
}