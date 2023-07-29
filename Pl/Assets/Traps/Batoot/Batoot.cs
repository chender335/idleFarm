using UnityEngine;

public class Batoot : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private string jumpAnimationName = "Jump";
    [SerializeField] private string idleAnimationName = "Idle";

    private Collider2D collider;
    private Animator animator;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.GetContact(0).normal == Vector2.down)
        {
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, jumpForce);
            collider.enabled = false;
            animator.Play(jumpAnimationName);
        }
    }

    private void OnJumpAnimationEnd()
    {
        collider.enabled = true;
        animator.Play(idleAnimationName);
    }
}
