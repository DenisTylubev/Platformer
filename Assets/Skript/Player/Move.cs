using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Move : MonoBehaviour
{



    public float spead;
    public float JumpForce;
    SpriteRenderer sr;
    private Rigidbody2D rb;
     private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3 (movement, 0, 0) * spead * Time.deltaTime;
        if(anim)
        {
            anim.SetBool("RUn", Mathf.Abs(movement) >= 0.1f);

        }
       
        

        sr.flipX = movement < 0? true : false;

        
    }




}
