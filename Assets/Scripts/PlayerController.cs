using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] 
    public float speed;
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Health")]
    public int lives;

    public bool invulnerable;
    private float currentInvulnerabilityTime;
    public float invulnerabilityTime;
    private InputAction jumpAction;
    private InputAction movementAction;
    
    private void Start()
    {
        movementAction = InputSystem.actions.FindAction("Move");
        movementAction.Enable();
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.Enable();
    }

    private void Update()
    {
        //if (InputSystem.)
        if (currentInvulnerabilityTime > 0)
        {
            currentInvulnerabilityTime -= Time.deltaTime;
            if (currentInvulnerabilityTime <= 0)
            {
                invulnerable = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementAction.ReadValue<Vector2>().x, 0) * speed;
    }

    private void OnHurt()
    {
        if (!invulnerable)
        {
            lives--;
            currentInvulnerabilityTime = invulnerabilityTime;
            invulnerable = true;
        }
    }
}
