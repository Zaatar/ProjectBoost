using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustButton : MonoBehaviour
{
    Movement rocketMovement;

    void Start()
    {
        if (FindObjectOfType<Movement>())
        {
            rocketMovement = FindObjectOfType<Movement>();
        }
    }

    public void pointerDown()
    {
        if (FindObjectOfType<Movement>())
        {
            rocketMovement = FindObjectOfType<Movement>();
        }
        rocketMovement.isThrustClicked = true;
    }

    public void pointerUp()
    {
        if (FindObjectOfType<Movement>())
        {
            rocketMovement = FindObjectOfType<Movement>();
        }
        rocketMovement.isThrustClicked = false;
    }
}
