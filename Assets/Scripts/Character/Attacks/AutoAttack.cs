using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// cast auto attacks
/// </summary>
public class AutoAttack : MonoBehaviour
{
    //auto attack variables
    float fAutoAttackSpeed; //speed of the fired projectlile

    //script references
    AutoAttackRanged AutoAttackRangedReference;

    private void Start()
    {
        AutoAttackRangedReference = GameObject.FindGameObjectWithTag("AttacksHolder").GetComponent<AutoAttackRanged>();
    }

    public void Attack(RaycastHit hit)
    {
        //////////////////Auto attack//////////////////
        AutoAttackRanged(this.gameObject.transform, hit.point);
    }


    /// <summary>
    /// use ranged attack
    /// </summary>
    private void AutoAttackRanged(Transform a_ProjectileLaunchPosition, Vector3 a_TargetPosition)
    {   
        AutoAttackRangedReference.AutoAttack(a_ProjectileLaunchPosition, a_TargetPosition);
    }
}
