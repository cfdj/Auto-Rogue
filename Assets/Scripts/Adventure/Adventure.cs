using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Adventures store encounters and handle combat between the party and the encounters, as well as rewards
 * Displayed by AdventureDisplays
 */
[CreateAssetMenu(fileName = "New Adventure", menuName = "Adventure")]
public class Adventure : ScriptableObject
{
    public List<Encounter> encounters;
    private int reward;
    private int progress = 0;

    public AdventureLog log;

    private List<Character> characters;
    public void StartAdventure(List<Character> adventureCharacters)
    {
        calculateReward();
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
    public int calculateReward()
    {
        reward = 0;
        foreach(Encounter e in encounters)
        {
            foreach(Enemy x in e.FrontLineIn)
            {
                reward += x.reward;
            }
            foreach (Enemy x in e.BackLineIn)
            {
                reward += x.reward;
            }
        }
        return reward;
    }
    public void RunEncounter()
    {
        Encounter current = encounters[progress];
        foreach (Character c in characters)
        {
            Attack currentWeapon = c.getWeapon();
            log.AddLog(c.name + " attacks with a " + currentWeapon.name);
            if (!current.FinishedEncounter() &&c.curHealth >0)
            {
                current.Damage(currentWeapon, c.curAttack, c.curMana);
                
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
        log.AddLog("Won Adventure! "+ reward + "G");
        Wallet.wallet.giveMoney(reward);
        AdventureDisplay.onAdventure = false;
    }
    public void LoseAdventure()
    {
        log.AddLog("Lost Adventure!" + reward/2 + "G");
        Wallet.wallet.giveMoney(reward/2);
        AdventureDisplay.onAdventure = false;
    }
}
