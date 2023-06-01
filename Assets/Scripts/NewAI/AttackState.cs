using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] State idleState;
    [SerializeField] Health hThisHealth;

    [SerializeField] Senses sensesRef;

    [SerializeField] GameObject hitEffect;

    [SerializeField] float AttackInverval;

    [SerializeField] float fDamage;
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
