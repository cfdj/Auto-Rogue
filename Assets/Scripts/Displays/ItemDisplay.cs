using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDisplay : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Item item;
    public InventoryDisplay inventoryDisplay;
    public Vector3 returnPos; // this is the position the item returns to if it's dropped outside of a drop location
    public void OnDrag(PointerEventData eventData)
    {
        //blocksRaycasts = false;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //CanvasGroup.blocksRaycasts = true;
        RectTransform invPanel = inventoryDisplay.transform as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Drop item");
            returnPos =inventoryDisplay.Buy(item);
        }
        
        transform.position = returnPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        returnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
