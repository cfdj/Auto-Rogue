using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this holds a party's current items
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public Stock stock;
    private List<Item> items;
    public InventoryDisplay display;
    public bool Check(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }
    public int numItems()
    {
        return items.Count;
    }
    public void Add(Item item)
    {

        if (TripleCheck(item))
        {
            items.Add(Triple(item));
        }
        else
        {
            items.Add(item); //adds after checking if it triples
            item.inventory = this;
        }
    }
    public void Remove(Item item)
    { 
        items.Remove(item);
    }
    public void Empty()
    {
        foreach(Item i in items)
        {
            stock.giveBack(i);
        }
        items.Clear();
    }
    public void GiveBack(Item item)
    {
        Remove(item);
        stock.giveBack(item);
    }
    private Item Triple(Item item)
    {
        Item triple;
        List<Item> same = new List<Item>();
        foreach(Item i in items)
        {
            if (i == item)
            {
                same.Add(i);
            }
        }
        triple = CreateInstance<Item>();
        triple.init(same[0], same[1], item);
        GiveBack(same[0]);
        GiveBack(same[1]);
        GiveBack(item);
        return triple;
    }
    private bool TripleCheck(Item item) //checks if 2 others of the same item exist in the inventory
    {
        List<Item> same = new List<Item>();
        foreach (Item i in items)
        {
            if (i == item)
            {
                same.Add(i);
            }
        }
        if (same.Count >= 2)
        {
            return true;
        }
        return false;
    }
}
