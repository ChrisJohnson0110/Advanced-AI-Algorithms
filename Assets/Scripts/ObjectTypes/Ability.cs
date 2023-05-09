using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability 
{
    public enum type
    {
        Projectile, //launch projectile
        AOE, //area to apply
        Self, //buff to self
        Target, //lock on
        Spot, //does thing at set location
    }
}
