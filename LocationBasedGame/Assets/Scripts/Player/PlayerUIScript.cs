using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DatabaseN;
using ItemN;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    Vector2[] reagentPosition = new Vector2[6];
    int positionCounter = 0;
    private DatabaseManager databaseManager;
    private GameObject playerUI;
    private Canvas playerUICanvas;
    private Button playerUIExitButton;
    private ItemProvider itemProvider;
    private GameObject playerUIReagentPrefab;

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
        playerUI = GameObject.Find("PlayerUI");
        if (playerUI != null)
        {
            playerUICanvas = GameObject.Find("PlayerUI").GetComponent<Canvas>();
            playerUIExitButton = GameObject.FindWithTag("Exit").GetComponent<Button>();
            playerUIExitButton.onClick.AddListener(() => togglePlayerUICanvas());
            Debug.Log(playerUIExitButton);
        }
        playerUIReagentPrefab = Resources.Load<GameObject>("Assets/PlayerUIReagent");
        playerUICanvas.enabled = false;
    }

    void Update()
    {

    }

    private void drawItemIcons()
    {
        foreach (Item item in items)
        {
            instantiatePlayerUIReagent(item);
        }
    }

    private void instantiatePlayerUIReagent(Item item)
    {
        GameObject playerUIReagent = Instantiate(playerUIReagentPrefab);
        playerUIReagent.transform.SetParent(GameObject.Find("PlayerUI").transform);
    }


    public void togglePlayerUICanvas()
    {
        Debug.Log("HELLLOOO");
        playerUICanvas.enabled = !playerUICanvas.enabled;
    }
}
