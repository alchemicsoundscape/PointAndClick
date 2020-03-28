using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite inventorySprite;
    public Sprite worldSprite;
    Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void ModifySprite(bool setActive, int slotToActivate)
    {
        var itemSlotToActivate = inventory.gameObject.GetComponentsInChildren<Transform>().Where(tr => tr.gameObject.name.Contains("ItemSlot") && tr.gameObject.name.EndsWith(slotToActivate.ToString())).FirstOrDefault();

        var imageToModify = itemSlotToActivate.gameObject.GetComponentsInChildren<Transform>().First(tr => tr.gameObject.name == "ItemSprite").gameObject.GetComponent<Image>();

        if (setActive)
        {
            imageToModify.sprite = inventorySprite;
        }
        else
        {
            imageToModify.sprite = null;
        }
    }
}
