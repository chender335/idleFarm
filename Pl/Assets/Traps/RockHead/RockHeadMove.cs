using UnityEditor.Rendering;
using UnityEngine;

public class RockHeadMove : MonoBehaviour
{
    [SerializeField] private Vector2 startDirection;
    [SerializeField] private float speed;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.GetContact(0).normal);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = (startDirection * speed); 
    }
}
