using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    int jumpNum;

    public SpriteRenderer sprite;
    private Rigidbody2D rb;

    bool isGround=false;
    bool isWall=false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGround = true;
        jumpNum = 1;
        }
        if(col.gameObject.tag == "Wall")
        {
        isWall = true;
        jumpNum = 1;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGround = false;
        }
        if(col.gameObject.tag == "Wall")
        {
        isWall = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && (jumpNum != 0))
        {
            Jump(1);
        }
        else if (Input.GetButtonDown("Jump") && (jumpNum != 0))
        {
            Jump(2);
        }
        if(Input.GetButton("Horizontal") && !(Input.GetButtonDown("Jump") && isWall))
        {
            Run();
        }   
    }

    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        sprite.flipX = Input.GetAxis("Horizontal") < 0f;
    }

    void Jump(int num)
    {
        switch(num)
        {
            case 1:
            rb.velocity = Vector2.up * jumpForce;
            jumpNum -= 1;
            break;
            case 2:
            rb.velocity = Vector2.up * jumpForce;
            jumpNum -= 1;
            //rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed * -1;
            break;
        }
    }
}
