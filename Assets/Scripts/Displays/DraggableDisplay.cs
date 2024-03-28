using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*Used as a base class for items which can be dragged around the UI.
 * This is because of shared functionality between Weapon Displays and Item displays
 * Does not have a default ability to be dropped somewhere, will always return to starting position when dropped
 */
public class DraggableDisplay : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 returnPos; // this is the position the item returns to if it's dropped outside of a drop location
    // Start is called before the first frame update
    void Start()
    {
        returnPos = transform.localPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        returnPos = transform.localPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //blocksRaycasts = false;
        transform.position = Input.mousePosition;
    }

    virtual public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = returnPos;
        Debug.Log(returnPos);
    }
}
