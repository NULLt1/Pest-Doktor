using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlagueAttribute
{
    private int id;
    private int health;
    public PlagueAttribute(int id, int health)
    {
        Debug.Log("Konstruktor");
        this.id = id;
        this.health = health;
    }
    public int getId()
    {
        return id;
    }

    public int getHealth()
    {
        return health;
    }
}
