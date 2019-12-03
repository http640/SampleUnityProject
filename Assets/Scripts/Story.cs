using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;



public class Story : MonoBehaviour
{
    public string storyAndPackage;
    public GameObject newLevel;
    public Transform contentPanel;
    public int maxLevel = 50;
    public int maxScore = 50;
    private int _score = 0;
    private Collection.LevelStatus _levelStatus = Collection.LevelStatus.locked;
    void Start()
    {
        JSONNode fetch = JSON.Parse(storyAndPackage);
        InitLevels(fetch);
    }
    
    public void InitLevels(JSONNode fetch)
    {

        for (int i = 0; i < maxLevel; i++)
        {
            if (i <= fetch["data"]["playerGameInfo"]["storyBoard"].Count - 1)
            {
                _levelStatus = Collection.LevelStatus.passed;
                _score = fetch["data"]["playerGameInfo"]["storyBoard"][i];
            }
            else if (i == fetch["data"]["playerGameInfo"]["storyBoard"].Count )
                _levelStatus = Collection.LevelStatus.current;

            else if (i > fetch["data"]["playerGameInfo"]["storyBoard"].Count)
                _levelStatus = Collection.LevelStatus.locked; 

            SetLevelStatuse(_levelStatus, i );
        }

    }
    public void SetLevelStatuse(Collection.LevelStatus levelStatus,int index )
    {
        GameObject newScore = Instantiate(newLevel) as GameObject;
        
        SetButtonInfoes storyboardBTN = newScore.GetComponent<SetButtonInfoes>();
        storyboardBTN.SetStoryBoardButtonInfo(index, levelStatus, _score, CalculateStarCount(_score));
        newScore.transform.SetParent(contentPanel);
        newScore.transform.localScale = Vector3.one;
    }
    public int CalculateStarCount(int score)
    {
        if (score == 0) return 0;
        else if (score < maxScore / 3) return 1;
        else if (score >= maxScore / 3 && score <= (2 * maxScore) / 3) return 2;
        else return 3;
    }
}
