using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
   [SerializeField] float mouseDelay = 4f;
   [SerializeField] GameObject mousePrefab;
   [SerializeField] Transform cheesePos;

   [SerializeField] float peaDelay = 10f;
   [SerializeField] GameObject peaPrefab;

    [HideInInspector]
   public bool gameEnded = false;


   [SerializeField] TextMeshProUGUI countdownText;
   [SerializeField] float timeLeft;    

   [SerializeField] Animator textMessage;

   private bool gameStarted = false;

   [SerializeField] GameObject LoseUI;
   [SerializeField] GameObject WinUI;

    void Start()
    {
        gameStarted = false;
        gameEnded = false;
        StartCoroutine(messageAnim());

    }

    void Update()
    {   
        startTimer();
        if (timeLeft <= 60)
        {
            mouseDelay = 2.5f;
        }
    }

    IEnumerator messageAnim()
    {
        textMessage.Play("Message", 0, 0f);
        yield return new WaitForSeconds(5f);
        textMessage.Play("MesssageOut", 0, 0f);
        gameStarted = true;
        StartCoroutine(SpawnPea());
        StartCoroutine(SpawnMouse());
    }
    void startTimer()
    {   
        if (timeLeft > 0 && gameStarted == true)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft <= 0)
        {
            timeLeft = 0;
            winGame();
        }
        
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        countdownText.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void loseGame()
    {
        gameEnded = true;
        LoseUI.SetActive(true);
    }

    void winGame()
    {
        gameEnded = true;
        WinUI.SetActive(true);
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
                mouseScript.gameManager = this;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 1)
            {
                mousePos.x = Random.Range(-24, 32);
                mousePos.y = 27;
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.gameManager = this;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 2)
            {
                mousePos.x = 33;
                mousePos.y = Random.Range(26, -15);
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.gameManager = this;
                mouseScript.mouseSpeed = Random.Range(2f, 6f);
            }
            else if (MSquare == 3)
            {
                mousePos.x = Random.Range(-24, 32);
                mousePos.y = -16;
                GameObject mouseSpawned = Instantiate(mousePrefab, mousePos, Quaternion.identity);
                Mouse mouseScript = mouseSpawned.GetComponent<Mouse>();
                mouseScript.cheesePos = cheesePos;
                mouseScript.gameManager = this;
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

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
