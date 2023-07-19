using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float throwSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = new Vector2 (rigidbody.velocity.x, throwSpeed);
            OnUse();
        }
    }

    private void OnUse()
    {
        Destroy(gameObject);
    }

}
