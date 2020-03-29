using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    FadeScreen fadeScreen;
    Inventory inventory;
    ButtonHandler buttonHandler;

    void Start()
    {
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<FadeScreen>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        buttonHandler = GameObject.Find("ButtonHandler").GetComponent<ButtonHandler>();
    }

    public void LoadButtons()
    {
        buttonHandler.HandleButtons();
    }

    public void ChangeButtonsAndTransition()
    {
        StartCoroutine(fadeScreen.FadeImage(true));
        buttonHandler.HandleButtons();
        StartCoroutine(fadeScreen.FadeImage(false));
    }

    public void ToggleInventory(bool isActive)
    {
        inventory.gameObject.SetActive(isActive);
        buttonHandler.ToggleButtonVisibility(isActive);
    }
}
