using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;

public class PlagueController : MonoBehaviour
{
    private PlagueAttribute plagueAttribute;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(plagueAttribute.getHealth());
        //Debug.Log(plagueAttribute.getId());

    }

    public void setPlagueAttribute(PlagueAttribute plagueAttribute)
    {
        this.plagueAttribute = plagueAttribute;
    }
}
