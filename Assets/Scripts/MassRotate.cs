using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassRotate : MonoBehaviour
{

    public Transform player;
    public Transform center;
    public float backDistance;
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(center.localPosition.z + " " + player.localPosition.z + " " + backDistance);
        if ((center.localPosition.z - player.localPosition.z) > backDistance) 
        {
            rb.AddRelativeTorque(Vector3.right * -speed);
            //Debug.Log("1");

        }
        if ((center.localPosition.z - player.localPosition.z) < -backDistance)
        {
            rb.AddRelativeTorque(Vector3.right * speed);
            //Debug.Log("1");

        }
    }
    void GetRotate()
    {

    }
}
