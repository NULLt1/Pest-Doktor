using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    private static Canvas oreUI;
    private Button enterButton;
    private ReagentButtonSpawn reagentButtonSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("EnterButton") != null)
        {
            enterButton = GameObject.Find("EnterButton").GetComponent<Button>();
        }
        if (GameObject.Find("OreUI") != null)
        {
            oreUI = GameObject.Find("OreUI").GetComponent<Canvas>();
            reagentButtonSpawn = GameObject.Find("OreUI").GetComponent<ReagentButtonSpawn>();
        }
        oreUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionStay(Collision collision)
    {
        //enterButton.gameObject.SetActive(true);
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && oreUI.enabled == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<POICollisionScript>().active)
                {
                    toggleCanvas();
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        //enterButton.gameObject.SetActive(false);
        if (oreUI.enabled)
        {
            toggleCanvas();
        }
    }

    public void toggleCanvas()
    {
        if (oreUI.enabled)
        {
            oreUI.enabled = false;
        }
        else
        {
            reagentButtonSpawn.spawnReagentButtons();
            oreUI.enabled = true;
        }
    }

}
