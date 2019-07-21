using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    public Canvas oreUI;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
        oreUI.enabled = false;
        Debug.Log("STARTED PCS");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionStay(Collision collision)
    {
        button.gameObject.SetActive(true);
    }

    void OnCollisionExit(Collision other)
    {
        button.gameObject.SetActive(false);
        if (oreUI.enabled)
        {
            toggleCanvas();
        }
    }

    public void toggleCanvas()
    {
        Debug.Log(oreUI.enabled);
        if (oreUI.enabled)
        {
            oreUI.enabled = false;
        }
        else
        {
            oreUI.enabled = true;
        }
    }
}
