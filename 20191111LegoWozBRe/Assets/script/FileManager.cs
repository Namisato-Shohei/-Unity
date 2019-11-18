//// データを初期化するか？
////#define DATA_INIT

//using UnityEngine;
//using System.IO;
//using System.Text;
//using System.Collections;
//using System;


///// ファイル管理
//public class FIleManager
//{
//    //StreamingAssetsからの読み込み、WWWを使用
//    public static T ReadFromStreaming<T>(string fileName)
//    {
//        var fullPath = DataLoader.GetFilePathFromStreaming() + fileName;
//        //WWWを使った読み込みは可能
//        WWW www = new WWW(fullPath);
//        //終わるまで待機。非同期で読み込む際はyieldを使用
//        while (!www.isDone) { }
//        string readText = www.text;
//        //必要ならBOMなしに変換
//        if (HasBomWithText(www.bytes)) readText = GetDeletedBomText(www.text);
//        //TextReaderを用いてstringからデータ読み込み
//        using (TextReader stream = new StringReader(readText))
//        {
//            var serializer = new XmlSerializer(typeof(T));
//            return (T)serializer.Deserialize(stream);
//        }
//    }
//    //persistentDataPathからの読み込み
//    public static T ReadFromPersistent<T>(string fileName)
//    {
//        var fullPath = DataLoader.GetFilePathFromPersistent() + fileName;
//        //内部ではFileStreamを利用
//        return XMLUtility.Deserialize<T>(fullPath);
//    }
//    //persistentDataPathへの書き込み
//    public static void WriteToPersistent<T>(string fileName, T data)
//    {
//        var fullPath = GetFilePathFromPersistent() + fileName;
//        XMLUtility.Seialize<T>(fullPath, data);
//    }
//    //BOM有無の判定
//    static bool HasBomWithText(byte[] bytes)
//    {
//        return bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF;
//    }
//    //BOM消し
//    static string GetDeletedBomText(string text)
//    {
//        return text.Remove(0, 1);
//    }
//    //persistentDataPathのパスを返す
//    static string GetFilePathFromPersistent()
//    {
//        return Application.persistentDataPath + "/";
//    }
//    //プラットフォーム毎のStreamingAssetsのパスを返す
//    static string GetFilePathFromStreaming()
//    {
//#if UNITY_EDITOR
//        return "file:///" + Application.dataPath + "/StreamingAssets/";
//#elif UNITY_IPHONE || UNITY_ANDROID
//      return "jar:file://" + Application.dataPath + "!/assets" + "/";
//#endif
//    }
//}
