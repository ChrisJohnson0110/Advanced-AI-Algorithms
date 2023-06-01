using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    [SerializeField] GameObject goCharacterRef; //this character ref

    [SerializeField] AttackState attackState;
    [SerializeField] IdleState idleState;
    public bool isInAttackRange;


    [SerializeField] Senses SensesRef;


   public override State RunCurrentState()
    {
        if (isInAttackRange == true)
        {
            isInAttackRange = false;
            return attackState;
        }
        else
        {

            //move towards target
            if (SensesRef.bCanSee == true | SensesRef.bCanHear == true)
            {
                goCharacterRef.GetComponent<NavMeshAgent>().SetDestination(SensesRef.target.transform.position);
            }
            else
            {
                return idleState;
            }

            return this;
        }
    }

    /// <summary>
    /// if in attack range
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isInAttackRange = true;
        }
    }
}
