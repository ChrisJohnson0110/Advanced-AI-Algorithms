using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTracker : MonoBehaviour
{
    [SerializeField] GameObject goPickupsFoundUIRef;

    public int totalPickups = 0 ;

    private void Start()
    {
        goPickupsFoundUIRef.SetActive(false);
    }

    /// <summary>
    /// increase pickup count and check for all found
    /// </summary>
    public void ObjectPickedup()
    {
        totalPickups++;
        if (totalPickups >= 10)
        {
            goPickupsFoundUIRef.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
