using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDisplay : MonoBehaviour
{
    public Shop shop;
    public Canvas canvas;
    List<Vector3> slotLocations;
    List<ItemDisplay> currentItems;
    int numItems;
    public ItemDisplay itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        numItems = 0;
        shop.display = this;
        currentItems = new List<ItemDisplay>();
        slotLocations = new List<Vector3>();
        slotLocations.Add(new Vector3(110, 0, 0));
        slotLocations.Add(new Vector3(162, 0, 0));
        slotLocations.Add(new Vector3(110, -54, 0));
        slotLocations.Add(new Vector3(162, -54, 0));
        slotLocations.Add(new Vector3(110, -108, 0));
        slotLocations.Add(new Vector3(162, -108, 0));
        Restock();
    }
    public void Restock()
    {
        Empty();
        shop.reStock();
        foreach(Item i in shop.current){
            currentItems.Add(Instantiate(itemPrefab, slotLocations[numItems], Quaternion.identity));
            currentItems[numItems].gameObject.transform.SetParent(canvas.transform, false);
            currentItems[numItems].setItem(i);
            numItems += 1;
        }
    }
    public void Empty()
    {
        shop.Empty();
        
        if (currentItems != null)
        {
            foreach (ItemDisplay i in currentItems)
            {
                Destroy(i.gameObject);
            }
        }
        currentItems.Clear();
        numItems = 0;
    }
    public void Buy(Item item)
    {
        ItemDisplay buying = null;
        foreach (ItemDisplay i in currentItems)
        {
            if (i.item == item)
            {
                buying = i;
            }
        }
        if (buying != null)
        {
            currentItems.Remove(buying);
        }
    }
}
