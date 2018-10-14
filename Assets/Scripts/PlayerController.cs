using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Öll hreyfing fyrir kallinn. 

    public float speed;
    public float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;
    public bool facingRight = true;
    private bool isGrounded = true;
    float outofbounds = -25f;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;

    public Transform firePoint;
    public GameObject missile;

    Animator anim;

    

    
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Gefið player extra jump sem er limitað á eitt.
        Movement();

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        
    }

    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius, whatIsGround);
        /*
         * Upprunalega move functionið
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        */

    }

        

    void Movement() //Núverandi move function sem er mjög sniðugt. Ef horizontal ásinn er í plús fer hann til hægri, og svo öfugt fer hann til vinstri.
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        /*
        if(rb.velocity.x == 0 && rb.velocity.z == 0)
        {
            anim.Stop("labba");
        }
        */

        //Skjóta missiles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, firePoint.position, firePoint.rotation);
        }

    }

    public MissileController missileSpeed;
    //Flippað sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;        
        transform.localScale = Scaler;
        
    }
}
