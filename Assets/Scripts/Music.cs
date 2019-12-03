using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Music : MonoBehaviour
{
    private AudioClip _audioClip;
    private string _URL;

    public Music(string url)
    {
        _URL = url;
    }

    public AudioClip Audio
    {
        get
        {
            return _audioClip;
        }
        set
        {
           
            _audioClip = value;
        }
    }
    public string URL
    {
        get
        {
            return _URL;
        }
        set
        {
            _URL = value;
        }
    }
}
