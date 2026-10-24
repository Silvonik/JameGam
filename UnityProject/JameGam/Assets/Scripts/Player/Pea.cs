using UnityEngine;

public class Pea : MonoBehaviour
{
    public Throwing throwingScript;
    private Vector2 moveDirection;
    private float speed;

    void Start()
    {
        Destroy(gameObject, 25f);

        if (throwingScript != null)
        {
            moveDirection = throwingScript.throwDirection;
            speed = throwingScript.throwSpeed;
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
