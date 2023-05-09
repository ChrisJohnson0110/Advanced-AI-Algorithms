using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //projectile properties
    public float fProjectileSpeed = 1f; //speed the projectile will travel
    public float fProjectileDamage = 1f; //amount of damage the projectile will deal
    public float fProjectileMaxDuration = 10f; //duration of a projectile before destroying
    public Damage.type DamageType; //type of damage the projectile applies
    public int PierceAmount; //number of objects/enemies that the projectile can pierce
    public Vector3 TargetPosition;
    Vector3 direction;


    /// <summary>
    /// hide the object x amount of time after being set active
    /// </summary>
    private void OnEnable()
    {
        direction = TargetPosition - transform.position;
        Invoke("SetInactive", fProjectileMaxDuration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * fProjectileSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    /// <summary>
    /// if colliding with object try to damage then set inactive
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other)
    {
        //process damage
        if (other.transform.tag == "Damageable")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(fProjectileDamage);
            if (other.gameObject.activeSelf == true) //if obj not been destroyed
            {
                other.gameObject.GetComponent<Status>().Apply(DamageType); //aplly dmg type effect
            }
            SetInactive();
        }

        
    }

    /// <summary>
    /// set the projectile to inactive
    /// </summary>
    private void SetInactive()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

}
