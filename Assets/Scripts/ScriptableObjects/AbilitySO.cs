using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ability", menuName = "NewProjectileAbility")]
public class AbilitySO : ScriptableObject
{
    Ability.type AbilityType;

    public float cooldown;
    public float duration;

}
