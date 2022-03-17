using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Stock stock; //holds the stock which this item is returned to on being consumed
    public Inventory inventory;
    public new string name;
    public int Health;
    public int Attack;
    public int Mana;
    public int Magic;
    public int Tier;
    public Texture2D sprite;
    public int numInStock;

    public void init (Item itemA, Item itemB)
    {
        Health += itemA.Health + itemB.Health;
        Attack += itemA.Attack + itemB.Attack;
        Mana += itemA.Mana + itemB.Mana;
        Magic += itemA.Magic + itemA.Mana;
        Tier += itemA.Tier + 1;
        name =name + Tier;
    }

    public int[] getStats()
    {
        int[] stats = { Health, Attack, Mana, Magic };
        return stats;
    }

    //checking if two items are equal for tripling
    public override bool Equals(object other)
    {
        return base.Equals(other as Item);
    }
    public bool Equals(Item other)
    {
        if(Object.ReferenceEquals(other, null))
        {
            return false;
        }
        if(Tier == other.Tier)
        {
            if(Health == other.Health && Attack == other.Attack && other.Mana == Mana && other.Magic == Magic)
            {
                return true;
            }
        }
        return false;
    }
    public static bool operator ==(Item lhs, Item rhs)
    {
        if (Object.ReferenceEquals(lhs, null))
        {
            if (Object.ReferenceEquals(rhs, null)) // null == null
            {
                return true;
            }
            return false; // null != not null
        }
        return lhs.Equals(rhs);
    }
    public static bool operator !=(Item lhs, Item rhs)
    {
        return !lhs.Equals(rhs);
    }
}
