using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "NewWeapon")]
public class WeaponSO : ScriptableObject
{
    //public GameObject WeaponModel;
    public GameObject ProjectileModel;
    public float BaseProjectileDamage;
    public float BaseProjectileSpeed;
    public bool IsRanged;
    public Damage.type DamageType;
}
