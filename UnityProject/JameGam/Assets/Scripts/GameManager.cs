using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] float mouseDelay = 4f;
   [SerializeField] GameObject mousePrefab;
   [SerializeField] Transform cheesePos;

   [SerializeField] float peaDelay = 8f;
   [SerializeField] GameObject peaPrefab;

    [HideInInspector]
   public bool gameEnded = false;
    
    void Start()
    {
        gameEnded = false;
        StartCoroutine(SpawnPea());
        StartCoroutine(SpawnMouse());
    }

    void Update()
    {   

    }

    public void loseGame()
    {
        Debug.Log("Lose Game");
        gameEnded = true;
    }

    void winGame()
    {
        Debug.Log("Win Game");
        gameEnded = true;
    }
    IEnumerator SpawnMouse()
    {   
        while (gameEnded == false)
        {   
            int MSquare = Random.Range(0,4);
            Vector2 mousePos;
              
            if (MSquare == 0)
            {    
                mousePos.x = -26;
                mousePos.y = Random.Range(26, -15);
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 1)
            {
                mousePos.x = Random.Range(-24, 32);
                mousePos.y = 27;
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 2)
            {
                mousePos.x = 33;
                mousePos.y = Random.Range(26, -15);
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 3)
            {
                mousePos.x = Random.Range(-24, 32);
                mousePos.y = -16;
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }

            yield return new WaitForSeconds(mouseDelay);
        }

    }

    IEnumerator SpawnPea()
    {   
        while (gameEnded == false)
        {
            int Square = Random.Range(0,4);
            Vector2 peaPos;  

            if (Square == 0)
            {    
                peaPos.x = Random.Range(-25, -10);
                peaPos.y = Random.Range(-12 ,20);
                Instantiate(peaPrefab, peaPos, Quaternion.identity);
            }
            else if (Square == 1)
            {
                peaPos.x = Random.Range(-25, 22);
                peaPos.y = Random.Range(12 , 20);
                Instantiate(peaPrefab, peaPos, Quaternion.identity);
            }
            else if (Square == 2)
            {
                peaPos.x = Random.Range(5, 22);
                peaPos.y = Random.Range(-12 , 20);
                Instantiate(peaPrefab, peaPos, Quaternion.identity);
            }
            else if (Square == 3)
            {
                peaPos.x = Random.Range(-25, 22);
                peaPos.y = Random.Range(-12 , 1);
                Instantiate(peaPrefab, peaPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(peaDelay);
        }

    }
}
