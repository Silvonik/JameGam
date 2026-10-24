using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] float mouseDelay = 5f;
   [SerializeField] GameObject mousePrefab;
   [SerializeField] Transform cheesePos;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(SpawnMouse());
        }
    }

    IEnumerator SpawnMouse()
    {
        GameObject mouseSpawned = Instantiate(mousePrefab, transform.position, transform.rotation);
        Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
        mouseScript.cheesePos = cheesePos;
        yield return new WaitForSeconds(mouseDelay);
    }
}
