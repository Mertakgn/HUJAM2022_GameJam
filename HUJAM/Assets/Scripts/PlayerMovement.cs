using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    void Start()
    {

    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    
}
