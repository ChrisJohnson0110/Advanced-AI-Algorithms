using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    [SerializeField] GameObject goCharacterRef; //this character ref

    [SerializeField] State chaseState;

    [SerializeField] Senses SensesRef;

    [SerializeField] List<GameObject> PatrolPoints;

    int iNumberOfPatrolPoints;
    int iCurrentPatrolPoint;

    [SerializeField] float fDistanceToPatrolPointThreshold;

    private void Start()
    {
        iNumberOfPatrolPoints = PatrolPoints.Count - 1;
        iCurrentPatrolPoint = 0;
    }

    public override State RunCurrentState()
    {
        if (SensesRef.bCanSee == true | SensesRef.bCanHear == true)
        {
            return chaseState;
        }
        else
        {
            //distance to patrol point
            float fDistance = Vector3.Distance(goCharacterRef.transform.position, PatrolPoints[iCurrentPatrolPoint].transform.position);

            if (fDistance <= fDistanceToPatrolPointThreshold) //close enough to patrol point
            {
                //increment current patrol point
                if (iCurrentPatrolPoint == iNumberOfPatrolPoints)
                {
                    iCurrentPatrolPoint = 0;
                }
                else
                {
                    iCurrentPatrolPoint++;
                }
            }
            //set movement destination
            goCharacterRef.GetComponent<NavMeshAgent>().SetDestination(PatrolPoints[iCurrentPatrolPoint].transform.position);
            return this;
        }
    }
}
