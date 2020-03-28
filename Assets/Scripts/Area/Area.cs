using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Area : ResourceLoader
{
    public Area previousArea;
    public Area leftArea;
    public Area rightArea;
    public Area forwardArea;
    public List<PlaceOfInterest> placesOfInterest;
    public List<Area> nextAreas;

    void Start()
    {
        nextAreas = new List<Area>() { leftArea, rightArea, previousArea, forwardArea };
    }
}
