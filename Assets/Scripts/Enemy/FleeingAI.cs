using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeingAI : MonoBehaviour
{
    public bool isFleeing; // currently fleeing ?

    LayerMask dangerLayers; // what is a danger

    float DistanceOfDanger = 100f; // distance that if a danger is within will flee
    [SerializeField] float healthThreshold; //health threshhold before trying to flee

    NavMeshAgent nmaNavMesh; // navmesh
    Transform CurrentDanger; // current danger

    Health hHealthRef;
    Enemy eEnemyRef;

    float StartingTime; //time needed before starting to wander
    float Timer;

    private void Start()
    {
        nmaNavMesh = GetComponent<NavMeshAgent>(); // get navmesh
        hHealthRef = GetComponent<Health>(); //get health
        eEnemyRef = GetComponent<Enemy>(); //get enemy
        dangerLayers = LayerMask.GetMask("FriendlyCreature");
        healthThreshold = eEnemyRef.EnemyProperties.FleeingThreshold;
    }

    private void Update()
    {
        if (isFleeing == true)
        {
            Flee();
        }
    }

    public bool CheckForDanger()
    {
        
        Collider[] dangerColliders = Physics.OverlapSphere(transform.position, DistanceOfDanger, dangerLayers); //find dangers
        if (dangerColliders.Length > 0)
        {
            CurrentDanger = dangerColliders[0].transform;
            return true;
        }
        return false;
    }


    private void Flee()
    {
        Vector3 v3FleeDirection = transform.position - CurrentDanger.position; //get dir away from danger
        Vector3 v3Destination = transform.position + v3FleeDirection.normalized * DistanceOfDanger; //position away from danger outside range
        NavMeshPath nmpNavPath = new NavMeshPath();


        if (NavMesh.SamplePosition(v3Destination, out NavMeshHit hit, DistanceOfDanger, NavMesh.AllAreas))
        {
            NavMesh.CalculatePath(transform.position, hit.position, NavMesh.AllAreas, nmpNavPath);
            if (nmpNavPath.status != NavMeshPathStatus.PathInvalid)
            {
                nmaNavMesh.SetPath(nmpNavPath);
            }
        }
    }
}
