using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarryPatrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5.0f;

    [Space]
    public Transform leftTransform;
    public Transform rightTransform;

    public LayerMask groundLayer;

    //We need to give Larry an initial direction to travel. We change this in the Update function
    Vector2 moveVector = Vector2.right;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check if the Left Transform CANT detect the ground layer underneath it. In this case, were setting the movement vector to the right
        if(!Physics2D.Raycast(leftTransform.position, Vector2.down, 1, groundLayer)){
            moveVector = Vector2.right;
        }
        //Check if the Right Transform CANT detect the ground layer underneath it. In this case, were setting the movement vector to the left
        if(!Physics2D.Raycast(rightTransform.position, Vector2.down, 1, groundLayer)){
            moveVector = Vector2.left;
        }
        
        //Move Larry in the calculated direction, left or right, by the speed we have specified. I've given it 5 by default.
        rb.velocity = speed * moveVector;
    }
}
