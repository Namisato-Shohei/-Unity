using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music : MonoBehaviour
{

    public static AudioClip sound1;
    public static AudioClip sound2;
    public static AudioClip sound3;
    public static AudioClip sound4;
    public static AudioClip[] sounds;
    string[] musicname;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        int num = 13;
        sounds = new AudioClip[num];
        musicname = new string[num];
        audioSource = GetComponent<AudioSource>();
        //sound1 = Resources.Load("music/ボタン音46")as AudioClip;
        //sound2 = Resources.Load("music/ボタン音40") as AudioClip;
        //sound3 = Resources.Load("music/合格！（キンコンカンコン）") as AudioClip;
        //sound4 = Resources.Load("music/クイズ・残念02") as AudioClip;
        musicname[0] = "ボタン音46";
        musicname[1] = "ボタン音40";
        musicname[2] = "合格！（キンコンカンコン）";
        musicname[3] = "クイズ・残念02";
        musicname[4] = "bgm_maoudamashii_8bit01";
        musicname[5] = "bgm_maoudamashii_8bit02";
        musicname[6] = "bgm_maoudamashii_8bit29";
        musicname[7] = "bgm_maoudamashii_ethnic14";
        musicname[8] = "bgm_maoudamashii_fantasy05";
        musicname[9] = " drum - roll1";
        musicname[10] = " fate2";
        musicname[11] = " trumpet1";
        musicname[12] = "se_maoudamashii_chime14";
        for (int i = 0; i < musicname.Length; i++)
        {
            //Debug.Log(musicname[i]);
            sounds[i] = Resources.Load("music/" + musicname[i]) as AudioClip;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void MusicPlay1()
    {
        audioSource.PlayOneShot(sounds[0]);
    }
    public static void MusicPlay2()
    {
        audioSource.PlayOneShot(sounds[1]);
    }
    public static void MusicPlay3()
    {
        audioSource.PlayOneShot(sound3);
    }
    public static void MusicPlay4()
    {
        audioSource.PlayOneShot(sound4);
    }
    public static void MusicPlay(int n)
    {
        audioSource.PlayOneShot(sounds[n]);
    }

}
