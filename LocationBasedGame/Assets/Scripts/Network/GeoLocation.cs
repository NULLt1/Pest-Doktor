using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeoLocation : MonoBehaviour
{
    private double x;
    private double y;

    public GeoLocation(double x, double y)
    {
        this.x = x;
        this.y = x;
    }
}
