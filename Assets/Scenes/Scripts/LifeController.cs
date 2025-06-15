using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int maxLife = 100;
    private int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
