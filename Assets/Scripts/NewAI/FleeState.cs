using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    [SerializeField] Transform goCharacterRef; //this character ref

    [SerializeField] State idleState;

    [SerializeField] float fFleeDuration;
    bool isTimerActive = false;
    float fTimer;

    [SerializeField] Senses SensesRef;

    public override State RunCurrentState()
    {
        //timer
        if (isTimerActive == true)
        {
            fTimer -= Time.deltaTime;

            //flee

            Vector3 direction = SensesRef.target.transform.position - goCharacterRef.position; //get dir
            Vector3 oppositeDirection = -direction; //flip dir
            goCharacterRef.GetComponent<NavMeshAgent>().SetDestination(goCharacterRef.position + oppositeDirection); //set nav path

            if (fTimer <= 0)
            {
                isTimerActive = false;
                return idleState;
            }
        }
        else
        {
            isTimerActive = true;
            fTimer = fFleeDuration;
        }

        return this;
    }
}
