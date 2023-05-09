using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armour", menuName = "NewArmourPiece")]
public class JewellerySO : ScriptableObject
{
    public GameObject JewlleryModel;
    public Equipment.JewelleryTypes JewelleryType;
}