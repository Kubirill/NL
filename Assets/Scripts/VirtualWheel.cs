using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualWheel : MonoBehaviour
{

    public Transform originalWheel;
    public Vector3 startPosition;
    public float startAngle;
    public float startAngleWheel;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (active)
        {
            Vector2 offset = new Vector2(transform.localPosition.y, transform.localPosition.z);
            Debug.Log("New offset " + offset);
            offset.Normalize();
            Debug.Log("New offset norm" + offset);
            float newAngle =  Mathf.Atan2(offset.x, offset.y)* Mathf.Rad2Deg;
            Debug.Log("New angle" + newAngle);
            originalWheel.localEulerAngles =  new Vector3(startAngleWheel-startAngle + newAngle, originalWheel.localEulerAngles.y, originalWheel.localEulerAngles.z);
            if (offset.sqrMagnitude <0.3)
            {

                active = false;
                transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            Vector2 offset = new Vector2(transform.localPosition.y, transform.localPosition.z);
            if (offset.sqrMagnitude > 0.3)
            {
                active = true;
                startAngleWheel = originalWheel.localEulerAngles.x;
                Debug.Log("Start " + startAngleWheel + " " + originalWheel.localEulerAngles.x);
                Vector2 Startoffset = new Vector2(transform.localPosition.y, transform.localPosition.z);
                Debug.Log("Start offset " + Startoffset);

                Startoffset.Normalize();
                Debug.Log("Start offset norm" + Startoffset);
                startAngle = Mathf.Atan2(Startoffset.x, Startoffset.y) * Mathf.Rad2Deg;
                Debug.Log("Start angle" + startAngle);
            }
            
        }
    }

    public void OnStartGrub()
    {
       
    }
    public void OnEndGrub()
    {
       
    }
}
