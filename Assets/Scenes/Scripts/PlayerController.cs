using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float horizontal;
    private float vertical;

    private Rigidbody2D rb;

    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += Direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }
}
