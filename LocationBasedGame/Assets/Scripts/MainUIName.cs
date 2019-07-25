using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;

public class MainUIName : MonoBehaviour
{
    private DatabaseManager databaseManager;
    public Text playerName;
    private Canvas tutorialUI;
    private GameObject profilTut;
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
        playerName.text = databaseManager.getPlayerName();
        tutorialUI = GameObject.Find("TutorialUI").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggleProfilTutorialUI()
    {
        tutorialUI.enabled = false;
    }
}
