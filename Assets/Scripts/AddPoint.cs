using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enable to add point

public class AddPoint : MonoBehaviour
{

    private bool addPoint = true; // can add point to the player


    public bool getAddPoint() // getter enable add point
    {
        return this.addPoint;
    }

    public void setAddPoint(bool addPoint) // setter enable add point
    {
        this.addPoint = addPoint;
    }
}
