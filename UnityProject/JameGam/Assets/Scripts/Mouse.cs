using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
   [SerializeField] float speed = 3f;
   public Transform cheesePos;

    void Update()
    {   
        if (cheesePos == null)
        {
            return;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, cheesePos.position, speed * Time.deltaTime);
        
        lookCheese();

        if (transform.position == cheesePos.position)
        {
            cheesePos.gameObject.GetComponent<Cheese>().cheeseHealth -= 15;
            Destroy(gameObject);
        }
    }

    void lookCheese()
    {
        Vector2 Direction = transform.position - cheesePos.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
