using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public Animator animator;
    public SpriteRenderer spriteRend;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.position += movement;

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
