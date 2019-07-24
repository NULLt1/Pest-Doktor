using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string latinName;
    public string description;
    public Texture2D icon;
    public Sprite sprite;

    public Item(int itemId, string itemName, string itemLatinName, string itemDescription)
    {
        this.id = itemId;
        this.name = itemName;
        this.latinName = itemLatinName;
        this.description = itemDescription;
        this.icon = Resources.Load<Texture2D>("Grafics/" + name);
        this.sprite = Resources.Load<Sprite>("Grafics/" + name);
    }

    public Item()
    {

    }
}
