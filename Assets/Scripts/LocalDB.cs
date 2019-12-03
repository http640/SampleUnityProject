using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LocalDB 
{
    
    private static string DATA_path;
    private static AudioClip _startAudio;
    
    public static bool audioSaved;
    
    public static AudioClip StartAudio
    {
        get
        {
            return _startAudio;
        }
        set
        {
            _startAudio = value;
        }
    }
    public static void SaveData(Music music)
    {
        DATA_path = "/StartSound.mp3";
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + DATA_path);
            //encrypt and save the data
            bf.Serialize(file, music);
        }
        catch(Exception exception)
        {
            if(exception != null)
            {
                //handel Exception
                Debug.LogError(exception);
            }
        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }
    
    public static Music LoadData(Music music)
    {
        DATA_path ="/StartSound.mp3";
        FileStream file = null;
        try
        {
            //decrepting and loading data 
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + DATA_path, FileMode.Open);
            music = bf.Deserialize(file) as Music;
        }
        catch(Exception excepsion)
        {
            return null;
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }

        if (File.Exists(Application.persistentDataPath + DATA_path))
            return music;
        else
            return null;
    }

}
