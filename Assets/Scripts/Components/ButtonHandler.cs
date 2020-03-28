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
    Dictionary<Button, bool> buttonModificationTracker;

    void Start()
    {
        allButtons = new List<Button>() { leftButton, rightButton, backButton, forwardButton, POIButton1, POIButton2, POIButton3 };
        buttonModificationTracker = new Dictionary<Button, bool>();

        foreach(var button in allButtons)
        {
            buttonModificationTracker.Add(button, false);
        }
    }

    public void HandleButtons(AreaManager manager)
    {
        AssignListeners(manager);
        ActivatePOIs(manager);
        TriggerButtonVisibility();
    }

    private void ActivatePOIs(AreaManager manager)
    {
        for(int i=0;i<manager.activeArea.placesOfInterest.Count; i++)
        {
            manager.activeArea.placesOfInterest[i].MapPOI();
            ChangeButtonListeners(manager, manager.activeArea.placesOfInterest[i], manager.activeArea.placesOfInterest[i].interactWith);
        }
    }

    void AssignListeners(AreaManager manager)
    {
        foreach(var button in allButtons)
        {
            button.onClick.RemoveAllListeners();
            buttonModificationTracker[button] = false;
        }

        ChangeButtonListeners(manager, manager.activeArea.leftArea, leftButton);
        ChangeButtonListeners(manager, manager.activeArea.rightArea, rightButton);
        ChangeButtonListeners(manager, manager.activeArea.previousArea, backButton);
        ChangeButtonListeners(manager, manager.activeArea.forwardArea, forwardButton);
    }

    void ChangeButtonListeners(AreaManager manager, Area areaToPointTo, Button button)
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
}
