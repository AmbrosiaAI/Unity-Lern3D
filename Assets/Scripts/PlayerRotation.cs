using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CameraRotate {X, Y}
public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 3000f;
    public float RotationSpeed => _rotationSpeed;
    public CameraRotate CRotate = CameraRotate.X;

    public float maxAngle = 45f;
    public float minAngle = -45f;
    private float currenrAngle=0;
    void Update()
    {
        float y = 0;
        float x = 0;
        switch (CRotate)
        {
            case CameraRotate.Y:
                y = -Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
                currenrAngle = Mathf.Clamp(currenrAngle+y, minAngle, maxAngle);
                break;
            case CameraRotate.X:
                x = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
                break;
        } 
            transform.localEulerAngles = new Vector3(currenrAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.Rotate(0, x, 0);
    }
}
