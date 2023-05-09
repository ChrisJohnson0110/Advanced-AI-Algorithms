using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAI : MonoBehaviour
{
    AggressiveAI AggressiveAIRef;
    GameObject target;

    NavMeshAgent agent; //this agent
    LayerMask TargetLayer; // what is a danger
    float fAttackRange; //attack range
    float AgroRange; // distance that if a danger is within will flee


    // Start is called before the first frame update
    void Start()
    {
        AggressiveAIRef = GetComponent<AggressiveAI>();

        agent = GetComponent<NavMeshAgent>(); //get this agent
        TargetLayer = LayerMask.GetMask("FriendlyCreature");
        AgroRange = AggressiveAIRef.EnemySORef.EnemyProperties.AgroRange;
        fAttackRange = AggressiveAIRef.EnemySORef.EnemyProperties.AttackRange;


        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > fAttackRange) //is not in range of attack
        {
            if (CheckForTarget() == true) //if danger in agro range
            {
                AggressiveAIRef.SetState(AggressiveAI.Behaviours.Chase); //switch to chase
            }
            else
            {
                AggressiveAIRef.EnemySORef.SetState(Enemy.Behaviours.Wander); //switch to wander
            }
        }
    }
    
    /// <summary>
    /// follow target
    /// </summary>
    public void Chase()
    {
        agent.SetDestination(target.transform.position); //chase target
    }


    /// <summary>
    /// find target
    /// </summary>
    public bool CheckForTarget()
    {
        Collider[] dangerColliders = Physics.OverlapSphere(transform.position, AgroRange, TargetLayer); //find dangers
        if (dangerColliders.Length > 0)
        {
            target = dangerColliders[0].gameObject; //set target
            return true;
        }
        return false;
    }
}
