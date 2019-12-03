using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraphicBank : MonoBehaviour
{
    public static GeraphicBank Instance { private set; get; }
    public void Awake()
    {
        Instance = this;
    }

    public List<Sprite> avatarList;
    public List<Sprite> playState;
    public Sprite GetAvatarSprite(int index)
    {
        return avatarList[index];
    }
    public Sprite GetPlayState(int index)
    {
        return playState[index];
    }



}
