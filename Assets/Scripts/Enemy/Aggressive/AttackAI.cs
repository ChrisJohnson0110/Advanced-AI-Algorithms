using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackAI : MonoBehaviour
{
    AggressiveAI AggressiveAIRef;
    NavMeshAgent agent; //this agent
    GameObject target;

    float fAttackRange; //attack range




    // Start is called before the first frame update
    void Start()
    {
        AggressiveAIRef = GetComponent<AggressiveAI>();
        agent = GetComponent<NavMeshAgent>(); //get this agent

        fAttackRange = AggressiveAIRef.EnemySORef.EnemyProperties.AttackRange;

        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < fAttackRange) //is in range of attack
        {
            AggressiveAIRef.SetState(AggressiveAI.Behaviours.Attack);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack Player");

        agent.SetDestination(gameObject.transform.position); //stop movement

        //run attack anim if not already
        //if ()
        //{

        //}
        
    }


}
