using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    private static Canvas reagentUI, plagueUI, mainUI;
    private Button enterButton;
    private ReagentController reagentController;

    void Start()
    {
        if (GameObject.Find("EnterButton") != null)
        {
            enterButton = GameObject.Find("EnterButton").GetComponent<Button>();
        }
        if (GameObject.Find("ReagentUI") != null)
        {
            reagentUI = GameObject.Find("ReagentUI").GetComponent<Canvas>();
            reagentController = GameObject.Find("ReagentUI").GetComponent<ReagentController>();
        }

        if (GameObject.Find("PlagueUI") != null)
        {
            plagueUI = GameObject.Find("PlagueUI").GetComponent<Canvas>();
        }

        if (GameObject.Find("MainUI") != null)
        {
            mainUI = GameObject.Find("MainUI").GetComponent<Canvas>();
        }

        reagentUI.enabled = false;
        plagueUI.enabled = false;
    }

    void Update()
    {
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("STAY STAY");
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && reagentUI.enabled == false && plagueUI.enabled == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.GetComponent<POICollisionScript>().active)
                {
                    if(hit.transform.gameObject.name == "Reagent(Clone)")
                    {
                        //Debug.Log("FIRE REAGENT");
                        toggleCanvas();
                    }
                    if (hit.transform.gameObject.name == "Plague(Clone)")
                    {

                        //Debug.Log("FIRE SEUCHE");
                        toggleSeucheCanvas();
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        
        if (reagentUI.enabled)
        {
            toggleCanvas();
        }
        if (plagueUI.enabled)
        {
            //Debug.Log("EXIT");
            toggleSeucheCanvas();
        }
    }

    public void toggleCanvas()
    {
        if (reagentUI.enabled)
        {
            reagentUI.enabled = false;
            mainUI.enabled = true;
        }
        else
        {
            reagentController.spawnReagentButtons();
            reagentUI.enabled = true;
            mainUI.enabled = false;
        }
    }

    public void toggleSeucheCanvas()
    {
        //Debug.Log("Toggle Canvas called on: " + seucheUI + ", Status: " + seucheUI.enabled);
        if (plagueUI.enabled)
        {
            plagueUI.enabled = false;
            mainUI.enabled = true;
        }
        else
        {
            plagueUI.enabled = true;
            mainUI.enabled = false;
        }
    }

}
