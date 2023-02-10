using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private SpriteRenderer playerSprite;
    public GameObject trailGO;
    private Animator playerAnim;
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    [SerializeField] private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    // Start is called before the first frame update
    
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();


        moveSpeed = 3f;
        jumpForce = 60f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 playerPosition = gameObject.transform.position;
        //Vector3 trailOffset = gameObject.transform.position;
        

        if(!isJumping && Input.GetKeyDown("space"))
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            /*
            playerAnim.SetBool("IsIdle", false);
            playerAnim.SetBool("IsWalking", false);
            playerAnim.SetBool("IsJumping", true);
            */
        }
        //playerSprite.flipX
        if(moveHorizontal > 0 && playerSprite.flipX)
        {
            
            playerSprite.flipX = false;
            //Vector3 playerPosition = gameObject.transform.position;
            //Vector3 trailOffset = gameObject.transform.position;
            
        }
        else if(moveHorizontal < 0 && !playerSprite.flipX)
        {
            
            playerSprite.flipX = true;
            
            //trailGO.transform.position = new Vector3 (1.8f, 1, 0.0f);
        }

        if(playerSprite.flipX)
        {
           

        if(rb2D.velocity.x != 0)
        {
            playerAnim.SetBool("IsWalking", true);
        }
        else
        {
            playerAnim.SetBool("IsWalking", false);
        }

        if(rb2D.velocity.y != 0)
        {
            playerAnim.SetBool("IsJumping", true);
        }
        else
        {
            playerAnim.SetBool("IsJumping", false);
        }
        
        if(playerAnim.GetBool("IsWalking") || playerAnim.GetBool("IsJumping"))
        {
            playerAnim.SetBool("IsIdle", false);
        }
        else
        {
            playerAnim.SetBool("IsIdle", true);
        }

    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            /*
            playerAnim.SetBool("IsIdle", false);
            playerAnim.SetBool("IsWalking", true);
            playerAnim.SetBool("IsJumping", false);
            */
        }
        else if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            /*
            playerAnim.SetBool("IsIdle", false);
            playerAnim.SetBool("IsWalking", false);
            playerAnim.SetBool("IsJumping", true);
            */
        }
        else
        {
            /*
            playerAnim.SetBool("IsIdle", true);
            playerAnim.SetBool("IsWalking", false);
            playerAnim.SetBool("IsJumping", false);
            */
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            //playerAnim.SetBool("IsJumping", false);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}