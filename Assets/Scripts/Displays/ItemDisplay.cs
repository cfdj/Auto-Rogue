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
        List<CharacterDisplay> chars = new List<CharacterDisplay>( FindObjectsOfType<CharacterDisplay>());
        RectTransform charPanel;
        if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Drop item");
            returnPos =inventoryDisplay.Buy(item);
        }
        if (inventoryDisplay.inventory.Check(item)) //if the party has bought the item, check if they're giving it to a character
        {
            foreach(CharacterDisplay c in chars)
            {
                charPanel = c.transform as RectTransform;
                if(RectTransformUtility.RectangleContainsScreenPoint(charPanel, Input.mousePosition))
                {
                    Debug.Log("Gave character item");
                    item.consume(c.character);
                }
            }
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
