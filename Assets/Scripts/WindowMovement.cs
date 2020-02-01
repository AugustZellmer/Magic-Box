using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMovement : MonoBehaviour
{

    Gyroscope gyro;

    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        transform.localRotation = getAndroidGyroscopeRotation();
    }

    /*  
    I don't completely understand how this method works, but by the time it's done it will return a rotation in which
    north is positive x, up is positive y, and east is positive z, which is exactly what we want for unity's coordinate system.
    */
    private Quaternion getAndroidGyroscopeRotation()
    {
        return Quaternion.Euler(0, 90, 0) * (new Quaternion(.5f, -.5f, .5f, .5f) * gyro.attitude) * Quaternion.Euler(0, 0, 180); 
    }
}
