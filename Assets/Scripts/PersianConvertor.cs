using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersianConvertor : MonoBehaviour
{
    public InputField input;
    public Text resultTest;
    public void OnChane()
    {
        resultTest.text = Fa.faConvert(input.text);
    }
}
