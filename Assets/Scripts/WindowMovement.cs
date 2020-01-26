using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMovement : MonoBehaviour
{

    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        transform.localRotation = GyroToUnity(gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(.5f, .5f, -.5f, .5f) * q;
    }
}
