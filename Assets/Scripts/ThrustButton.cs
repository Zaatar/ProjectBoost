using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustButton : MonoBehaviour
{
    Movement rocketMovement;
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
