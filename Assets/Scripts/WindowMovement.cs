using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMovement : MonoBehaviour
{
    private Gyroscope gyro;
    [SerializeField] private Quaternion baseAngle = new Quaternion(0, 0, 0, 1);

    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        transform.localRotation = new Quaternion(.5f, .5f, -.5f, .5f) * GyroToUnity(gyro.attitude) * Quaternion.Normalize(baseAngle);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
