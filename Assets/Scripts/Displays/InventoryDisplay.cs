using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    private List<Vector3> slotLocations;

    public Vector3 Buy(Item item)
    {
        Vector3 pos = transform.position;
        inventory.Add(item);
        return pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        slotLocations = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
