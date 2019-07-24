using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POICollisionScript : MonoBehaviour
{
    public GameObject collisionRing;
    public bool active { get; set; }

    void Start()
    {
        collisionRing = Instantiate(collisionRing);
        collisionRing.transform.parent = this.transform;
        collisionRing.transform.position = new Vector3(0, 2, 0);
        collisionRing.SetActive(false);
    }

    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.tag = "Collision";
            active = true;
            //Debug.Log("Active: " +active);
            collisionRing.SetActive(true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        this.gameObject.tag = "Untagged";
        active = false;
        collisionRing.SetActive(false);
    }
}
