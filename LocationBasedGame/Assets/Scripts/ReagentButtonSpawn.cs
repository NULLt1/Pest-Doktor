using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentButtonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnReagentButtons()
    {
        GameObject reagent = GameObject.FindWithTag("Collision");
        int[] randomItmes = reagent.GetComponent<ReagentRandomizer>().getRandomItems();
        foreach (int i in randomItmes)
        {
            Debug.Log(i);

        }
    }
}
