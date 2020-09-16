using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;
    public int baseHealth;
    public int baseAttack;
    public int baseMana;
    public int baseMagic;
}
