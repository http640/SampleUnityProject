using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    public Collection.PanelType panelState;
    public GameObject previousPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && panelState == Collection.PanelType.leaderBoard)
        {
            Back();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && panelState != Collection.PanelType.leaderBoard && previousPanel)
        {
            PanelNavigator.Instance.ActiveCurrentPanel(previousPanel);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !previousPanel )
        {
            Debug.Log("Exit");
        }
    }

    public void Back()
    {
        if(PanelNavigator.Instance.lastActivatedPanel == null)
        {
            previousPanel = PanelNavigator.Instance.WhatPanelIsActive();
            //print("In if - Back - PreviousPanel is " + previousPanel);
        }
       
        else
        {
            //print("In else - Back - PreviousPanel is " + PanelNavigator.Instance.lastActivatedPanel);
            PanelNavigator.Instance.ActiveCurrentPanel(PanelNavigator.Instance.lastActivatedPanel);
        }

    }


}
