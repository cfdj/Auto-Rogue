using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Spell : Attack
{
    public Spell(string n, Sprite i, float aM) : base(n, i, aM)
    {
    }
    //Attacks all enemies
    public override List<TempEnemy> GetTargets(List<TempEnemy> frontLine, List<TempEnemy> backLine)
    {
        List<TempEnemy> targets = new List<TempEnemy>();
        targets.AddRange(frontLine);
        targets.AddRange(backLine);
        return targets;
    }
}
