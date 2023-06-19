using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopDisplay : MonoBehaviour
{
    public Shop shop;
    public Canvas canvas;
    List<Vector3> slotLocations;
    List<ItemDisplay> currentItems;
    int numItems;
    public ItemDisplay itemPrefab;
    public Image shopPanel;
    // Start is called before the first frame update
    private bool firstTime = true;
    void Awake()
    {
        if (firstTime)
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
            firstTime = false;
        }
    }
    public void Restock()
    {
        Empty();
        shop.reStock();
        foreach(Item i in shop.currentItems){
            currentItems.Add(Instantiate(itemPrefab, slotLocations[numItems], Quaternion.identity));
            currentItems[numItems].gameObject.transform.SetParent(shopPanel.transform, false);
            currentItems[numItems].returnPos = slotLocations[numItems];
            currentItems[numItems].setItem(i);
            numItems += 1;
        }
    }
    public void Empty()
    {
        foreach (ItemDisplay i in currentItems)
        {
            if (i != null)
            {
                Debug.Log("Giving back: " + i.name);
                shop.stock.giveBack(i);
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
