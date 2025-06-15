using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 10;

    private Rigidbody2D rb;
    private Vector2 direction;

    public void Setup(Vector2 direction)
    {
        this.direction = direction.normalized;
        Destroy(gameObject, lifetime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var life = collision.GetComponent<LifeController>();
        if (life)
        {
            life.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
