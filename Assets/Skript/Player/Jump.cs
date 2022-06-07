using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool isGrounded;
    public float jumpForce;
    public Transform groundCheack;
    public float cheackRadius;
    public LayerMask watIsGround;
    private  int extraJump;
    public int extraJumpsValue;
    Rigidbody2D rb;
    Animator anim;

    
    void Start()
    {
        extraJump = extraJumpsValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(isGrounded ==  true)
        {
            extraJump = extraJumpsValue;
            
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJump  > 0)
        {
           
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            anim.SetTrigger("JUMP");

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            

        }
    }

    private  void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheack.position,cheackRadius,watIsGround);
       
    }
}
 