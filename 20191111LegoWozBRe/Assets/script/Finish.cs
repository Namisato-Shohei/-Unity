using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Finish : MonoBehaviour
{
    public static GameObject[] result;
    public static string[,] resultdata;
    float tmpDis = 0;           //距離用一時変数
    //float nearDis = 0;          //最も近いオブジェクトの距離
    GameObject target = null; //オブジェクト

    Process process;
    // プロセスを起動させるbatファイルが格納されたディレクトリのパス
    string scriptPath = "Assets/Resources/";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        result = GameObject.FindGameObjectsWithTag("OldLego");
        for(int i = 0; i < result.Length; i++)
        {
            if (result[i].transform.position.y == 0)
            {
                result[i].tag = "Target";
            }
        }
        target =serchTag("Target");
        for (int i = 0; i < result.Length; i++)
        {
                result[i].tag = "OldLego";
        }
        resultdata = new string[result.Length,9];
        //Directory.CreateDirectory("Assets/Resources/text/user/" + Main.filename);
        //StreamWriter sw = new StreamWriter("Assets/Resources/text/user/"+Main.filename+"/"+Select.GoalName+".txt", true);// TextData.txtというファイルを新規で用意
        StreamWriter sw = new StreamWriter("Assets/Resources/text/LegoData.txt");
        //sw.WriteLine(Select.GoalName);
        for (int i = 0; i < result.Length; i++){
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(result[i].transform.position, target.transform.position);

            sw.WriteLine(result[i].name.Replace("(Clone)","")+","+result[i].transform.position.x + "," + result[i].transform.position.y + "," + result[i].transform.position.z+","+ result[i].transform.rotation.x+","+ result[i].transform.rotation.y+","+ result[i].transform.rotation.z+","+ result[i].transform.rotation.w + "," +tmpDis);// ファイルに書き出したあと改行
            resultdata[i, 0] = result[i].name;
            resultdata[i, 1] = result[i].transform.position.x.ToString();
            resultdata[i, 2] = result[i].transform.position.y.ToString();
            resultdata[i, 3] = result[i].transform.position.z.ToString();
            resultdata[i, 4] = result[i].transform.rotation.x.ToString();
            resultdata[i, 5] = result[i].transform.rotation.y.ToString();
            resultdata[i, 6] = result[i].transform.rotation.z.ToString();
            resultdata[i, 7] = result[i].transform.rotation.w.ToString();
            resultdata[i, 8] = tmpDis.ToString();

        }
        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        sw.Close();// ファイルを閉じる
        //SceneManager.LoadScene("Replace");

        //callBatFile("legodatasend.bat");
    }
    public void OnclicAllDel()
    {
        for (int i = 0; i < result.Length; i++)
        {
            ItemList.y = 0;
            Destroy(result[i]);
        }
    }
    /* アプリを起動/終了させるbatファイルを実行 */
    private void callBatFile(string batFilePath)
    {
        // 他のプロセスが実行しているなら行わない
        if (process != null) return;

        // 新規プロセスを作成し、batファイルのパスを登録
        process = new Process();
        process.StartInfo.FileName = scriptPath + batFilePath;
        print(process.StartInfo.FileName);
        // 外部プロセスの終了を検知するための設定
        process.EnableRaisingEvents = true;
        process.Exited += process_Exited;

        // 外部プロセスを実行
        process.Start();
    }

    // 外部プロセスの終了を検知してプロセスを終了
    void process_Exited(object sender, System.EventArgs e)
    {
        process.Dispose();
        process = null;
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
                                    //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, this.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }
        return targetObj;
    }
}
