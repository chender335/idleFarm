using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private bool isGround=false;
    private bool isWall=false;

    int jumpNum;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
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
        if(Input.GetButtonDown("Jump"))
        {
            jumpNum -= 1;
        }
        if(!isGround)
        {
            if(isWall && Input.GetButton("Horizontal"))
        {
            State = States.Wall;
        }
        else if(jumpNum <= 0)
        {
            State = States.DoubleJump;
        }
        else
        {
            State = States.Jump;
        }
        }
        else if(Input.GetButton("Horizontal") && isGround)
        {
            State = States.Run;
        }
        else
        {
            State = States.Idle;
        }
    }

    public enum States
    {
        Idle,
        Run,
        Jump,
        Wall,
        DoubleJump
    }
    States State
    {
        get {return(States)anim.GetInteger("state");}
        set {anim.SetInteger("state", (int)value);}
    }
}
