using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// create and manage projectiles from player
/// </summary>
public class AutoAttackRanged : MonoBehaviour
{
    //ranged variables
    [SerializeField] int fNumberOfProjectilesToCreate; //number of projects to create
    GameObject a_goAutoAttackProjectile; //object that will be fired
    GameObject[] goProjectilesToLaunch; //store projectiles that will be used
    Player PlayerReference;

    void Start()
    {
        PlayerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        a_goAutoAttackProjectile = PlayerReference.EquippedWeapon.ProjectileModel;
        CreateProjectiles();
    }

    /// <summary>
    /// create as many projectiles as specified and set them all to inactive
    /// </summary>
    private void CreateProjectiles()
    {
        if (goProjectilesToLaunch != null) //check no projectiles currently exist
        {
            foreach (GameObject go in goProjectilesToLaunch) // destroy all the objects
            {
                Destroy(go);
            }
        }
        
        goProjectilesToLaunch = new GameObject[fNumberOfProjectilesToCreate];

        for (int i = 0; i < fNumberOfProjectilesToCreate; i++)
        {
            goProjectilesToLaunch[i] = Instantiate(a_goAutoAttackProjectile, transform);
            //goProjectilesToLaunch[i].layer = LayerMask.GetMask("Attacks");
            goProjectilesToLaunch[i].SetActive(false);
        }
    }


    /// <summary>
    /// set the first found inactive bullet and set it to active
    /// </summary>
    public void AutoAttack(Transform a_tTransform, Vector3 a_TargetPosition, WeaponSO a_EquippedWeapon)
    {
        foreach (GameObject projectileToLaunch in goProjectilesToLaunch)
        {
            if (projectileToLaunch.activeSelf == false)
            {
                projectileToLaunch.transform.position = a_tTransform.position;

                Projectile properties = projectileToLaunch.GetComponent<Projectile>();
                properties.fProjectileSpeed = a_EquippedWeapon.BaseProjectileSpeed;
                properties.fProjectileDamage = a_EquippedWeapon.BaseProjectileDamage;
                properties.DamageType = a_EquippedWeapon.DamageType;
                properties.TargetPosition = a_TargetPosition;

                projectileToLaunch.SetActive(true);

                break;
                //return projectileToLaunch;
            }
        }
        //return null;
    }

}
