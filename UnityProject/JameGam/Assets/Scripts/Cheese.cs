using UnityEngine;
using TMPro;

public class Cheese : MonoBehaviour
{
   [HideInInspector]
   public float cheeseHealth = 100f;

   [SerializeField] TMP_Text healthText;

    void Start()
    {
        cheeseHealth = 100f;
        healthText.text = cheeseHealth.ToString("F0") +" / 100";
    }


    void Update()
    {
        healthText.text = cheeseHealth.ToString("F0") +" / 100";

        if (cheeseHealth >= 51)
        {
            healthText.color = new Color(0.416f, 0.616f, 0.443f);
        }
        else if (cheeseHealth <= 51 && cheeseHealth >= 21)
        {
            healthText.color = new Color(0.886f, 0.706f, 0.584f);
        }
        else if (cheeseHealth <= 20)
        {
            healthText.color = new Color(0.635f, 0.408f, 0.404f);
        }

        if (cheeseHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
