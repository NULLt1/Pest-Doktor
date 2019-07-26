using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NULLt1
public class POICollisionScript : MonoBehaviour
{
    private RPCController rpCController;
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
        collisionRing.transform.position = this.transform.position + new Vector3(0, 2, 0);
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
