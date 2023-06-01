using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handle attack behaviour
/// </summary>
public class AttackState : State
{
    [SerializeField] State idleState; //idle state ref

    [SerializeField] Senses sensesRef; //this characters senses

    [SerializeField] GameObject hitEffect; //effect of dealing dmg
    [SerializeField] float AttackInverval; //time between attacks
    [SerializeField] float fDamage; //dmg attacks will deal

    float fTimer = 0;

    public override State RunCurrentState()
    {
        if (fTimer >= 0)
        {
            fTimer -= Time.deltaTime; //hit cooldown
        }
        else
        {
            sensesRef.target.GetComponent<Health>().TakeDamage(fDamage); //deal damage
            Instantiate(hitEffect, sensesRef.target.transform.position, transform.rotation); //create hit effect
            fTimer = AttackInverval; //reset hit timer
        }

        return idleState;
    }
}
