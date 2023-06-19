using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Encounter", menuName = "Encounter")]
public class Encounter : ScriptableObject
{
    public List<Enemy> FrontLineIn, BackLineIn;
    public List<TempEnemy> FrontLine = new List<TempEnemy>();
    public List<TempEnemy> BackLine = new List<TempEnemy>();

    public EncounterDisplay display;
    public void StartEncounter()
    {
        FrontLine.Clear();
        BackLine.Clear();
        foreach(Enemy E in FrontLineIn)
        {
            FrontLine.Add(new TempEnemy(E));
        }
        foreach (Enemy E in BackLineIn)
        {
           BackLine.Add(new TempEnemy(E));
        }
    }
    public void Damage(Attack weapon, int characterAttack, int characterMana)
    {
        List<TempEnemy> targets = new List<TempEnemy>();
        targets = weapon.GetTargets(FrontLine, BackLine);
        foreach(TempEnemy e in targets)
        {
            e.Damage(characterAttack * weapon.attackModifier);
            display.UpdateDisplay();
            if (!e.alive)
            {
                
                if (FrontLine.Contains(e))
                {
                    FrontLine.Remove(e);
                }
                else
                {
                    BackLine.Remove(e);
                }
            }
        }
    }

    public bool FinishedEncounter()
    {
        display.UpdateDisplay();
        if((FrontLine.Count == 0)&&(BackLine.Count ==0))
        {
            return true;
        }
        return false;
    }
}
