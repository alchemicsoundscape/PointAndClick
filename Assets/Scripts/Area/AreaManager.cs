using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AreaManager : MonoBehaviour
{
    public Area activeArea;
    List<Area> allAreas;
    UIManager uiManager;

    void Start()
    {
        allAreas = new List<Area>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        activeArea.ChangeSprite(activeArea.Name);
        AddArea(activeArea);

        uiManager.LoadButtons();
    }

    public void Traverse(Area area)
    {
        if(!allAreas.Contains(area))
        {
            AddArea(area);
        }
        activeArea = area;

        uiManager.ChangeButtonsAndTransition();

        activeArea.ChangeSprite(activeArea.Name);
    }

    public void AddArea(Area area)
    {
        allAreas.Add(area);
    }
}
