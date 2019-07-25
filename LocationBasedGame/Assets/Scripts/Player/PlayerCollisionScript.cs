using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// 0t1
public class PlayerCollisionScript : MonoBehaviour
{
    private static Canvas reagentUI, plagueUI, mainUI;
    private Button enterButton;
    private ReagentUIController reagentUIController;

    void Start()
    {
        if (GameObject.Find("EnterButton") != null)
        {
            enterButton = GameObject.Find("EnterButton").GetComponent<Button>();
        }
        if (GameObject.Find("ReagentUI") != null)
        {
            reagentUI = GameObject.Find("ReagentUI").GetComponent<Canvas>();
            reagentUIController = GameObject.Find("ReagentUI").GetComponent<ReagentUIController>();
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
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && reagentUI.enabled == false && plagueUI.enabled == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<POICollisionScript>().active)
                {
                    if (hit.transform.gameObject.name == "Reagent(Clone)")
                    {
                        toggleReagentCanvas();
                    }
                    if (hit.transform.gameObject.name == "Plague(Clone)")
                    {
                        togglePlagueCanvas();
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {

        if (reagentUI.enabled)
        {
            toggleReagentCanvas();
        }
        if (plagueUI.enabled)
        {
            togglePlagueCanvas();
        }
    }

    public void toggleReagentCanvas()
    {
        if (reagentUI.enabled)
        {
            reagentUI.enabled = false;
            mainUI.enabled = true;
        }
        else
        {
            reagentUIController.spawnReagentButtons();
            reagentUI.enabled = true;
            mainUI.enabled = false;
        }
    }

    public void togglePlagueCanvas()
    {
        if (plagueUI.enabled)
        {
            plagueUI.enabled = false;
            mainUI.enabled = true;
            GameObject.Find("PlagueUI").GetComponent<AudioSource>().Stop();
        }
        else
        {
            plagueUI.enabled = true;
            mainUI.enabled = false;
            GameObject.Find("PlagueUI").GetComponent<AudioSource>().Play();
        }
    }
}
