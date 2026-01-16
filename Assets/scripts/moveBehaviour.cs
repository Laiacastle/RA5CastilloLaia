using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Rigidbody _rB;
    [SerializeField] private float jumpH;
    public float gravity = -9.81f;
    void Start()
    {
        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
        if (_rB == null)
        {
            _rB = GetComponent<Rigidbody>();
        }
    }
    public void Move(Vector3 direction, float speed)
    {
        Vector3 movement = new Vector3(direction.x, 0f, direction.z);
        _controller.Move(movement * speed * Time.deltaTime);
        _rB.transform.position = _controller.transform.position;

    }

    public void RotateCharacter(Vector3 direction)
    {
        Debug.Log(direction);
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);


        }
    }

    public void ApplyGravity(float speed)
    {
        Vector3 movement = new Vector3(0f, gravity, 0f);
        _controller.Move(movement * speed * Time.deltaTime);
        _rB.transform.position = _controller.transform.position;
    }

    public void Jump()
    {
        if (_controller.isGrounded)
        {
            float playerJump = Mathf.Sqrt(jumpH * -2f * gravity);
            Vector3 jump = new Vector3(0f, playerJump, 0f);
            _controller.Move(jump * Time.deltaTime);
            _rB.transform.position = _controller.transform.position;
        }
    }
}
