using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    public SpriteRenderer sprite;
    private Rigidbody2D rb;

    bool isGround=false;

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
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        sprite.flipX = dir.x < 0f;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
