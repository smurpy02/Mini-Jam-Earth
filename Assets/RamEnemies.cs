using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemies : DoDamage
{
    public override void Damage()
    {
        BuildStructures.resources = (int)Mathf.Clamp(BuildStructures.resources-2, 0, Mathf.Infinity);
    }
}
