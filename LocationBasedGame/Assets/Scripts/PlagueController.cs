using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlagueController : MonoBehaviour
{
    private Canvas seucheUI;
    private Image healthBar, infektBar, mainInfektBar;
    public float health, infektion, healthFaktor, infektFaktor, infektHealFaktor;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SeucheUI") != null)
        {
            seucheUI = GameObject.Find("SeucheUI").GetComponent<Canvas>();
            healthBar = GameObject.Find("Bar").GetComponent<Image>();
            infektBar = GameObject.Find("InfektionBar").GetComponent<Image>();
            mainInfektBar = GameObject.Find("MainInfektBar").GetComponent<Image>();
        }

        health = 100;
        healthFaktor = 0.05f;
        infektion = 0;
        infektFaktor = 0.5f;
        infektHealFaktor = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (seucheUI.enabled)
        {
            health -= healthFaktor;
            infektion += infektFaktor;
            healthBar.GetComponent<Image>().fillAmount = health / 100f;
            infektBar.GetComponent<Image>().fillAmount = infektion / 100f;
            mainInfektBar.GetComponent<Image>().fillAmount = infektion / 100f;

            if (health == 0)
            {
                resetAndHidePlague();
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleSeucheCanvas();
            }
            if(infektion == 100) {
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleSeucheCanvas();
            }
        } else {
            infektion -= infektHealFaktor;
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
        yield return new WaitForSeconds (waitSeconds);
        plague.SetActive(true);
    }
}
