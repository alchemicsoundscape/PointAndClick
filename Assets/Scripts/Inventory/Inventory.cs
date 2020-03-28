using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[numItemSlots];
    public const int numItemSlots = 20;

    public void AddItem(Item itemToAdd)
    {
        for(int i = 0; i<numItemSlots;i++)
        {
            if(items[i] == null)
            {
                items[i] = itemToAdd;
                itemToAdd.ModifySprite(true, i);
                break;
            }
        }

        Destroy(itemToAdd.gameObject);
    }

    public void RemoveItem(int i)
    {
        
    }
}
