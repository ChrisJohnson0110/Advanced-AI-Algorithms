using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] State idleState;
    [SerializeField] State fleeState;
    [SerializeField] Health hThisHealth;

    [SerializeField] Senses sensesRef;

    [SerializeField] float AttackInverval;

    [SerializeField] float fDamage;
    float timer;

    public override State RunCurrentState()
    {
        //play attack effect
        //damage player
        Debug.Log("Attack");
        if (timer <= 0)
        {
            sensesRef.target.GetComponent<Health>().TakeDamage(fDamage);
            Debug.Log(fDamage.ToString());
            timer = AttackInverval;
        }
        else
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
        }

        if (hThisHealth.health <= (hThisHealth.health / 10)) //hp drop below 10%
        {
            return fleeState;
        }

        return idleState;
    }
}
