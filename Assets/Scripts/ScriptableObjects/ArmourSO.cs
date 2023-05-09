using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armour", menuName = "NewArmourPiece")]
public class ArmourSO : ScriptableObject
{
    public GameObject ArmourModel;
    public float ArmourResist;
    public float MagicResist;
    public float Health;
    public Equipment.ArmourTypes ArmourType;
}
