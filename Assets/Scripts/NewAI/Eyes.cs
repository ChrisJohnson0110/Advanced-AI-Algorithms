using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    [SerializeField] Transform goCharacter;

    [SerializeField] Senses SensesRef;

    [SerializeField] string sTagToCheck;

    [SerializeField] float fVisionAngle;

    [SerializeField] GameObject goDetectionBar; //detection bar indicator
    [SerializeField] Vector3 v3DetectionBarScale; //scale of bar
    float fDetectionProgress = 0; //progress detecting player
    [SerializeField] float fDetectionTime = 1f; //how long to detect

    [SerializeField] float fLoseAgroDuration;
    bool bIsTimerActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == sTagToCheck) //if collision with target to check tag
        {
            //raycast to target
            Ray ray = new Ray(transform.position, other.transform.position - transform.position);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) //has line of sight
            {
                if (hit.transform.tag == sTagToCheck)
                {
                    Vector3 direction = other.transform.position - goCharacter.transform.position; //get direction to spotted object
                    float angle = Vector3.Angle(direction, transform.forward); //angle between forward dir and player dir
                    if (angle < fVisionAngle / 2f) //is the player within the vision angle
                    {
                        fDetectionProgress += Time.deltaTime / fDetectionTime; //increase detection
                        fDetectionProgress = Mathf.Clamp(fDetectionProgress, 0f, 1f); //clamp detection progress
                        if (fDetectionProgress >= 0.999f) // if player fully detected
                        {
                            SensesRef.bCanSee = true;
                            SensesRef.target = other.gameObject;
                        }
                        else
                        {
                            SensesRef.bCanSee = false;
                        }

                        transform.LookAt(GameObject.FindGameObjectWithTag("Player").gameObject.transform); //lock on to player
                    }
                    else
                    {
                        StartCoroutine(AgroTimer());
                    }
                }
                else
                {
                    StartCoroutine(AgroTimer());
                }
            }
            else
            {
                StartCoroutine(AgroTimer());
            }
        }
        goDetectionBar.transform.localScale = new Vector3(v3DetectionBarScale.x * fDetectionProgress, v3DetectionBarScale.y, v3DetectionBarScale.z); //scale pysical detection bar
    }


    private IEnumerator AgroTimer()
    {
        if (bIsTimerActive == true)
        {
            yield break;
        }
        bIsTimerActive = true;

        yield return new WaitForSeconds(fLoseAgroDuration);
        SensesRef.bCanSee = false;
        fDetectionProgress = 0;
    }
}
