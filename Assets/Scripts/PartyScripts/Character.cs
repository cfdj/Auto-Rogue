using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Character objects hold the stats of each adventure, which are then contained in partys
 * They have base stats for setting inital values, and then track being leveled up by items
 * They also track which Archetype and weapon they have
 * Current (cur) values are used for temporary storage during adventures
*/

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public ArchetypeManager manager;
    public new string name;
    public Archetype archetype;
    //these store a characters initial stat values without any upgrades
    public int baseHealth;
    public int baseAttack;
    public int baseMana;
    public int baseMagic;
    //these store the current maximum stats of a character
    public int totalHealth;
    public int totalAttack;
    public int totalMana;
    public int totalMagic;
    //the number of times this character has gained stats, it reduces future stat gains in a diminishing returns way. currently inactive
    public int totalGains;
    //these store the amount of each stat a character currently has for use in combat
    public int curHealth, curAttack, curMana, curMagic;
    public Attack weapon;
    public void increaseStats (int[] stats) // health, mana,attack, magic
    {
        totalHealth += stats[0];
        totalMana += stats[1];
        totalAttack += stats[2];
        totalMagic += stats[3];
        totalGains += 1;
        curHealth = totalHealth;
        curAttack = totalAttack;
        curMana = totalMana;
        curMagic = totalMagic;
        if (!archetype.fitsRequirements(this) || !archetype.maxRequirement)
        {
            //Debug.Log("Changing archetype");
            manager.GetArchetype(this).setArchetype(this);
        }
    }
    public int[] getStats()
    {
        int[] stats = { totalHealth, totalMana, totalAttack, totalMagic };
        return stats;
    }
    public void ReadyForAdventure()
    {
        curHealth = totalHealth;
        curAttack = totalAttack;
        curMana = totalMana;
        curMagic = totalMagic;
    }
    //Added to support having no weapon equipped
    public Attack getWeapon()
    {
        if(weapon == null)
        {
            return new Attack("Fists", null, 0.5f);
        }
        return weapon;
    }
}
