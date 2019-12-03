using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
public class TopScore : MonoBehaviour
{
    public string topScore;
    public GameObject scoreShow;
    public Transform contentPanel;

    private Image avatarImage;
    // Start is called before the first frame update
    void Start()
    {
        JSONNode fetch = JSON.Parse(topScore);
        Init(fetch);
    }
    public void Init(JSONNode fetch)
    {
        foreach(JSONNode item in fetch["data"]["topScore"])
        {
            InitScoreShow(item);
        }
    }
    public void InitScoreShow(JSONNode item)
    {
        GameObject newScore = Instantiate(scoreShow) as GameObject;
        SetButtonInfoes generate = newScore.GetComponent<SetButtonInfoes>();
        generate.SetLeaderBoardInfo(item[0], item[1], GeraphicBank.Instance.GetAvatarSprite(item[2].AsInt));
        newScore.transform.SetParent(contentPanel);
        newScore.transform.localScale = Vector3.one;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


public class MakeDynamicScrollView
{
    public Transform parent;
    public GameObject InstanseOBJ;

    public void MakeScroll()
    {

    }
}

