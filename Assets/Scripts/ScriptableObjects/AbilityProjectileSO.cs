using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ability", menuName = "NewProjectileAbility")]
public class AbilityProjectileSO : AbilitySO
{
    //ememy prefab
    public GameObject AbilityModel;
    public GameObject AbilityTrail;
    public GameObject AbilityEffect;







    //properties
    public float MovementSpeed;
    public float Mana; //resource needed to use abilities
    public float Health;

    //Behaviours

    //agressive
    public float AgroRange; //range player needed to gain agro
    //public float AgroDistance; //distance before losing agro

    //wander
    public float WanderRangeStart; //distance can wander from start
    public float WanderRangeSelf; //distance the wander can be from self

    //fleeing
    public float FleeingThreshold; //if below this hp flee

    //resistences
    public float Armour;
    public float MagicResistence;
    public Damage.type ResitanceType;

    //attacks
    public bool IsRanged;
    public float AttackRange;
    public float AttackDamage;
    public float AttackSpeed;
    public Damage.type DamageType;

    //behaviour
    EnemyBehaviour.Type BehaviourType;

    //abilities



}
