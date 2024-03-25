using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/* Displays Items in the UI
 * Drag and Droppable onto Characters, Inventories and Shops
 * If dropped in an invalid location, will snap back
 */
public class ItemDisplay : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public InventoryDisplay inventoryDisplay;
    public RawImage image;
    public Vector3 returnPos; // this is the position the item returns to if it's dropped outside of a drop location
    public Outline outline;

    int[] stats;
    public int tier =0;
    public void OnBeginDrag(PointerEventData eventData)
    {
        returnPos = transform.localPosition;
    }
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
            returnPos = inventoryDisplay.Buy(this);
          
        }
        if (inventoryDisplay.inventory.Check(item)) //if the party has bought the item, check if they're giving it to a character
        {
            foreach(CharacterDisplay c in chars)
            {
                charPanel = c.transform as RectTransform;
                if(RectTransformUtility.RectangleContainsScreenPoint(charPanel, Input.mousePosition))
                {
                    Debug.Log("Gave character item");
                    consume(c.character);
                    c.updateText();
                    inventoryDisplay.inventory.GiveBack(this);
                    
                }
            }
        }
        transform.localPosition = returnPos;
        Debug.Log(returnPos);
        
    }
    private void consume(Character c)
    {
        c.increaseStats(stats);
    }

    void Start()
    {
        returnPos = transform.localPosition;
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
    }
    public void setItem(Item i)
    {
        item = i;
        image.texture = item.sprite;
        stats = item.getStats();
    }
    public void Triple()
    {
        for (int i = 0; i < 4; i++){
            stats[i] = stats[i] * 3;
        }
        increaseTier();
    }
    public void increaseTier()
    {
        tier += 1;
        outline.enabled = true;
    }
}
