using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 0t1
[System.Serializable]
public class PlagueAttribute
{
    private int id;
    private int health;
    public PlagueAttribute(int id, int health)
    {
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

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void decrementBy(int amount)
    {
        health = health - amount;
    }
}
