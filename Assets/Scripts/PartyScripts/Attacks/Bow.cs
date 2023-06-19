using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bow : Attack
{
    public Bow(string n, Sprite i, float aM) : base (n,i,aM)
    {
    }
    //Starts by attacking the backLine
    public override List<TempEnemy> GetTargets(List<TempEnemy> frontLine, List<TempEnemy> backLine)
    {
        List<TempEnemy> targets = new List<TempEnemy>();
        if (backLine.Count > 0)
        {
            targets.Add(backLine[0]);
        }
        else
        {
            targets.Add(frontLine[0]);
        }
        return targets;
    }
}
