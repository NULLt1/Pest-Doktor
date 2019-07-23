using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serialisierung wichtig, damit mehrere Objekte entstehen können - keine *MONOBEHAVIOUR* Klasse
[System.Serializable]
public class Item
{
    public int itemId;
    public string itemName;
    public string itemLatinName;
    public string itemDescription;
    public Texture2D itemIcon;
    public Sprite itemSprite;


    //Konstruktoren
    public Item(int itemId, string itemName, string itemLatinName, string itemDescription)
    {
        this.itemId = itemId;
        this.itemName = itemName;
        this.itemLatinName = itemLatinName;
        this.itemDescription = itemDescription;
        this.itemIcon = Resources.Load<Texture2D>("Grafics/reagent");
        this.itemSprite = Resources.Load<Sprite>("Grafics/reagent");
    }
    public Item()
    {

    }
}
