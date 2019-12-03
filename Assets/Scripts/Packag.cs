using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Packag : MonoBehaviour
{
    public string storyAndPackage;
    public GameObject newPackageButton;
    public Transform contentPanel;

    private Texture2D _downloadedImage;
    private Sprite packageImage;
    // Start is called before the first frame update
    void Start()
    {
        JSONNode fetch = JSON.Parse(storyAndPackage);
        Init(fetch);
    }

    public void Init(JSONNode fetch)
    {
        //Debug.Log(fetch["data"]["playerGameInfo"]["challengePacks"]);
        foreach (JSONNode item in fetch["data"]["playerGameInfo"]["challengePacks"])
        {
            InitScoreShow(item);
        }
    }
    public void InitScoreShow(JSONNode item)
    {
        GameObject newScore = Instantiate(newPackageButton) as GameObject;
        SetButtonInfoes generate = newScore.GetComponent<SetButtonInfoes>();
        
        
        generate.SetPackageButtonInfo(item["name"], item["scores"], item["image"]);
        newScore.transform.SetParent(contentPanel);
        newScore.transform.localScale = Vector3.one;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
