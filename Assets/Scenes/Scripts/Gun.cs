using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public float detectionRange = 5f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        Collider2D enemy = Physics2D.OverlapCircle(transform.position, detectionRange, LayerMask.GetMask("Enemy"));
        if (enemy && fireTimer >= fireRate)
        {
            ShootAt(enemy.transform);
            fireTimer = 0;
        }
    }

    private void ShootAt(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Setup(direction);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
