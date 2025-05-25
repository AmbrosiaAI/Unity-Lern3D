using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovable : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    private float _gravity= -9.8f;
    public float MoveSpeed => _moveSpeed;
    public float Gravity => _gravity;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3 (x, _gravity, z);
        movement = Vector3.ClampMagnitude(movement, _moveSpeed);
        movement = transform.TransformDirection(movement);
        controller?.Move(movement);
    }
}