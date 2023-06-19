using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Adventure", menuName = "Adventure")]
public class Adventure : ScriptableObject
{
    public List<Encounter> encounters;
    private int progress = 0;

    public AdventureLog log;

    private List<Character> characters;
    public void StartAdventure(List<Character> adventureCharacters)
    {
        characters = adventureCharacters;
        foreach(Character c in characters)
        {
            c.ReadyForAdventure();
        }
        encounters[0].StartEncounter();//Need to rework this flow through
        while(progress < encounters.Count && !CheckLost())
        {
            if (encounters[progress].FinishedEncounter())
            {
                progress += 1;
                if (progress < encounters.Count)
                {
                    log.AddLog("Next encounter");
                    encounters[progress].StartEncounter();
                }
            }
            else
            {
                RunEncounter();
            }
        }
        if (CheckLost())
        {
            progress = 0;
            LoseAdventure();
        }
        else
        {
            progress = 0;
            WinAdventure();
        }
    }

    public void RunEncounter()
    {
        Encounter current = encounters[progress];
        foreach (Character c in characters)
        {
            log.AddLog(c.name + " attacks with a " + c.weapon.name);
            if (!current.FinishedEncounter() &&c.curHealth >0)
            {
                current.Damage(c.weapon, c.curAttack, c.curMana);
                
            }
        }
        foreach(TempEnemy e in current.FrontLine)
        {
            if (e.alive)
            {
                log.AddLog("Enemy " + e.name + " attacks");
                bool doneAttack = false;
                for(int i = 0; i< characters.Count && !doneAttack; i++)
                {
                    if (characters[i].curHealth > 0)
                    {
                        doneAttack = true;
                        characters[i].curHealth -= e.Attack;
                    }
                }
           
            }
        }
        foreach (TempEnemy e in current.BackLine)
        {
            if (e.alive)
            {
                log.AddLog("Enemy " + e.name + " attacks");
                bool doneAttack = false;
                for (int i = 0; i < characters.Count&& !doneAttack; i++)
                {
                    if (characters[i].curHealth > 0)
                    {
                        doneAttack = true;
                        characters[i].curHealth -= e.Attack;
                    }
                }
            }
        }
    }

    private bool CheckLost()
    {
        bool dead = true;
        foreach(Character c in characters)
        {
            if(c.curHealth > 0)
            {
                dead = false;
            }
        }
        return dead;
    }
    public void WinAdventure()
    {
        log.AddLog("Won Adventure!");
    }
    public void LoseAdventure()
    {
        log.AddLog("Lost Adventure!");
    }
}
