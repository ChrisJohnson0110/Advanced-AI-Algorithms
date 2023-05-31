using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    [SerializeField] Transform goCharacter;

    [SerializeField] Senses SensesRef;

    [SerializeField] string sTagToCheck;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == sTagToCheck) //if collision with target to check tag
        {
            //raycast to target
        }
    }
}
