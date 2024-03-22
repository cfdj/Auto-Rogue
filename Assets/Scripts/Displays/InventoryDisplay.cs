using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Displays the contents of an inventory 
 * As with  the shop, slot locations are currently hardcoded but should be updated to Gizmos
*/
public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public Stock stock;
    public ShopDisplay shopDisplay;
    private List<Vector3> slotLocations;
    public ItemDisplay itemPrefab;
    public Canvas canvas;
    public Vector3 Buy(ItemDisplay item)
    {
        if (Wallet.wallet.checkMoney(item.item.price)) { 
            inventory.Add(item);
            shopDisplay.Buy(item.item);
            //item.transform.SetParent(this.transform);
            Vector3 pos = slotLocations[inventory.numItems() - 1];
            return pos;
        }
        return item.returnPos;
    }

    void Start()
    {
        inventory.display = this;
        slotLocations = new List<Vector3>();
        slotLocations.Add(new Vector3(-68,45,0));
        slotLocations.Add(new Vector3(0, 45, 0));
        slotLocations.Add(new Vector3(-68, -5, 0));
        slotLocations.Add(new Vector3(0, -5, 0));
        slotLocations.Add(new Vector3(-68, -55, 0));
        slotLocations.Add(new Vector3(0, -55, 0));
        slotLocations.Add(new Vector3(-68, -105, 0));
        slotLocations.Add(new Vector3(0, -105, 0));
        inventory.Empty();
    }

}
