using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemProvider : MonoBehaviour
{
    DatabaseManager databaseManager;
    public List<Item> items = new List<Item>();
    //Hier werden die Gegenstände definiert. Hart.
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
        items = DatabaseManager.getAllItems();
    }

}
