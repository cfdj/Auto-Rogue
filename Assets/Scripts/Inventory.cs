using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this holds a party's current items
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public Stock stock;
    private List<ItemDisplay> currentItems;
    public InventoryDisplay display;
    public bool Check(Item item)
    {
        foreach (ItemDisplay i in currentItems)
        {
            if (i.item == item)
            {
                return true;
            }
        }
        return false;
    }
    public int numItems()
    {
        return currentItems.Count;
    }
    public void Add(ItemDisplay newItem)
    {

        if (TripleCheck(newItem))
        {
            Debug.Log("Tripling");
            Triple(newItem);
            currentItems.Add(newItem);

        }
        else
        {
            currentItems.Add(newItem); //adds after checking if it triples
        }
    }
    public void Remove(ItemDisplay item)
    { 
        currentItems.Remove(item);
        Destroy(item.gameObject);
    }
    public void Empty()
    {
        foreach(ItemDisplay i in currentItems)
        {
            if (i != null)
            {
                stock.giveBack(i);
            }
        }
        currentItems.Clear();
    }
    public void GiveBack(ItemDisplay item)
    {
        Remove(item);
        stock.giveBack(item);
    }
    private ItemDisplay Triple(ItemDisplay item)
    {
        List<ItemDisplay> same = new List<ItemDisplay>();
        foreach(ItemDisplay i in currentItems)
        {
            if (i.item == item.item &&i.tier == item.tier)
            {
                same.Add(i);
            }
        }
        item.Triple();
        GiveBack(same[0]);
        GiveBack(same[1]);     
        return item;
    }
    private bool TripleCheck(ItemDisplay item) //checks if 2 others of the same item exist in the inventory
    {
        List<ItemDisplay> same = new List<ItemDisplay>();
        foreach (ItemDisplay i in currentItems)
        {
            if (i.item == item.item && i.tier == item.tier)
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
