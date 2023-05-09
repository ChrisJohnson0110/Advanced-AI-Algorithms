using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAI : MonoBehaviour
{

    AggressiveAI AggressiveAIRef;
    GameObject goProjectileToDodge;


    float fDodgeRange; //range that if a projectile enters will attempt to dodge
    float fDodgeCooldown; //range that if a projectile enters will attempt to dodge



    // Start is called before the first frame update
    void Start()
    {
        AggressiveAIRef = GetComponent<AggressiveAI>();

        fDodgeRange = AggressiveAIRef.EnemySORef.EnemyProperties.DodgeRange;
        fDodgeCooldown = AggressiveAIRef.EnemySORef.EnemyProperties.DodgeCooldown;
    }



    public void Dodge()
    {
        //do dodge


    }


    public void CheckForBeingAttacked()
    {
        Collider[] Attacks = Physics.OverlapSphere(transform.position, 100f, LayerMask.GetMask("Attacks")); //find dangers
        if (Attacks.Length > 0)
        {
            goProjectileToDodge = Attacks[0].gameObject; //get the nearest attack to this object
            AggressiveAIRef.SetState(AggressiveAI.Behaviours.Dodge); //set the state to dodge this object
        }
    }

}
