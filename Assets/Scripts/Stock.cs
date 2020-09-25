using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//holds a list of all items which can be added to the stock, once they're used they return to the stock
[CreateAssetMenu(fileName = "New Stock", menuName = "Stock")]
public class Stock : ScriptableObject
{
    List<Item> inStock;
    List<Item> current;
    public Item takeOut(Item taking)
    {
        if (inStock.Contains(taking))
        {
            current.Remove(taking);
            inStock.Remove(taking);
        }
        return taking;
    }
    public void giveBack(Item giving)
    {
        inStock.Add(giving);
    }
}
