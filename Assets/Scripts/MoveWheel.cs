using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWheel : MonoBehaviour
{
    public Transform virtualWheel;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        position = jostick.transform.position;
        if (active)
        {
            transform.eulerAngles = startRotation + (startPosition - position)*3;

        }
    }
    public void StartGrab()
    {
        startPosition = position;
        startRotation = transform.eulerAngles;
        active = true;
    }
    public void EndGrab()
    {
        active = false;
    }
    */
}
