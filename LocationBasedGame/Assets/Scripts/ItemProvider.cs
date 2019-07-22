using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    //Hier werden die Gegenstände definiert. Hart.
    void Start()
    {
        items.Add(new Item(0, "Alraune", "Mandragora", "Heilpflanze"));
        items.Add(new Item(1, "Tollkirsche", "Atropus belladonna", "Heilpflanze"));
        items.Add(new Item(2, "Wachholder", "Juniperus sabina", "Heilpflanze"));
        items.Add(new Item(3, "Fliegenpilz", "Juniperus sabina", "Pilz"));
        items.Add(new Item(4, "Morchel", "Juniperus sabina", "Pilz"));
        items.Add(new Item(5, "Kiefernschwamm", "Juniperus sabina", "Pilz"));

    }

}
