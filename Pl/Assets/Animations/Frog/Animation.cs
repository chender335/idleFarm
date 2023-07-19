using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        State = States.Idle;
    }

    States State
    {
        get {return(States)anim.GetInteger("state");}
        set {anim.SetInteger("state", (int)value);}
    }
}

public enum States
{
    Idle
}
