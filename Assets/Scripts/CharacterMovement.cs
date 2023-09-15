using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public Animator animator;
    public SpriteRenderer spriteRend;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Vector Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed;

        rb.velocity = new Vector2(movement.x, movement.y);

        //plays walking animation if character is moving in any direction
        if (horizontalInput != 0 || verticalInput != 0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }

        if (horizontalInput >= 0)
        {
            spriteRend.flipX = false;
        }
        else
        {
            spriteRend.flipX = true;
        }

    }
}
