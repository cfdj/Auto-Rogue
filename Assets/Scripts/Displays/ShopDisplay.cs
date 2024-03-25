using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Handles Displaying the shop
 *Slot locations now handled by objects within a gridlayout group and panel
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
    public List<Image> slotHolders;
    void Awake()
    {
        if (firstTime)
        {
            numItems = 0;
            shop.display = this;
            currentItems = new List<ItemDisplay>();
            slotLocations = new List<Vector3>();
            foreach (Image s in slotHolders) //Given this functionality is probably going to replicated in 3 places, it seems potentially prime for moving to a class of its own
            {
                slotLocations.Add(s.rectTransform.localPosition);
                s.color = Color.clear;
            }
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
            //currentItems[numItems].returnPos = currentItems[numItems].gameObject.transform.position;
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
