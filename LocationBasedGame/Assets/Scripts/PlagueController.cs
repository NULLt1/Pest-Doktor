using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlagueController : MonoBehaviour
{
    private Canvas seucheUI;
    private Image healthBar;
    public float health;
    public float healthFaktor;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SeucheUI") != null)
        {
            seucheUI = GameObject.Find("SeucheUI").GetComponent<Canvas>();
            healthBar = GameObject.Find("Bar").GetComponent<Image>();
        }

        health = 100;
        healthFaktor = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (seucheUI.enabled)
        {
            Debug.Log("UI: " + seucheUI.enabled);
            health -= healthFaktor;
            healthBar.GetComponent<Image>().fillAmount = health / 100f;

            if (health == 0)
            {
                Debug.Log("Health: " + health);
                resetAndHidePlague();
                GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleSeucheCanvas();
            }
        }

    }

    private void resetAndHidePlague()
    {
        GameObject plague = GameObject.FindWithTag("Collision");
        health = 100;
        healthBar.GetComponent<Image>().fillAmount = health;
        //plague.SetActive(false);
        coroutine = StartCo(plague, 10f);
        StartCoroutine(coroutine);
    }

    IEnumerator StartCo(GameObject plague, float waitSeconds)
    {
        Debug.Log("COROUTINE STARTED");
        plague.SetActive(false);
        yield return new WaitForSeconds (waitSeconds);
        Debug.Log("COROUTINE ENDED");
        plague.SetActive(true);
    }
}
