using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    Vector2[] reagentPosition = new Vector2[6];
    int positionCounter = 0;
    private DatabaseManager databaseManager;
    private ItemProvider itemProvider;
    public GameObject playerUIReagentPrefab;

    public List<Item> items = new List<Item>();

    void Start()
    {
        reagentPosition[0] = new Vector2(-190, -435);
        reagentPosition[1] = new Vector2(0, -435);
        reagentPosition[2] = new Vector2(190, -435);
        reagentPosition[3] = new Vector2(-190, -585);
        reagentPosition[4] = new Vector2(0, -585);
        reagentPosition[5] = new Vector2(190, -585);
        databaseManager = FindObjectOfType<DatabaseManager>();
        itemProvider = FindObjectOfType<ItemProvider>();

        items = itemProvider.getItems();
        drawItemIcons();
    }

    void Update()
    {

    }

    private void drawItemIcons()
    {
        Debug.Log(items);
        foreach (Item item in items)
        {
            instantiatePlayerUIReagent(item);
        }
    }

    private void instantiatePlayerUIReagent(Item item)
    {
        Debug.Log("INSTANTIATE");
        GameObject playerUIReagent = Instantiate(playerUIReagentPrefab);
        playerUIReagent.transform.SetParent(GameObject.Find("PlayerUI").transform);
    }

}
