using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    Rigidbody car;
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            car.AddForce(new Vector3(0, 0, 2), ForceMode.Force);
        }
        if(Input.GetKey(KeyCode.S))
        {
            car.AddForce(new Vector3(0,0,-2), ForceMode.Force);
        }
        if(Input.GetKey(KeyCode.D))
        {
            car.MoveRotation(Quaternion);
        }
        if (Input.GetKey(KeyCode.A))
        {
            car.MoveRotation(new Quaternion(0, -1, 0, 0));
        }
    }
}
