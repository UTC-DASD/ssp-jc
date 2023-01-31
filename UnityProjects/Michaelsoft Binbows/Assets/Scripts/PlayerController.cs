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
            Vector3 trailRightOffset = new Vector3 (-1.0f, -0.6f, 0.0f);
            trailGO.transform.position = playerPosition - trailRightOffset;
        }
        else
        {
            Vector3 trailLeftOffset = new Vector3 (1.0f, -0.6f, 0.0f);
            trailGO.transform.position = playerPosition - trailLeftOffset;
        }
    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            playerAnim.SetBool("IsWalking", true);
        }
        else
        {
            playerAnim.SetBool("IsWalking", false);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
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