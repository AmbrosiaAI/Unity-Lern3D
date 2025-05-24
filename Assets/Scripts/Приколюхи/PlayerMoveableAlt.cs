using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveableAlt : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    public float MoveSpeed => _moveSpeed;
    [SerializeField]
    private float _rotationSpeed = 90f;
    public float RotationSpeed => _rotationSpeed;

    void Update()
    {
        float mz = _moveSpeed * Time.deltaTime;
        float mx = _moveSpeed * Time.deltaTime;
        float ry = _rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) ry *= 1;
        else if (Input.GetKey(KeyCode.Q)) ry *= -1;
        else ry *= 0;
        if (Input.GetKey(KeyCode.LeftShift)) ry *= 1.75f;
        else if (Input.GetKey(KeyCode.LeftControl)) ry *= 0.75f;

        if (Input.GetKey(KeyCode.W)) mz *= 1;
        else if (Input.GetKey(KeyCode.S)) mz *= -1;
        else mz *= 0;
        if (Input.GetKey(KeyCode.D)) mx *= 1;
        else if (Input.GetKey(KeyCode.A)) mx *= -1;
        else mx *= 0;
        transform.Translate(mx, 0, mz);
        transform.Rotate(0, ry, 0);
    }
}
