using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed;
    public float jumpspeed;
    private bool isJumping=false;
    public Transform GroundDetector;
    public LayerMask groundMask;
    public float groundRadius;
    public AudioClip jumpSound;
    public AudioClip collectSound;
    public AudioSource sounds;
 


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            
            Jump();
           
        }

    }

    private void FixedUpdate()
    {
        //rig.velocity = new Vector2(speed,rig.velocity.y);
        Vector2 velocity = rig.velocity;
        velocity.x = speed;
        if (isJumping)
        {
            sounds.PlayOneShot(jumpSound);
            velocity.y = jumpspeed;
            isJumping = false;
        }
       
        rig.velocity = velocity;

        

    }
     
    public void Jump()
    {   if(isGrounded())
        isJumping = true;
    }


    


    public bool isGrounded()
    {
         Collider2D ground=Physics2D.OverlapCircle(GroundDetector.position, groundRadius, groundMask);
        return ground != null;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        else if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            sounds.PlayOneShot(collectSound);

        }
            

    }


}
