using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float fProjectileSpeed;
    public float fProjectileDamage;
    public Vector3 TargetPosition;

    Vector3 v3BulletDirection;


    private void OnEnable()
    {
        v3BulletDirection = TargetPosition - transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(v3BulletDirection * fProjectileSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);


        float distance = Vector3.Distance(transform.position, new Vector3(0,0,0));

        if (distance >= 50)
        {
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// if collides with damageable object damage it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damageable")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(fProjectileDamage);
            gameObject.SetActive(false);
        }
    }
}
