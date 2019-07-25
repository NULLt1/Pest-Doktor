using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;

public class PlagueUIController : MonoBehaviour
{
    private Canvas plagueUI;
    private Image healthBar, infektBar, mainInfektBar;
    public GameObject player1, player2, player3, player4;
    private DatabaseManager databaseManager;
    private Text playerName;
    public float health, infektion, healthFaktor, infektFaktor, infektHealFaktor;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager = GameObject.Find("DatabaseManager").GetComponent<DatabaseManager>();
        if (GameObject.Find("PlagueUI") != null)
        {
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

        health = 100;
        infektion = 0;

        healthFaktor = 0.05f;
        infektFaktor = 0.5f;
        infektHealFaktor = 0.1f;

        healthBar.GetComponent<Image>().fillAmount = 100;
        infektBar.GetComponent<Image>().fillAmount = 0;
        mainInfektBar.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (plagueUI.enabled)
        {
            Debug.Log("ENABLED");
            health -= healthFaktor;
            infektion += infektFaktor;
            healthBar.GetComponent<Image>().fillAmount = health / 100f;
            infektBar.GetComponent<Image>().fillAmount = infektion / 100f;
            mainInfektBar.GetComponent<Image>().fillAmount = infektion / 100f;

            if (health <= 0)
            {
                resetAndHidePlague();
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleSeucheCanvas();
            }
            if (infektion >= 100)
            {
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleSeucheCanvas();
            }
        }
        else
        {
            Debug.Log("DISABLED");
            if (infektion > 0)
            {
                Debug.Log(infektion);
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
        StartCoroutine(StartCo(plague, 30f));
    }

    IEnumerator StartCo(GameObject plague, float waitSeconds)
    {
        plague.SetActive(false);
        yield return new WaitForSeconds(waitSeconds);
        plague.SetActive(true);
    }
}
