using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
public class Shop : ScriptableObject { 
    public new string name;
    public int level;
    public int Tier;
    public Stock stock;
    public List<Item> current; //ideally this would be a set, however I would need to override items hashcode
    public ShopDisplay display;

    //refereshes the current stock of items, based on whats in the stock
    public void reStock()
    {
        current = stock.refresh(Tier, level);
    }
    public void Empty()
    {
        foreach(Item i in current)
        {
            stock.giveBack(i);
        }
        current.Clear();
    }
    public void Buy(Item item)
    {
        if (current.Contains(item))
        {
            display.Buy(item);
            current.Remove(item);
        }
    }
}
