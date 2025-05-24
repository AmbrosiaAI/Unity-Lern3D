using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotation : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    private float _rotationSpeed = 50f;
    public float RotationSpeed => _rotationSpeed;
    public float MoveSpeed => _moveSpeed;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(0, 0, z);
        movement = Vector3.ClampMagnitude(movement, _moveSpeed);
        movement = transform.TransformDirection(movement);
        controller?.Move(movement);
        transform.Rotate(0, x, 0);
    }
}
