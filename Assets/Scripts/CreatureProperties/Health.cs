using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// handle attach objects health
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField] GameObject HealthDisplay;

    public float health = 5f;

    private void Start()
    {
        UpdateDisplay();
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
