using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;
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
    private int curHealth;
    private int curAttack;
    private int curMana;
    private int curMagic;

    public void increaseStats (int[] stats) // health, attack, mana, magic
    {
        totalHealth += stats[0];
        totalAttack += stats[0];
        totalMana += stats[0];
        totalMagic += stats[0];
        totalGains += 1;
        curHealth = totalHealth;
        curAttack = totalAttack;
        curMana = totalMana;
        curMagic = totalMagic;
    }

}
