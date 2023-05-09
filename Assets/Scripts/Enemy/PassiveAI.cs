using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassiveAI : MonoBehaviour
{
    public bool isWandering; //currently in wandering state

    float fWanderRadiusStart; //distance can wander from start
    float fWanderDistanceSelf; //distance the wander can be from self

    Vector3 v3StartingPosition; //starting pos
    NavMeshAgent nmaNavMesh; //nav mesh
    Enemy EnemySORef; //nav mesh

    private void Start()
    {
        v3StartingPosition = transform.position; //store the starting pos
        nmaNavMesh = GetComponent<NavMeshAgent>(); //get nav mesh agent
        EnemySORef = GetComponent<Enemy>();

        fWanderRadiusStart = EnemySORef.EnemyProperties.WanderRangeStart;
        fWanderDistanceSelf = EnemySORef.EnemyProperties.WanderRangeSelf;

    }

    private void Update()
    {
        if (isWandering == true) //currentlywandering
        {
            if (nmaNavMesh.hasPath == false) //if no path exists
            {
                Vector3 randomDirection = Random.insideUnitSphere * 1f; //get random dir
                randomDirection.y = 0f; // 0 level
                Vector3 wanderTarget = v3StartingPosition + randomDirection.normalized * fWanderRadiusStart + transform.forward * fWanderDistanceSelf; //get pos within range
                NavMeshHit hit;
                if (NavMesh.SamplePosition(wanderTarget, out hit, fWanderRadiusStart, NavMesh.AllAreas)) //find new pos on navmesh
                {
                    nmaNavMesh.SetDestination(hit.position); //set navmesh destination
                }
            }
        }
    }
}