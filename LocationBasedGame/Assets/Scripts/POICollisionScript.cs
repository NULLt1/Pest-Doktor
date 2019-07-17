using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POICollisionScript : MonoBehaviour
{
    public GameObject collisionRing;

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
            collisionRing.SetActive(true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        collisionRing.SetActive(false);
    }
}
