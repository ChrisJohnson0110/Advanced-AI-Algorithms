using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject HealthDisplay;

    public float health = 5f;
    float fTimer; //current countdown time for regening


    private void Start()
    {
        UpdateDisplay();
    }

    private void Update()
    {
        if (fTimer > 0 )
        {
            fTimer -= Time.deltaTime;
        }
        else
        {
            //regen
        }
    }

    public void TakeDamage(float a_fDamageToTake)
    {
        health -= a_fDamageToTake;

        if (health <= 0)
        {
            if (HealthDisplay != null)
            {
                HealthDisplay.SetActive(false);
                //Destroy(HealthDisplay);
            }
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (HealthDisplay != null)
        {
            HealthDisplay.GetComponent<Text>().text = health.ToString();
        }
    }
}
