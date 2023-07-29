using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallStartSpeed;
    [SerializeField] private float fallAcceleration;
    [SerializeField] private float fallDistance;
    [SerializeField] private string fallAnimationName = "Fall";
    [SerializeField] private float deltaYIfIdle;
    [SerializeField] private float idleSpeed;

    private float distancePassed;
    private bool isFalling;
    private float previousY;
    private float curentSpeed;
    private float startY;
    private Vector2 moveDirection;

    private Animator animator;
#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    private Collider2D collider;
#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово

    private void Awake()
    {
        previousY = transform.position.y;
        moveDirection = Vector2.up;
        startY = transform.position.y;
        animator = GetComponent<Animator>();
        curentSpeed = fallStartSpeed;
        collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (isFalling)
        {
            transform.position += (Vector3)(Vector2.down * curentSpeed * Time.deltaTime);
            curentSpeed += fallAcceleration * Time.deltaTime;

            distancePassed += Mathf.Abs(transform.position.y - previousY);
            previousY = transform.position.y;
            if (distancePassed >= fallDistance)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            MoveUpDown();
        }
    }

    private void MoveUpDown()
    {
        transform.position += (Vector3)(moveDirection * idleSpeed * Time.deltaTime);

        if(transform.position.y >= startY + deltaYIfIdle)
        {
            moveDirection = Vector3.down;
        }
        else if(transform.position.y <= startY - deltaYIfIdle)
        {
            moveDirection = Vector3.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal == Vector2.down)
        {
            Fall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Fall();
    }

    private void Fall()
    {
        isFalling = true;
        animator.Play(fallAnimationName);
        collider.isTrigger = true;
    }
}
