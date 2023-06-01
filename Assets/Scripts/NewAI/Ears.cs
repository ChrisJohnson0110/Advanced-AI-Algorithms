using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ears : MonoBehaviour
{
    [SerializeField] Transform goCharacter;

    [SerializeField] Senses SensesRef;

    [SerializeField] float fHearingDistance;
    [SerializeField] string sTagToCheck;

    /// <summary>
    /// if within the range of ear collision check
    /// check if player is making noise ??
    /// check if the player is within range
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == sTagToCheck) //if collision with target to check tag
        {
            NavMeshPath path = new NavMeshPath();
            if (NavMesh.CalculatePath(goCharacter.position, other.transform.position, NavMesh.AllAreas, path)) //get path
            {
                if (CalculatePathDistance(path) <= fHearingDistance) //if path is shorter than hearing distance
                {
                    //set can hear
                    SensesRef.bCanHear = true;
                    SensesRef.target = other.gameObject;
                }
                else
                {
                    //set cannot hear
                    SensesRef.bCanHear = false;
                }
            }
        }
    }


    /// <summary>
    /// calculate the distance of the navmesh path
    /// </summary>
    /// <param pathToCheck="path"></param>
    /// <returns>the distance of the given path</returns>
    private float CalculatePathDistance(NavMeshPath a_NavMeshPath)
    {
        float distance = 0f;
        if (a_NavMeshPath.corners.Length < 2) //if the path doesnt have any corners
        {
            return distance; //return path distance
        }

        for (int i = 0; i < a_NavMeshPath.corners.Length - 1; i++) //for each corner in the path
        {
            distance += Vector3.Distance(a_NavMeshPath.corners[i], a_NavMeshPath.corners[i + 1]); //increase the distance by the segment length
        }

        return distance; //return path distance
    }
}
