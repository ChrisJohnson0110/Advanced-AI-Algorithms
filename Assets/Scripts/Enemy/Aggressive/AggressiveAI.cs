using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveAI : MonoBehaviour
{
    //public
    public Enemy EnemySORef; //
    public enum Behaviours
    {
        Chase,
        Attack,
        Dodge,
        Ability
    }
    public Behaviours currentBehaviour;

    //private
    DodgeAI DodgeAIRef;
    AttackAI AttackAIRef;
    ChaseAI ChaseAIRef;


    private void Start()
    {
        //EnemySORef = GetComponent<Enemy>();
        DodgeAIRef = GetComponent<DodgeAI>();
        AttackAIRef = GetComponent<AttackAI>();
        ChaseAIRef = GetComponent<ChaseAI>();
    }


    public void BehaviourSwitch()
    {
        DodgeAIRef.CheckForBeingAttacked(); //check if need to dodge
        //moved here because its only going to check when within aggressive state

        switch (currentBehaviour)
        {
            case Behaviours.Chase:

                ChaseAIRef.Chase();

                break;

            case Behaviours.Attack:

                AttackAIRef.Attack();

                break;

            case Behaviours.Dodge:

                DodgeAIRef.Dodge();

                break;

            case Behaviours.Ability:

                //props remove

                break;

            default:

                Debug.LogError("Unknown behaviour: " + currentBehaviour);

                break;
        }
    }

    /// <summary>
    /// switch the current state within the aggessive state
    /// </summary>
    /// <param new behaviour to switch to="a_bNewBehaviour"></param>
    public void SetState(Behaviours a_bNewBehaviour)
    {
        if (currentBehaviour != a_bNewBehaviour)
        {
            currentBehaviour = a_bNewBehaviour;
            EnemySORef.SetState(Enemy.Behaviours.Aggressive);

            //need to make sure not mid dodge/attack when switching?





        }
    }

    public void DamageTaken()
    {
        //agro to nearest however expand agro range to 2x
    }

}
