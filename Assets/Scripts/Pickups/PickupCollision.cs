using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollision : MonoBehaviour
{
    PickupTracker PickupTrackerRef;

    private void Start()
    {
        PickupTrackerRef = GameObject.FindObjectOfType<PickupTracker>();
    }

    /// <summary>
    /// if the player is touching and interacting hide this object and increase pickup count
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                PickupTrackerRef.ObjectPickedup();
                gameObject.SetActive(false);
            }
        }
    }
}
