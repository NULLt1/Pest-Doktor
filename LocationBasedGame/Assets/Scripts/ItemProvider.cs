﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemProvider : MonoBehaviour
{
    DatabaseManager databaseManager;
    public List<Item> items = new List<Item>();
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
        items = DatabaseManager.getAllItems();
    }
    public List<Item> getItems()
    {
        Debug.Log("CALLED");
        foreach (Item item in items)
        {
            Debug.Log(item.name);
        }
        return items;
    }

    public Item getReagentItem(int index)
    {
        return items[index];
    }
}
