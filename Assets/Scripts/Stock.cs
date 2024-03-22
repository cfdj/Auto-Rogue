using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//holds a list of all items which can be added to the shop, once they're used they return to the stock
[CreateAssetMenu(fileName = "New Stock", menuName = "Stock")]
public class Stock : ScriptableObject
{
    public List<Item> inStock;
    public bool takeOut(Item taking)
    {
        if (taking.numInStock >0)
        {
            taking.numInStock -= 1;
        }
        return true;
    }
    public void giveBack(ItemDisplay giving)
    {
        if (giving.item != null)
        {
            giving.item.numInStock += 1;
        }
    }
    public List<Item> refresh(int tier, int num)
    {
        List<Item> newItems = new List<Item>();
        List<Item> potential = new List<Item>();
        int totalStock = 0;
        foreach(Item i in inStock)
        {
            if(i.Tier < tier && i.numInStock> 0)
            {
                potential.Add(i);
            }
        }
        foreach(Item i in potential)
        {
            totalStock += i.numInStock;
        }
        if (num >= totalStock)
        {
            foreach(Item i in potential)
            {
                while (i.numInStock > 0)
                {
                    newItems.Add(i);
                    takeOut(i);
                }
            }
            potential.Clear();
        }
        else
        {
            while (newItems.Count < num)
            {
                int choice = Random.Range(0, potential.Count);
                newItems.Add(potential[choice]);
                takeOut(potential[choice]);
                if (potential[choice].numInStock <= 0)
                {
                    potential.RemoveAt(choice);
                }
            }
        }
        return newItems;
    }
}
