using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory Instance;

    void Awake()
    {
        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int Space = 10;  // Amount of item spaces

    // Our current list of Items in the inventory
    public List<Item> Items = new List<Item>();

    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.ShowInInventory)
        {
            if (Items.Count >= Space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            Items.Add(item);

            OnItemChangedCallback?.Invoke();
        }
    }

    // Remove an item
    public void Remove(Item item)
    {
        Items.Remove(item);

        OnItemChangedCallback?.Invoke();
    }

}
