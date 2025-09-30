using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 150f; 

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Left/Right movement
        float move = 0f;

        if (Keyboard.current.aKey.isPressed) move = -1f;
        if (Keyboard.current.dKey.isPressed) move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // tell Animator to play Idle or Walk
        bool isWalking = Mathf.Abs(move) > 0.01f;
        anim.SetBool("isWalking", isWalking);

        // Jump (velocity-based)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
