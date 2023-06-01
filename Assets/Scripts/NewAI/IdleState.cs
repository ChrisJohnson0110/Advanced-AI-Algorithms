using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    [SerializeField] GameObject goCharacterRef; //this character ref

    [SerializeField] ChaseState chaseState;
    [SerializeField] PatrolState patrolState;

    [SerializeField] Senses SensesRef;

    [SerializeField] float fRotationSpeed;
    [SerializeField] float fTimerStartDuration;
    bool isTimerActive = false;
    float fTimer;

    public override State RunCurrentState()
    {
        if (SensesRef.bCanSee == true | SensesRef.bCanHear == true)
        {
            return chaseState;
        }
        else
        {
            //stop pathing
            goCharacterRef.GetComponent<NavMeshAgent>().SetDestination(goCharacterRef.transform.position);


            //spin
            float fRotationAmount = fRotationSpeed * Time.deltaTime;
            goCharacterRef.transform.Rotate(Vector3.up, fRotationAmount);

            //timer
            if (isTimerActive == true)
            {
                fTimer -= Time.deltaTime;
                if (fTimer <= 0)
                {
                    isTimerActive = false;
                    return patrolState;
                }
            }
            else
            {
                isTimerActive = true;
                fTimer = fTimerStartDuration;
            }

            return this;
        }
    }
}
