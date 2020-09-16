using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public int Health;
    public int Mana;
    public int Magic;
    public int Attack;
    public int Tier;
    public Sprite sprite;
}
