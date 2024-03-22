using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Used to create new weapons
 * This is the main goal of the next part of development, allowing players to buy and equip different weapons to characters
 */
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
