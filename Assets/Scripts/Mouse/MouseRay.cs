using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{
    ClickToMove ClickToMoveRef;
    AutoAttack AutoAttackRef;
    Outline OutlineRef; //outline 

    // Start is called before the first frame update
    void Start()
    {
        ClickToMoveRef = GetComponent<ClickToMove>();
        AutoAttackRef = GetComponent<AutoAttack>();
        OutlineRef = GetComponent<Outline>();
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag == "Damageable") //if can attack
            {
                OutlineRef.ApplyOutline(hit.transform.gameObject); //apply outline

                if (Input.GetMouseButtonDown(0)) //if mouse down
                {
                    AutoAttackRef.Attack(hit);
                    ClickToMoveRef.StopMoving();
                }
            }
            else
            {
                OutlineRef.RemoveOutline(); //remove outline
                if (Input.GetMouseButtonDown(0)) //move
                {
                    ClickToMoveRef.MoveToClickPoint(hit);
                }
            }
        }
    }
}
