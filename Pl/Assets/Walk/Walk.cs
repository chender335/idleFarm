using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float jumpForce;
    public float speed;

    public SpriteRenderer sprite;
    public Rigidbody2D rb;

    bool isGround=false;



    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGround = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGround)
        {
            Jump();
        }
        if(Input.GetButton("Horizontal"))
        {
            Run();
        }   
    }

    void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        if(Input.GetAxis("Horizontal")>0)
        {
            transform.position = Vector3.MoveTowards(transform.position,transform.position + dir,speed * Time.deltaTime);
        }
        else if(Input.GetAxis("Horizontal")<0)
        {
            transform.position = Vector3.MoveTowards(transform.position,transform.position + dir,speed * Time.deltaTime);
        }
        sprite.flipX = dir.x < 0f;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
