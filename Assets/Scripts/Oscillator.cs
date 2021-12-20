using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    const float tau = Mathf.PI * 2;
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        Debug.Log(rawSinWave);
        movementFactor = rawSinWave;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
