using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private bool isGround=false;

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
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGround = false;
        }
    }

    void FixedUpdate()
    {
        if(!isGround)
        {
            State = States.Jump;
        }
        else
        {
            State = States.Idle;
        }
        if(Input.GetButton("Horizontal") && isGround)
        {
            State = States.Run;
        }
    }

    void Update()
    {
    }

    public enum States
    {
        Idle,
        Run,
        Jump
    }
    States State
    {
        get {return(States)anim.GetInteger("state");}
        set {anim.SetInteger("state", (int)value);}
    }
}
