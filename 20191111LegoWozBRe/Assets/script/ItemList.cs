using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemList : MonoBehaviour
{
    //public AudioClip sound1;
    //public AudioClip sound2;
    //AudioSource audioSource;

    public List<GameObject> btnList = new List<GameObject>();

    // 選択されている状態を示すキーワード
    public string selectedSymbol = "Selected";
    // 選択状態にあるアイテムの番号を保存する
    public int selectedItemId = -1;
    public static GameObject obj;

    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    public static Vector3 screenToWorldPointPosition;


    public EventSystem eventSystem;
    public GameObject selectedGameObject;
    GameObject Plane;
    public static float y=0;


    //[SerializeField] Toggle toggle1;
    //[SerializeField] Toggle toggle2;
    //[SerializeField] Text text1;
    //[SerializeField] Text text2;
    //[SerializeField] GameObject Rule;
    //[SerializeField] GameObject HowPlay;

    // Start is called before the first frame update
    void Start()
    {

        int i = 0;
        while (GameObject.Find("Button (" + i.ToString() + ")") != null)
        {
            btnList.Add(GameObject.Find("Button (" + i.ToString() + ")"));
            i++;
        }
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //if (Select.GoalName == "Bird" || Select.GoalName == "Sample")
        //{
        //    Plane = (GameObject)Resources.Load("obj/Plane0");
        //    Instantiate((GameObject)Resources.Load("obj/Camera0"));
        //}
        //else if(Select.GoalName == "Chair")
        //{
        //    Plane = (GameObject)Resources.Load("obj/Plane4");
        //}
        //Instantiate(Plane);

        //audioSource = GetComponent<AudioSource>();
    }

    public void OnClick2x2R()
    {
        click(btnList[0]);
    }
    public void OnClick2x2G()
    {
        click(btnList[1]);
    }
    public void OnClick2x2B()
    {
        click(btnList[2]);
    }
    public void OnClick2x2Y()
    {
        click(btnList[3]);
    }

    public void OnClick2x4R()
    {
        click(btnList[4]);
    }
    public void OnClick2x4G()
    {
        click(btnList[5]);
    }
    public void OnClick2x4B()
    {
        click(btnList[6]);
    }
    public void OnClick2x4Y()
    {
        click(btnList[7]);
    }
    public void OnClick2x2W()
    {
        click(btnList[8]);
    }
    public void OnClick2x4W()
    {
        click(btnList[9]);
    }


    // アイテムリストを選択したときの処理
    public void click(GameObject btnObject)
    {
        if (obj == null)
        {
            //audioSource.PlayOneShot(sound1);
            Music.MusicPlay1();
            string im_name = btnObject.GetComponent<Image>().sprite.name;
            // 選択されたボタンの番号を取得
            int id = int.Parse(btnObject.name.Substring("Button (".Length, btnObject.name.Length - "Button ()".Length));

            // 既に選択状態なら選択状態を解除する
            if (id == selectedItemId)
            {

                im_name = im_name.Substring(selectedSymbol.Length);
                btnObject.GetComponent<Image>().sprite = Resources.Load("Image/" + im_name, typeof(Sprite)) as Sprite;
                selectedItemId = -1;

            }
            else if (im_name != null)
            {   // 何かのアイテムが割り当てられていたら

                // 他に選択状態のアイテムがあるなら非選択状態に変更
                if (selectedItemId != -1)
                {
                    string temp = btnList[selectedItemId].GetComponent<Image>().sprite.name.Substring(selectedSymbol.Length);
                    btnList[selectedItemId].GetComponent<Image>().sprite = Resources.Load("Image/" + temp, typeof(Sprite)) as Sprite;
                    selectedItemId = -1;
                }

                // 選択状態にする
                btnObject.GetComponent<Image>().sprite = Resources.Load("Image/" + selectedSymbol + im_name, typeof(Sprite)) as Sprite;
                selectedItemId = id;
                if (id == 0)
                {
                    obj = (GameObject)Resources.Load("obj/2x2_Red");
                }
                if (id == 1)
                {
                    obj = (GameObject)Resources.Load("obj/2x2_Green");
                }
                if (id == 2)
                {
                    obj = (GameObject)Resources.Load("obj/2x2_blue");
                }
                if (id == 3)
                {
                    obj = (GameObject)Resources.Load("obj/2x2_Yellow");
                }
                if (id == 4)
                {
                    obj = (GameObject)Resources.Load("obj/2x4_Red");
                }
                if (id == 5)
                {
                    obj = (GameObject)Resources.Load("obj/2x4_Green");
                }
                if (id == 6)
                {
                    obj = (GameObject)Resources.Load("obj/2x4_blue");
                }
                if (id == 7)
                {
                    obj = (GameObject)Resources.Load("obj/2x4_Yellow");
                }
                if (id == 8)
                {
                    obj = (GameObject)Resources.Load("obj/2x2_White");
                }
                if (id == 9)
                {
                    obj = (GameObject)Resources.Load("obj/2x4_White");
                }
                // Vector3でマウス位置座標を取得する
                position = Input.mousePosition;
                // Z軸修正
                position.z = 10f;
                // マウス位置座標をスクリーン座標からワールド座標に変換する
                screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
                if (obj != null)
                {
                    // ワールド座標に変換されたマウス座標を代入
                    obj = Instantiate(obj, new Vector3(screenToWorldPointPosition.x, 0.6f, screenToWorldPointPosition.z), Quaternion.identity);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (obj != null)
        {
            //if (Hit.Flag == 0)
            //{
                // Vector3でマウス位置座標を取得する
                position = Input.mousePosition;
            Debug.Log(position);
                // Z軸修正
                position.z = 10f;
                // マウス位置座標をスクリーン座標からワールド座標に変換する
                screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

                screenToWorldPointPosition.x = (int)(screenToWorldPointPosition.x / 0.45f) * 0.45f;
                //screenToWorldPointPosition.y = (int)(screenToWorldPointPosition.y / 0.6f) * 0.6f;
                screenToWorldPointPosition.z = (int)(screenToWorldPointPosition.z / 0.45f) * 0.45f;
               
                if (y <= 0f)
                {
                    y = 0f;
                }
                //if (screenToWorldPointPosition.y <= 0f)
                //{
                //    screenToWorldPointPosition.y = 0f;
                //}
                if (Input.GetMouseButtonUp(1))
                {
                Music.MusicPlay1();
                obj.transform.Rotate(0, 90, 0);
                }
            if (Input.GetKeyUp(KeyCode.U))
            {
                Music.MusicPlay1();
                y += 0.6f;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Music.MusicPlay1();
                y -= 0.6f;
            }

            //}
            //else if (Hit.Flag == 1)
            //{
            //    y = 0.6f;
            //}
            // ワールド座標に変換されたマウス座標を代入
            obj.transform.position = new Vector3(screenToWorldPointPosition.x,y,screenToWorldPointPosition.z);
            if (position.x>265 && Input.GetMouseButtonDown(0))
            {
                Music.MusicPlay2();
                //audioSource.PlayOneShot(sound2);
                //Hit.Flag = 0;
                obj.tag = "OldLego";
                //if(obj.transform.position.x<0f )//|| obj.transform.position.z < 0f)
                //{
                //    Destroy(obj);
                //}
                string temp = btnList[selectedItemId].GetComponent<Image>().sprite.name.Substring(selectedSymbol.Length);
                btnList[selectedItemId].GetComponent<Image>().sprite = Resources.Load("Image/" + temp, typeof(Sprite)) as Sprite;
                selectedItemId = -1;
                obj = null;
            }
        }
        //text1.text = "ルール " + (toggle1.isOn ? "ON" : "OFF");
        //if (toggle1.isOn)
        //{
        //    Rule.SetActive(true);
        //}
        //else
        //{
        //    Rule.SetActive(false);
        //}
        //text2.text = "そうさほうほう " + (toggle2.isOn ? "ON" : "OFF");
        //if (toggle2.isOn)
        //{
        //    HowPlay.SetActive(true);
        //}
        //else
        //{
        //    HowPlay.SetActive(false);
        //}

    }
    //public void OnClickClose()
    //{
    //    toggle1.isOn = false;
    //}
}
