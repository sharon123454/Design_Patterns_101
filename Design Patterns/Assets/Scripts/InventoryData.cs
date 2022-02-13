using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryData
{
    public static List<Item> Items = new List<Item>();
    
    //adds to horizontal group
    public static void AddItem(Item item)
    {
        Items.Add(item);
        InventoryUI.instance.Add(item);
    }

    public static void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
}