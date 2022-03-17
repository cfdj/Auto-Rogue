﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int curHealth;
    private int curAttack;
    private int curMana;
    private int curMagic;

    public void increaseStats (int[] stats) // health, attack, mana, magic
    {
        totalHealth += stats[0];
        totalAttack += stats[1];
        totalMana += stats[2];
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
}