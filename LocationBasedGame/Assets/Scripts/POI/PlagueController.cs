using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;
// 0t1
public class PlagueController : MonoBehaviour
{
    private RPCController rpCController;
    private PlagueAttribute plagueAttribute;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlagueAttribute(PlagueAttribute plagueAttribute)
    {
        this.plagueAttribute = plagueAttribute;
    }

    public int getPlagueId()
    {
        return plagueAttribute.getId();
    }

    public int getHealth()
    {
        return plagueAttribute.getHealth();
    }

    public void decrementHealth()
    {
        int amount = 1;
        plagueAttribute.decrementBy(amount);

    }

    public void setHealth(int health)
    {
        plagueAttribute.setHealth(health);
    }
}
