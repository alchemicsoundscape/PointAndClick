using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceOfInterest : Area
{
    public Button interactWith;
    RectTransform rectTransform;
    public Vector2 Postition;
    public Vector2 Size;

    private void Start()
    {
        rectTransform = interactWith.gameObject.GetComponent<RectTransform>();
    }

    public void MapPOI()
    {
        rectTransform.anchoredPosition = Postition;
        rectTransform.sizeDelta = Size;
    }
}
