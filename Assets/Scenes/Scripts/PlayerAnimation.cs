using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector2 dir = playerController.Direction;
        bool isMoving = dir.magnitude > 0;

        animator.SetBool("isMoving", isMoving);
        if (isMoving)
        {
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
        }
    }
}
