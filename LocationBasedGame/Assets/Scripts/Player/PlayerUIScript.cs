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
    private GameObject playerUI, playerUIReagentPrefab;
    private Canvas playerUICanvas, mainUI;
    private Button playerUIExitButton;
    private ItemProvider itemProvider;
    private Image secondPage;
    private Text playerName;
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
        //drawItemIcons(); Generic

        playerUI = GameObject.Find("PlayerUI");
        mainUI = GameObject.Find("MainUI").GetComponent<Canvas>();
        playerName = GameObject.Find("ProfileName").GetComponent<Text>();
        secondPage = GameObject.Find("ProfileSecond").GetComponent<Image>();

        playerName.text = databaseManager.getPlayerName();

        if (playerUI != null)
        {
            playerUICanvas = GameObject.Find("PlayerUI").GetComponent<Canvas>();
        }
        playerUIReagentPrefab = Resources.Load<GameObject>("Assets/PlayerUIReagent");
        playerUICanvas.enabled = false;
    }

    void Update()
    {

    }

    /*
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
     */

    public void togglePageTwo()
    {
        secondPage.enabled = !secondPage.enabled;
    }

    public void togglePlayerUICanvas()
    {
        playerUICanvas.enabled = !playerUICanvas.enabled;
        if (playerUICanvas.enabled)
        {
            this.GetComponent<PlayerInventoryScript>().getAmountFromDatabase();
            this.GetComponent<PlayerInventoryScript>().setAmountText();
        }
    }
}
