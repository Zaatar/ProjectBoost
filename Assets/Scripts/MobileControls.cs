using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    Movement rocketMovement;
    LevelManager levelManager = null;

    public void Start()
    {
        if(FindObjectOfType<LevelManager>())
        {
            levelManager = FindObjectOfType<LevelManager>();
        }
        else
        {
            Debug.Log("Level Manager not found, error!");
        }
    }

    public void LocateMovement()
    {
        if (FindObjectOfType<Movement>())
        {
            rocketMovement = FindObjectOfType<Movement>();
        }
        else
        {
            Debug.Log("Rocket Movement component not present in scene!");
        }
    }

    public void RotateLeftPressed()
    {
        rocketMovement.setRotateLeftPressed(true);
    }

    public void RotateLeftUnpressed()
    {
        rocketMovement.setRotateLeftPressed(false);
    }

    public void RotateRightPressed()
    {
        rocketMovement.setRotateRightPressed(true);
    }

    public void RotateRightUnpressed()
    {
        rocketMovement.setRotateRightPressed(false);
    }

    public void ThrustButtonPressed()
    {
        rocketMovement.setThrustPressed(true);
    }

    public void ThrustButtonUnpressed()
    {
        rocketMovement.setThrustPressed(false);
    }

    public void OptionsButtonPressed()
    {
        levelManager.displayMobileOptionsMenu();
    }
}
