using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject throwObject;

    public float throwSpeed = 5f;

    [SerializeField] int ammo = 5;
    private bool hasAmmo = true;
    [SerializeField] GameObject ammoHold;
    [SerializeField] TMP_Text ammoUI;


    [SerializeField] Camera cam;

    [HideInInspector] 
    public Vector2 throwDirection;

    public GameManager gameManager;

    void Update()
    {   
        if (ammo >= 1)
        {
            hasAmmo = true;
            ammoHold.SetActive(true);

        }
        else
        {
            hasAmmo = false;
            ammoHold.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && hasAmmo && gameManager.gameEnded == false)
        {
            Throw();
        }

        ammoUI.text = "Peas: " + ammo.ToSafeString();
    }

    void Throw()
    {
        ammo -= 1;

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        throwDirection = (mousePos - (Vector2)throwPoint.position).normalized;

        GameObject pea = Instantiate(throwObject, throwPoint.position, throwPoint.rotation);
        Pea peaScript = pea.GetComponent<Pea>();
        peaScript.throwingScript = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PeaReload"))
        {
            Destroy(collision.gameObject);
            ammo += 3;
        }
    }
}
