﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Base class for attacks
 * Defines Name, Icon, and Modifier
 * It also defines the default targeting behaviour of targeting the frontline first, backline if no front line is available
*/
[System.Serializable]
public class Attack
{
    public string name;
    public Sprite icon;
    public float attackModifier;
    public Attack(string n,Sprite i, float aM)
    {
        name = n;
        icon = i;
        attackModifier = aM;
    }
    public virtual List<TempEnemy> GetTargets(List<TempEnemy> frontLine, List<TempEnemy> backLine)
    {
        List<TempEnemy> targets = new List<TempEnemy>();
        if (frontLine.Count > 0)
        {
            targets.Add(frontLine[0]);
        }
        else
        {
            targets.Add(backLine[0]);
        }
        return targets;
    }
}
