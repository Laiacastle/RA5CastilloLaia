using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private AnimationBehaviour _aB;
    public float speed = 5f;

    [SerializeField] private Vector3 moveInput;
    [SerializeField] private Vector3 moveDirection;
     private InputSystem_Actions inputActions;
    [SerializeField] private MoveBehaviour _mB;
    private Vector3 direction;
    public bool dancing = false;
    public event Action<bool> DanceEvent = delegate { };
    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _aB.Dance();
            dancing = !dancing;
            
           DanceEvent.Invoke(dancing);
            
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!dancing)
        {
            Vector2 input = context.ReadValue<Vector2>();
            direction = new Vector3(input.x, 0, input.y);
        }
        
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputSystem_Actions();
            inputActions.Player.SetCallbacks(this);
        }
        inputActions.Player.Enable();
    }
    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _mB = GetComponent<MoveBehaviour>();
        _aB = GetComponent<AnimationBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        _mB.Move(direction, speed);
        _mB.RotateCharacter(direction);
        _aB.Move(direction);
        _mB.ApplyGravity(_moveSpeed);
    }
}
