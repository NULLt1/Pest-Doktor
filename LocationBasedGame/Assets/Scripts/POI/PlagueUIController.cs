using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;
public class PlagueUIController : MonoBehaviour
{
    Vector2[] playerFramePosition = new Vector2[3];
    int positionCounter = 0;
    private RPCController rpCController;
    private Canvas plagueUI;
    private Image healthBar, infektBar, mainInfektBar;
    public GameObject player1, player2, player3, player4;
    private DatabaseManager databaseManager;
    private Text playerName;
    private bool playerInsidePlagueFlag;
    private List<string> playerList;
    bool setPlayersFlag;
    public float health, infektion, healthFaktor, infektFaktor, infektHealFaktor;
    // Start is called before the first frame update
    void Start()
    {
        playerFramePosition[0] = new Vector2(-125, -150);
        playerFramePosition[1] = new Vector2(125, -150);
        playerFramePosition[2] = new Vector2(375, -150);
        playerInsidePlagueFlag = true;
        setPlayersFlag = true;
        databaseManager = GameObject.Find("DatabaseManager").GetComponent<DatabaseManager>();
        if (GameObject.Find("PlagueUI") != null)
        {
            rpCController = GameObject.Find("PlagueSpawner").GetComponent<RPCController>();
            plagueUI = GameObject.Find("PlagueUI").GetComponent<Canvas>();
            healthBar = GameObject.Find("Bar").GetComponent<Image>();
            infektBar = GameObject.Find("InfektionBar").GetComponent<Image>();
            mainInfektBar = GameObject.Find("MainInfektionBar").GetComponent<Image>();
            playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        }

        playerName.text = databaseManager.getPlayerName();

        infektion = 0;

        healthFaktor = 0.05f;
        infektFaktor = 0.05f;
        infektHealFaktor = 0.1f;

        healthBar.GetComponent<Image>().fillAmount = health;
        infektBar.GetComponent<Image>().fillAmount = 0;
        mainInfektBar.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (plagueUI.enabled)
        {

            health = GameObject.FindWithTag("Collision").GetComponent<PlagueController>().getHealth();

            GameObject[] existingPlayerFrames = GameObject.FindGameObjectsWithTag("PlayerFrameUI");

            foreach (GameObject existingPlayerFrame in existingPlayerFrames)
            {
                Destroy(existingPlayerFrame);
            }
            playerList = GameObject.FindWithTag("Collision").GetComponent<PlagueController>().getPlayerList();
            foreach (string name in playerList)
            {
                Debug.Log(name);
                if (name != databaseManager.getPlayerName())
                {
                    GameObject playerFrame = Instantiate(Resources.Load("PlayerFramePrefab") as GameObject);
                    playerFrame.transform.GetChild(1).GetComponent<Text>().text = name;
                    playerFrame.transform.SetParent(GameObject.Find("PlagueUI").transform);
                    playerFrame.transform.localPosition = playerFramePosition[positionCounter++];
                    playerFrame.transform.localScale = new Vector3(1, 1, 1);
                }
                positionCounter = 0;
            }


            if (playerInsidePlagueFlag == true)
            {
                playerInsidePlagueFlag = false;
                StartCoroutine(sendInsidePlagueMessage());
            }

            health -= healthFaktor;
            infektion += infektFaktor;
            healthBar.GetComponent<Image>().fillAmount = health / 100f;
            infektBar.GetComponent<Image>().fillAmount = infektion / 100f;
            mainInfektBar.GetComponent<Image>().fillAmount = infektion / 100f;

            if (health <= 0)
            {
                resetAndHidePlague();
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().togglePlagueCanvas();
            }
            if (infektion >= 100)
            {
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().togglePlagueCanvas();
            }
        }
        else
        {
            if (infektion > 0)
            {
                infektion -= infektHealFaktor;
            }
            infektBar.GetComponent<Image>().fillAmount = infektion / 100f;
            mainInfektBar.GetComponent<Image>().fillAmount = infektion / 100f;

        }

    }

    private void resetAndHidePlague()
    {
        GameObject plague = GameObject.FindWithTag("Collision");
        health = 100;
        healthBar.GetComponent<Image>().fillAmount = health;
        //StartCoroutine(PlagueSpawn(plague, 30f));
    }

    IEnumerator PlagueSpawn(GameObject plague, float waitSeconds)
    {
        plague.SetActive(false);
        yield return new WaitForSeconds(waitSeconds);
        plague.SetActive(true);
    }

    IEnumerator sendInsidePlagueMessage()
    {
        rpCController.PlayerInsidePlague(GameObject.FindWithTag("Collision").GetComponent<PlagueController>().getPlagueId());
        rpCController.PlayerInsidePlagueName(GameObject.FindWithTag("Collision").GetComponent<PlagueController>().getPlagueId(), databaseManager.getPlayerName());
        yield return new WaitForSeconds(2f);
        var plagueControllers = FindObjectsOfType<PlagueController>();
        foreach (PlagueController plagueController in plagueControllers)
        {
            plagueController.resetPlayerNames();
        }
        playerInsidePlagueFlag = true;
    }
}
