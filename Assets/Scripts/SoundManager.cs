using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public static string urlString;
    //public Music StartMusic = new Music();
    public Music StartMusic = new Music(urlString);
    public AudioSource source;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        //Web.Instance.StartDownloadAudio(StartMusic);
    }
    public void PlayAudio()
    {
        source.clip = StartMusic.Audio;
        source.Play();
    }
}
