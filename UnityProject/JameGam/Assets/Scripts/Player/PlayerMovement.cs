using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] Rigidbody2D rb;
   
   Vector2 movement;

    public GameManager gameManager;
   
    void Update()
    {   
        if (gameManager.gameEnded == true) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        if (gameManager.gameEnded == true) return;
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
