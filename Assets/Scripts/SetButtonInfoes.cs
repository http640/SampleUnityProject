using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class SetButtonInfoes : MonoBehaviour
{
    public Text nameLbl;
    public Text scoreLbl;
    public Image avatarIcon;
    public GameObject loading;
    public Text levelNumber;    //for LevelBtnInfo
    public Image banner;        //for LevelBtnInfo
    public Image[] stars;       //for LevelBtnInfo
    private Collection.LevelStatus buttonState;
    public int buttonIndex;
    public Button thisButton;
    


    public void SetLeaderBoardInfo(string name,string score, Sprite avatar)
    {
        nameLbl.text = Fa.faConvert(name) + Fa.faConvert("نام: ") ;
        scoreLbl.text = Fa.faConvert(score) + Fa.faConvert("امتیاز: ");
        avatarIcon.sprite = avatar;
    }

    public void SetPackageButtonInfo(string name, string score, string imageUrl)
    {
        nameLbl.text = Fa.faConvert(name) + Fa.faConvert("نام: ") ;
        scoreLbl.text = Fa.faConvert(score) + Fa.faConvert("امتیاز: ");
        StartCoroutine(DownloadImage(imageUrl));
    }

    public void SetStoryBoardButtonInfo(int levelIndex , Collection.LevelStatus levelStatus , int score , int starCount)
    {
        buttonIndex = levelIndex;
        levelNumber.text = (buttonIndex+1).ToString();
        buttonState = levelStatus;
        scoreLbl.text = score.ToString();
        thisButton = this.GetComponent<Button>();
        if (buttonState == Collection.LevelStatus.current)
        {
            avatarIcon.sprite = GeraphicBank.Instance.GetPlayState(1);
            banner.enabled = false;
            scoreLbl.enabled = false;
            foreach (Image item in stars)
                item.enabled = false;
            thisButton.onClick.AddListener( ()=> CallPlayGame(1)); 
        }  
        else if (buttonState == Collection.LevelStatus.passed)
        {
            avatarIcon.sprite = GeraphicBank.Instance.GetPlayState(0);
            banner.enabled = true;
            scoreLbl.enabled = true;
            thisButton = this.GetComponent<Button>();
            thisButton.onClick.AddListener(delegate { TaskOnClick(buttonState); });
            scoreLbl.text = score.ToString();
            for (int i = 2; i > starCount - 1; --i)
                stars[i].enabled = false;  
        }
        else
        {
            avatarIcon.sprite = GeraphicBank.Instance.GetPlayState(2);
            banner.enabled = false;
            scoreLbl.enabled = false;
            thisButton.onClick.AddListener(delegate { TaskOnClick(buttonState); });
            foreach (Image item in stars)
                item.enabled = false;
        }
    }

    public void CallPlayGame(int index)
    {
        GameManager.Instanse.PlayGame(1);
    }

    public void TaskOnClick(Collection.LevelStatus buttonState)
    {
        Debug.Log("Level State: " + buttonState + " You Cannot play it.");
    }
    IEnumerator DownloadImage(string uri)
    {
        loading.SetActive(true);
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return req.SendWebRequest();
            if (req.isHttpError || req.isNetworkError)
            {
                Debug.Log(req.error);
            }
            else
            {
               Texture2D _downloadedImage = DownloadHandlerTexture.GetContent(req);
                avatarIcon.sprite = ConverTextur2DIntoSprite(_downloadedImage);
            }
        }
        loading.SetActive(false);
    }

    public Sprite ConverTextur2DIntoSprite(Texture2D textureDownloaded)
    {
        Sprite sp = Sprite.Create(textureDownloaded, new Rect(0, 0, textureDownloaded.width, textureDownloaded.height), new Vector2(0.5f, 0.5f), 100);
        return sp;
    }

    public void OnClick()
    {
        //ListenToButtonEvents.OnButtonEventRecived();
    }
}
