using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject gunPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(gunPrefab, collision.transform);
            Destroy(gameObject);
        }
    }
}
