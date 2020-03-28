using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AreaManager : MonoBehaviour
{
    public Area activeArea;
    List<Area> allAreas;
    ButtonHandler buttonHandler;
    FadeScreen screenFader;

    void Start()
    {
        allAreas = new List<Area>();
        buttonHandler = GameObject.Find("ButtonHandler").GetComponent<ButtonHandler>();
        screenFader = GameObject.Find("FadeScreen").GetComponent<FadeScreen>();

        activeArea.ChangeSprite(activeArea.Name);
        AddArea(activeArea);

        buttonHandler.HandleButtons(this);
    }

    public void Traverse(Area area)
    {
        if(!allAreas.Contains(area))
        {
            AddArea(area);
        }
        activeArea = area;

        StartCoroutine(screenFader.FadeImage(true));
        buttonHandler.HandleButtons(this);
        
        StartCoroutine(screenFader.FadeImage(false));

        activeArea.ChangeSprite(activeArea.Name);
    }

    public void AddArea(Area area)
    {
        allAreas.Add(area);
    }
}
