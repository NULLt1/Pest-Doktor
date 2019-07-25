using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;

public class PlagueUIController : MonoBehaviour
{
    private RPCController rpCController;

    private Canvas plagueUI;
    private Image healthBar, infektBar, mainInfektBar;
    public GameObject player1, player2, player3, player4;
    private DatabaseManager databaseManager;
    private Text playerName;
    private bool playerInsidePlagueFlag;
    public float health, infektion, healthFaktor, infektFaktor, infektHealFaktor;
    // Start is called before the first frame update
    void Start()
    {
        playerInsidePlagueFlag = true;

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

        // PROTOTYP IMPLEMENTIERUNG, BEI NETWORK ÄNDERN!
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

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
        StartCoroutine(PlagueSpawn(plague, 30f));
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
        yield return new WaitForSeconds(2f);
        playerInsidePlagueFlag = true;
    }
}
