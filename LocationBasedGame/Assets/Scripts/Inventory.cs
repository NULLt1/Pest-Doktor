using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial dazu: https://www.youtube.com/watch?v=4KNoOEkKSnk&list=PLivfKP2ufIK7Elii_nQvrZm3-YoZjlYHo&index=8



public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    private ItemProvider itemProvider;
    private bool showInventory;
    public List<Item> slots = new List<Item>();
    private bool showTooltip;
    private string tooltip;

    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;

    private void Start()
    {
        //Inventar Tabelle
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

        itemProvider = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemProvider>();
        Debug.Log(itemProvider);
        AddItem(0);
        AddItem(1);
        AddItem(2);

    }

    void OnGUI()
    {
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
            if (showTooltip)
                GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 60, 60), tooltip, skin.GetStyle("Tooltip"));
        }
        if (draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), draggedItem.itemIcon);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemId == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 90, y * 90, 90, 90);
                GUI.Box(new Rect(x * 90, y * 90, 90, 90), "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;

                        if (e.button == 0 && e.type == EventType.MouseDrag && !draggingItem) //e.button == 0 -> Linke Maustaste
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                }
                else
                {
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                    /*if (e.isMouse && e.type == EventType.MouseDown && e.button == 1)
                    {
                        print("You clicked Item Nr. " + i);
                    }*/
                }

                if (tooltip == "")
                {
                    showTooltip = false;
                }
                i++;
            }
        }
    }

    string CreateTooltip(Item item)
    {
        tooltip = "<color=#000000>" + item.itemName + "</color>\n\n" + "<color=#f12345>" + item.itemDescription + "</color>";
        return tooltip;
    }

    public void AddItem(int id)
    {
        Debug.Log(itemProvider.items[id].itemName);
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                inventory[i] = itemProvider.items[id];

                for (int j = 0; j < itemProvider.items.Count; j++)
                {
                    if (itemProvider.items[j].itemId == id)
                    {
                        inventory[i] = itemProvider.items[j];
                    }
                }
                break;
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemId == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }
}

