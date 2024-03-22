using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Tracks items that can be bought from the shop, as well as the shop's tier
 * Tier and Level are used when getting items from a stock, more items if its higher level and higher tier items based on shop tier
 */
[CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
public class Shop : ScriptableObject { 
    public new string name;
    public int level;
    public int Tier;
    public Stock stock;
    public List<Item> currentItems;
    public ShopDisplay display;
    public int restockCost;
    //refereshes the current stock of items, based on whats in the stock
    public void reStock()
    {
        currentItems =  stock.refresh(Tier, level);
    }
    /*
    public void Empty()
    {
        foreach(ItemDisplay i in current)
        {
            if (i != null)
            {
                Debug.Log("Giving back: " + i.name);
                stock.giveBack(i);
                Destroy(i.gameObject);
            }
        }
        current.Clear();
    }
    
    public void Buy(ItemDisplay item)
    {
        if (current.Contains(item))
        {
            display.Buy(item.item);
            current.Remove(item);
            currentItems.Remove(item.item);
        }
    }
    public List<ItemDisplay> getCurrent()
    {
        return current;
    }
    */
}
