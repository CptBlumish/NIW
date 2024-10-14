using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Input = UnityEngine.Input;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    // variables for jumping
    [SerializeField] int jumpPower;
    Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float speed = 10f;
    //code for enemy collsion & attack
    public GameObject Enemy;
    [SerializeField] GameObject Attackrange = default;
    private bool isAttacking = false;
    private float attackTime = 0.75f;
    private float timer = 0f;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Attackrange = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(new Vector2(0,3),ForceMode.Impulse);
        }
        */
        Movement();
        JumpMove();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackSwing();
        }
        if (isAttacking) 
        {
            timer = Time.deltaTime;
            if ( timer >= attackTime) 
            {
                timer = 0f;
                isAttacking = false;
                Attackrange.SetActive(Attackrange);


            }
        }
       

        
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
    }
    
    void JumpMove()
    {

        if (Input.GetKeyDown(KeyCode.Space)&& Groundem())
        {
            Debug.Log("Jumping!");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            
        }
        else 
        {
            Debug.Log("hoe i aint movin");
        }
       
    }
    bool Groundem()
    {
        bool isgounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.04f, 0.35f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        return isgounded;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
           

        }
        
    }
    void AttackSwing() 
    {
       isAttacking = true;
        Attackrange.SetActive(isAttacking);
    }
}
