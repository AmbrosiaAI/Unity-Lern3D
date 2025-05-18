using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovable : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    public float MoveSpeed => _moveSpeed;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3 (x, 0, z);
        movement = Vector3.ClampMagnitude(movement, _moveSpeed);
        movement = transform.TransformDirection(movement);
        controller?.Move(movement);
    }
}