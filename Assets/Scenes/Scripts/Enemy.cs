using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerTransform)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var life = collision.gameObject.GetComponent<LifeController>();
            if (life)
            {
                life.TakeDamage(10);
            }
            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
