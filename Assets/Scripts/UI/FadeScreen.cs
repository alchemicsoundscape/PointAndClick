using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    Image fadeScreen;
    void Start()
    {
        fadeScreen = GetComponent<Image>();
    }

    public IEnumerator FadeImage(bool fadeOut)
    {
        if (fadeOut)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * 3f)
            {
                fadeScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            
            for (float i = 1; i >= 0; i -= Time.deltaTime * 3f)
            {
                fadeScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    public void SetAlpha(float alphaValue)
    {
        fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alphaValue);
    }
}
