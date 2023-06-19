using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        inventory.Add(item);
        shopDisplay.Buy(item.item);
        //item.transform.SetParent(this.transform);
        Vector3 pos = slotLocations[inventory.numItems()-1];
        return pos;
    }
    // Start is called before the first frame update
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
