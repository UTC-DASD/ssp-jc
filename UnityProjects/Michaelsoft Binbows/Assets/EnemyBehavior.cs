using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SeralizeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(movespeed, 0f)
        } else
        {
            myRigidbody.velocity = new Vector2(-movespeed, 0f)
        }
    }

    privatebool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void private void OnTriggerExit2D(Collider2D collision) 
    {
        transform.localscale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localscale.y);
    }
}
