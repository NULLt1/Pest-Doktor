using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POICollisionScript : MonoBehaviour
{
    public GameObject collisionRing;
    public bool active { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        collisionRing = Instantiate(collisionRing);
        collisionRing.transform.parent = this.transform;
        collisionRing.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.tag = "Collision";
            active = true;
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
