using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;

public class MainUIName : MonoBehaviour
{
    private DatabaseManager databaseManager;
    public Text playerName;
    void Start()
    {
         databaseManager = FindObjectOfType<DatabaseManager>();
         playerName.text = databaseManager.getPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
