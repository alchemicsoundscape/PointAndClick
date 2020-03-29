using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class ButtonHandler : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button backButton;
    public Button forwardButton;
    public Button POIButton1;
    public Button POIButton2;
    public Button POIButton3;
    List<Button> allButtons;
    AreaManager manager;
    Dictionary<Button, bool> buttonModificationTracker;

    void Start()
    {
        manager = GameObject.Find("AreaManager").GetComponent<AreaManager>();
        allButtons = new List<Button>() { leftButton, rightButton, backButton, forwardButton, POIButton1, POIButton2, POIButton3 };
        buttonModificationTracker = new Dictionary<Button, bool>();

        foreach(var button in allButtons)
        {
            buttonModificationTracker.Add(button, false);
        }
    }

    public void HandleButtons()
    {
        AssignListeners();
        ActivatePOIs();
        TriggerButtonVisibility();
    }

    private void ActivatePOIs()
    {
        for(int i=0;i<manager.activeArea.placesOfInterest.Count; i++)
        {
            manager.activeArea.placesOfInterest[i].MapPOI();
            ChangeButtonListeners(manager.activeArea.placesOfInterest[i], manager.activeArea.placesOfInterest[i].interactWith);
        }
    }

    void AssignListeners()
    {
        foreach(var button in allButtons)
        {
            button.onClick.RemoveAllListeners();
            buttonModificationTracker[button] = false;
        }

        ChangeButtonListeners(manager.activeArea.leftArea, leftButton);
        ChangeButtonListeners(manager.activeArea.rightArea, rightButton);
        ChangeButtonListeners(manager.activeArea.previousArea, backButton);
        ChangeButtonListeners(manager.activeArea.forwardArea, forwardButton);
    }

    void ChangeButtonListeners(Area areaToPointTo, Button button)
    {
        if(areaToPointTo != null)
        {
            button.onClick.AddListener(() => manager.Traverse(areaToPointTo));
            buttonModificationTracker[button] = true;
        }
    }

    void TriggerButtonVisibility()
    {
        foreach(var button in buttonModificationTracker)
        {
            if(!button.Value)
                buttonModificationTracker.First(btn => btn.Key == button.Key).Key.gameObject.SetActive(false);
            else
                buttonModificationTracker.First(btn => btn.Key == button.Key).Key.gameObject.SetActive(true);
        }
    }

    public void ToggleButtonVisibility(bool toggleValue)
    {
        if(toggleValue)
        //toggle them on
        {
            foreach (var button in allButtons)
            {
                button.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var button in allButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
