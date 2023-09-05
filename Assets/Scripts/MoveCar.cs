using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakForce = 300f;
    public float turnAngle = 20f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        frontLeft.motorTorque= currentAcceleration;
        frontRight.motorTorque = currentAcceleration;


        currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //UpdateWheel(frontLeft, frontLeftTransform);
        //UpdateWheel(backLeft, backLeftTransform);
        //UpdateWheel(backRight, backRightTransform);
        //UpdateWheel(frontRight, frontRightTransform);
    }

    void UpdateWheel(WheelCollider col, Transform transform)
    {
        Vector3 pos;
        Quaternion quaternion;
        col.GetWorldPose(out pos, out quaternion);

        transform.position = pos;
        transform.rotation = quaternion;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.S))
        {
        }
        if(Input.GetKey(KeyCode.D))
        {
        }
        if (Input.GetKey(KeyCode.A))
        {
        }
    }
}
