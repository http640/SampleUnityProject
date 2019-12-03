using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instanse { set; get; }
    
    public int  maxLevel = 30;
    public string topScore;
    public string packageAndStory;

    private void Awake()
    {
        Instanse = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Active panel StartMenu in Start
        PanelNavigator.Instance.ActiveCurrentPanel(PanelNavigator.Instance.panels[4]);
    }
    public int MaxLevel
    {
        get
        {
            return maxLevel;
        }
    }
    
    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
}
