using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] Rigidbody2D rb;
   

   Vector2 movement;
   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
