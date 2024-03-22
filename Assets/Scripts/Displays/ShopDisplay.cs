using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Handles Displaying the shop
 *Next thing for improvement is making slot locations not hard coded but instead determined by Gizmos to help with multi-resolution flexibility
*/
public class ShopDisplay : MonoBehaviour
{
    public Shop shop;
    public Canvas canvas;
    List<Vector3> slotLocations;
    List<ItemDisplay> currentItems;
    int numItems;
    public ItemDisplay itemPrefab;
    public Image shopPanel;
    private bool firstTime = true;

    public Text restockLabel;
    void Awake()
    {
        if (firstTime)
        {
            numItems = 0;
            shop.display = this;
            currentItems = new List<ItemDisplay>();
            slotLocations = new List<Vector3>();
            slotLocations.Add(new Vector3(110, 25, 0));//Changing this
            slotLocations.Add(new Vector3(162, 25, 0));
            slotLocations.Add(new Vector3(110, -29, 0));
            slotLocations.Add(new Vector3(162, -29, 0));
            slotLocations.Add(new Vector3(110, -83, 0));
            slotLocations.Add(new Vector3(162, -83, 0));
            Restock();
            firstTime = false;
        }
        restockLabel.text = "Restock:" + shop.restockCost + "G";
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
    //so restocking for free is different to restocking in play
    public void payRestock()
    {
        if (Wallet.wallet.checkMoney(shop.restockCost)){
            Wallet.wallet.spendMoney(shop.restockCost);
            Restock();
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
        if (Wallet.wallet.checkMoney(item.price))
        {
            Wallet.wallet.spendMoney(item.price);
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
}
