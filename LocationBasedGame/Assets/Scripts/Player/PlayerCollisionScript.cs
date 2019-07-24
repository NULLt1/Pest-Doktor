using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    private static Canvas reagentUI;
    private static Canvas seucheUI;
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

        if (GameObject.Find("SeucheUI") != null)
        {
            seucheUI = GameObject.Find("SeucheUI").GetComponent<Canvas>();
            //reagentButtonSpawn = GameObject.Find("SeucheUI").GetComponent<ReagentButtonSpawn>();
        }
        reagentUI.enabled = false;
        seucheUI.enabled = false;
    }

    void Update()
    {
    }

    void OnCollisionStay(Collision collision)
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && reagentUI.enabled == false && seucheUI.enabled == false)
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
                    if (hit.transform.gameObject.name == "Pestbrunnen(Clone)")
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
        if (seucheUI.enabled)
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
        }
        else
        {
            reagentController.spawnReagentButtons();
            reagentUI.enabled = true;
        }
    }

    public void toggleSeucheCanvas()
    {
        //Debug.Log("Toggle Canvas called on: " + seucheUI + ", Status: " + seucheUI.enabled);
        if (seucheUI.enabled)
        {
            seucheUI.enabled = false;
        }
        else
        {
            seucheUI.enabled = true;
        }
    }

}
