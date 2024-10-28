using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
   [SerializeField] float playerSpeed;
    public Rigidbody2D rb;
    private Animator anim;
    private bool grounded;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        float horizontalinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y);
        //flip player back and forth
        if (horizontalinput > 0.01f) 
        { 
            transform.localScale = new Vector3(-0.48f, .45f, 1);
            
        }else if (horizontalinput < -0.01f) 
        {
            transform.localScale = new Vector3(0.48f, .45f,1);
        
        }
        //jump with space bar
        if (Input.GetKey(KeyCode.Space)&& grounded) 
        {
            jump();


        }

        //set animation
        anim.SetBool("Run", horizontalinput !=0);
        //anim.SetBool("grounded", grounded);
    }
    void jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
        grounded = false;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
            grounded = true;
    }
}
