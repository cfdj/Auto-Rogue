using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//holds a list of all items which can be added to the stock, once they're used they return to the stock
[CreateAssetMenu(fileName = "New Stock", menuName = "Stock")]
public class Stock : ScriptableObject
{
    public List<Item> inStock;
    public Item takeOut(Item taking)
    {
        if (inStock.Contains(taking))
        {
            inStock.Remove(taking);
        }
        return taking;
    }
    public void giveBack(Item giving)
    {
        if(giving.display != null)
        {
            Destroy(giving.display.gameObject);
        }
        inStock.Add(giving);
    }
    public List<Item> refresh(int tier, int num)
    {
        List<Item> newItems = new List<Item>();
        List<Item> potential = new List<Item>();
        foreach(Item i in inStock)
        {
            if(i.Tier < tier)
            {
                potential.Add(i);
            }
        }
        if (num >= potential.Count)
        {
            foreach(Item i in potential)
            {
                newItems.Add(i);
                takeOut(i);
                
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
                potential.RemoveAt(choice);
            }
        }
        return newItems;
    }
}
