using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
     public Rigidbody2D rBody;
    [SerializeField] private float speed;
    private Vector2 moveInput;
    
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        
        rBody.velocity = moveInput * speed;
    }
    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
    

    
}
