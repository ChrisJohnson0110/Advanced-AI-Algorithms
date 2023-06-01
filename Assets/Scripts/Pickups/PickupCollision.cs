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
