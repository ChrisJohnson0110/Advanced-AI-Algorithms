using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// quick movement in direction
/// </summary>
public class Dash : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField] float fDashSpeed = 100;
    [SerializeField] float fDashDuration = 0.5f;

    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //attack
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                navAgent.SetDestination(hit.point); // set destination to hit pos

                if (isDashing == false)
                {
                    StartCoroutine(DashSpace());
                }
            }
        }
    }


    IEnumerator DashSpace()
    {
        isDashing = true;

        float fOriginalSpeed = navAgent.speed; //save normal speed
        navAgent.speed = fDashSpeed; //change to dash speed

        float fElapsedTime = 0f;
        //dash
        while (fElapsedTime < fDashDuration)
        {
            navAgent.speed = Mathf.Lerp(fDashSpeed, fOriginalSpeed, fElapsedTime / fDashDuration); 
            fElapsedTime += Time.deltaTime;
            yield return null;
        }
        navAgent.speed = fOriginalSpeed; //reset speed
        isDashing = false; //dash over
    }


}
