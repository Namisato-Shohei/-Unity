//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class ColorDepth : MonoBehaviour
//{
//    int width = 1920;
//    int height = 1080;
//    int fps = 30;
//    Texture2D texture;
//    public static WebCamTexture webcamTexture;
//    Color32[] colors = null;

//    IEnumerator Init()
//    {
//        while (true)
//        {
//            if (webcamTexture.width > 16 && webcamTexture.height > 16)
//            {
//                colors = new Color32[webcamTexture.width * webcamTexture.height];
//                texture = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
//                GetComponent<Renderer>().material.mainTexture = texture;
//                break;
//            }
//            yield return null;
//        }
//    }

//    // Use this for initialization
//    void Start()
//    {
//        WebCamDevice[] devices = WebCamTexture.devices;
//        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
//        if (webcamTexture.isPlaying == false) webcamTexture.Play();
//        DontDestroyOnLoad(gameObject);
//        StartCoroutine(Init());
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (webcamTexture.isPlaying == false) webcamTexture.Play();
//        if (colors != null)
//        {
//            webcamTexture.GetPixels32(colors);

//        //    int width = webcamTexture.width;
//        //    int height = webcamTexture.height;
//        //    Color32 rc = new Color32();

//        //    for (int x = 0; x < width; x++)
//        //    {
//        //        for (int y = 0; y < height; y++)
//        //        {
//        //            Color32 c = colors[x + y * width];
//        //            byte gray = (byte)(0.1f * c.r + 0.7f * c.g + 0.2f * c.b);
//        //            rc.r = rc.g = rc.b = gray;
//        //            colors[x + y * width] = rc;
//        //        }
//        //    }

//            texture.SetPixels32(colors);
//            texture.Apply();
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorDepth : MonoBehaviour
{
    public static WebCamTexture webcamtex;
    private AsyncOperation async;
    // Use this for initialization
    void Start()
    {
        WebCamDevice[] webCamDev = WebCamTexture.devices;
        webcamtex = new WebCamTexture(webCamDev[0].name, 1280, 720, 30);

        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material.mainTexture = webcamtex;
        if (webcamtex.isPlaying == false) webcamtex.Play();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (webcamtex.isPlaying == false) webcamtex.Play();
    }
}