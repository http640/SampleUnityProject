using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNavigator : MonoBehaviour
{
    public static PanelNavigator Instance { get; private set; }
    public GameObject[] panels;
    public GameObject lastActivatedPanel;
    
    public void Awake()
    {
        Instance = this;
    }

    public void ActiveCurrentPanel(GameObject panelToActive)
    {
        
        PanelController _getPanelInfo = panelToActive.GetComponent<PanelController>();
        //print(_getPanelInfo.panelState);
        lastActivatedPanel = WhatPanelIsActive();
        //print("lastActivatedPanel in ActiveCurrentPanel" + lastActivatedPanel);
        DisableAllPanels();
        foreach (GameObject item in panels)
        {
            PanelController getSubPanels = item.GetComponent<PanelController>();
            Collection.PanelType thisType = getSubPanels.panelState;
            if (thisType == _getPanelInfo.panelState)
            {
                DisableAllPanels();
                item.SetActive(true);
                break;
            }
        }
    }

    public GameObject WhatPanelIsActive()
    {
        foreach (GameObject item in panels)
        {
            if (item.activeSelf)
                return item;
        }
        return null;
    }


    public Collection.PanelType WhatPanelIsActiveByPanelType()
    {
        foreach (GameObject item in panels)
        {
            if (item.activeSelf)
            {
                //Debug.Log(item);
                return item.GetComponent<PanelController>().panelState;

            }
        }
        return Collection.PanelType.none;
    }

    public void DisableAllPanels()
    {
        foreach (GameObject gb in panels)
        {
            gb.SetActive(false);
        }
    }
}
