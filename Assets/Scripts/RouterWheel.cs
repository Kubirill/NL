using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouterWheel : MonoBehaviour
{
    public float axisSpeed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ClosedAngle(transform.localEulerAngles.x, angle) + " "+transform.localEulerAngles + " " + " angle " + angle + " ");
        if (transform.localEulerAngles.z > 90)
        {
            axisSpeed = ClosedAngle(transform.localEulerAngles.y, angle);
            angle = transform.localEulerAngles.y;
        }
        else
        {
            axisSpeed = ClosedAngle(360 - transform.localEulerAngles.y, angle);
            angle =360- transform.localEulerAngles.y;
        }

        
    }
    
    float ClosedAngle (float orAngle,float compAngle)
    {
        float dif =Mathf.Min(Mathf.Abs(orAngle - compAngle), Mathf.Abs(orAngle - compAngle + 360), Mathf.Abs(orAngle - compAngle - 360));
        if (dif == Mathf.Abs(orAngle - compAngle)) return orAngle - compAngle;
        if (dif == Mathf.Abs(orAngle - compAngle + 360)) return orAngle - compAngle+360;
        if (dif == Mathf.Abs(orAngle - compAngle - 360)) return orAngle - compAngle-360;
        return orAngle - compAngle;
    }
}
