using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float jumpH = 1.5f;
    public float gravity = -30f;
    private float verticalVelocity;
    void Start()
    {
        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
    }
    public void Move(Vector3 direction, float speed)
    {
        Vector3 movement = new Vector3(direction.x, 0f, direction.z);
        _controller.Move(movement * speed * Time.deltaTime);

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

    public void ApplyGravity()
    {
        if (_controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // mantiene pegado al suelo
        }

        verticalVelocity += gravity * Time.deltaTime;
        _controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpH * -2f * gravity);
            Debug.Log("Jump velocity: " + verticalVelocity);
        }
    }
}
