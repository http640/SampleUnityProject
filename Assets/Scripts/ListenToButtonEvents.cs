using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ListenToButtonEvents : MonoBehaviour
{
    public static event Action<Collection.ButtonType> OnButtonEventRecived;
    public void Awake()
    {
        OnButtonEventRecived += OnButtonClicked;
    }

    public void OnButtonClicked(Collection.ButtonType buttonType)
    {

    }
}
