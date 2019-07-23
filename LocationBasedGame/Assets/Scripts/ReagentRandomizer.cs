using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentRandomizer : MonoBehaviour
{
    private int[] randomItems;

    void Start()
    {
        randomItems = new int[Random.Range(1, 4)];
        for (int i = 0; i < randomItems.Length; i++)
        {
            randomItems[i] = Random.Range(0, 6);
            Debug.Log(randomItems[i]);
        }
        //Debug.Log(randomItems.Length);
    }

    void Update()
    {

    }

    public int[] getRandomItems()
    {
        return randomItems;
    }
}
