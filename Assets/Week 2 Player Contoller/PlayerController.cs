using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 5.0f;
    public float jumpForce = 5.2f;
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
        if (Input.GetKeyDown(KeyCode.Space)) { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        } 
    }
}
