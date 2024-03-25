using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Displays the contents of an inventory 
 *Shop locations now work using Images which can be moved in the editor
*/
public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public Stock stock;
    public ShopDisplay shopDisplay;
    private List<Vector3> slotLocations;
    public Image inventoryPanel;
    public ItemDisplay itemPrefab;
    public Canvas canvas;


    public List<Image> slotHolders;
    public Vector3 Buy(ItemDisplay item)
    {
        if (Wallet.wallet.checkMoney(item.item.price)) { 
            inventory.Add(item);
            shopDisplay.Buy(item.item);
            item.transform.SetParent(inventoryPanel.transform);
            Vector3 pos = slotLocations[inventory.numItems() - 1];
            return pos;
        }
        return item.returnPos;
    }

    void Start()
    {
        inventory.display = this;
        slotLocations = new List<Vector3>();
        foreach(Image s in slotHolders)
        {
            slotLocations.Add(s.transform.position);
            s.color = Color.clear;
        }
        inventory.Empty();
    }

}
