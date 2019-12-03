using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{

    public static Web Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    public void StartDownloadAudio(Music music)
    {
        if(LocalDB.LoadData(music) != null)
        {
            music = LocalDB.LoadData(music);
        }
        else
            StartCoroutine(DownloadAudio(music));
        
    }
    IEnumerator DownloadAudio(Music music)
    {
        
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(music.URL, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                while (myClip.loadState != AudioDataLoadState.Loaded)
                    yield return null;
                print("Download Done");
                //save myClip to a file
                music.Audio = myClip;
                LocalDB.SaveData(music);
            }
        }
    }
}
