using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponGenerator", menuName = "WeaponGenerator")]
public class WeaponGenerator : ScriptableObject
{
    public List<Attack> attacks;
    public List<Bow> bows;
    public List<Spell> spells;
    public enum weapontype
    {
        attack,bow,spell
    }
}
