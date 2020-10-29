using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWithRaycast : MonoBehaviour
{
    //Normal PlayerController Movement
    Rigidbody2D rb;
    public float speed = 5.0f;
    public float jumpForce = 5.2f;
    //Raycast variables to check if player is on the floor
    public bool isGrounded; //Keeps track of if the player is touching the floor or not. We update this every frame
    public LayerMask groundLayer; //The layer that the Raycast is actively looking for
    public float collisionRadius = 1.0f; //How far the Raycast is going to look for the layer we have specified.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    //I have put the movement code into its own function that is then called in the Update() function. 
    // this keeps our files clean and easy to read
    void Move(){
        float x = Input.GetAxisRaw("Horizontal"); 
        float moveBy = x * speed; 
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }
    
    void Jump() { 
        //Raycast parameters:
        // 1. The position the Ray will start at AKA the ray origin. This will be the center of our players current position. i.e. transform.position
        // 2. The direction of our Ray. We want to look down to check for the floor. i.e. Vector2.down - Equivalent to new Vector2(0,-1)
        // 3. How far our Ray will look for the specified Layer
        // 4. The Layer our Ray is looking for. Were going to look for the Ground layer that we will create and specify in the Unity Editor
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, collisionRadius, groundLayer);

        //If the player presses the spacebar AND they are on the ground (according to the raycast) then our player can jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        } 
    }
}
