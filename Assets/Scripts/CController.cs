using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float speedSteer=1;

    
    // находит визуальную часть колес
    // устанавливает новые координаты
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque ;
        float steering = maxSteeringAngle ;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                float trash = steering;
                trash = Mathf.Clamp( trash * (Mathf.Abs(axleInfo.routerLeft.axisSpeed )- Mathf.Abs(axleInfo.routerRight.axisSpeed))*speedSteer, -maxSteeringAngle, maxSteeringAngle);
                axleInfo.leftWheel.steerAngle =Mathf.Lerp(axleInfo.leftWheel.steerAngle,trash,0.1f);
                axleInfo.rightWheel.steerAngle = Mathf.Lerp(axleInfo.rightWheel.steerAngle, trash, 0.1f); ;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor * /*Input.GetAxis("Vertical")*/  axleInfo.routerLeft.axisSpeed;
                axleInfo.rightWheel.motorTorque = motor * /*Input.GetAxis("Vertical")*/ axleInfo.routerRight.axisSpeed;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public RouterWheel routerLeft;
    public RouterWheel routerRight;
    public bool motor; // присоединено ли колесо к мотору?
    public bool steering; // поворачивает ли это колесо?
}