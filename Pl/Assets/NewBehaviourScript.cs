using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        Debug.Log(normal == Vector2.up ? "up" : (normal == Vector2.left ? "left" : normal == Vector2.right ? "right" : "down"));
    }
}
