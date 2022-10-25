using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveDirection { get; private set; }
    public float rotateDirection { get; private set; } 
    public Rigidbody rb;
    public Transform cannon;
    public int speed = 10;

    PlayerInput actions;
    private InputAction move;
    private InputAction rotate;
    private InputAction fire;

    private void Awake()
    {
        actions = new PlayerInput();
    }
    private void OnEnable()
    {
        move = actions.Player.Move;
        move.Enable();

        rotate = actions.Player.Rotate;
        rotate.Enable();
                
    }

    private void OnDisable()
    {
        move.Disable();
        rotate.Disable();
    }
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        Debug.Log(moveDirection);
        rotateDirection = rotate.ReadValue<float>();
        
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = new Vector3(0, moveDirection.x * speed, 0);
        rb.velocity = speed * -moveDirection.y * transform.up;

        //rb.velocity = new Vector3(0, 0, moveDirection.y * speed);

        cannon.Rotate(new Vector3(rotateDirection * speed * 0.5f, 0, 0));
    
    }

    public void Fire()
    {
        Debug.Log("Fire!");
    }

    void Start()
    {

    }

    // Update is called once per frame
}
