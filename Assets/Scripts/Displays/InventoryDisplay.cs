using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDisplay : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    private List<Vector3> slotLocations;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Called");
        RectTransform invPanel = transform as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Drop item");
        }
        Debug.Log("not in rectangle");
    }
    public Vector3 Buy(Item item)
    {
        Vector3 pos = transform.position;

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
