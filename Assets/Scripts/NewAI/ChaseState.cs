using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// chase state behaviour
/// </summary>
public class ChaseState : State
{
    [SerializeField] GameObject goCharacterRef; //this character ref

    [SerializeField] AttackState attackState; //attack state ref
    [SerializeField] IdleState idleState; //idle state ref
    public bool isInAttackRange; //is the player in range to attack


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
            if (SensesRef.bCanSee == true | SensesRef.bCanHear == true)
            {
                //if can see or hear chase
                goCharacterRef.GetComponent<NavMeshAgent>().SetDestination(SensesRef.target.transform.position);
            }
            else
            {
                //no target
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
