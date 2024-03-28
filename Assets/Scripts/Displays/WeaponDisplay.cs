using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*Used to display weapons for dragging around the UI, placing to equip to characters and swapping between characters
 * This inherits from Draggable Display, and overrides its functionality so it can be placed in the inventory and equipped to characters
 */
public class WeaponDisplay : DraggableDisplay
{
    public Attack weapon;
    public Image image;
    private WeaponRack weaponRack;
    private CharacterDisplay equippedTo;
    void Start()
    {
        returnPos = transform.localPosition;
        weaponRack = FindObjectOfType<WeaponRack>();
    }
    override public void OnEndDrag(PointerEventData eventData)
    {
        List<CharacterDisplay> chars = new List<CharacterDisplay>(FindObjectsOfType<CharacterDisplay>());
        RectTransform charPanel;

        foreach (CharacterDisplay c in chars)
        {
            charPanel = c.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(charPanel, Input.mousePosition))
            {
                Debug.Log("Equipped character");
                equip(c);
                c.updateText();

            }
        }
        RectTransform rackPanel = weaponRack.transform as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(rackPanel, Input.mousePosition))
        {
            unequip();
        }
   
        transform.localPosition = returnPos;
        Debug.Log(returnPos);
    }

    void equip(CharacterDisplay c)
    {
        if (equippedTo != null) //If the weapon is already equipped to someone, this lets it be swapped
        {
            equippedTo.equipWeapon(c.weaponDisplay);
        }
        c.equipWeapon(this);
    }
    void unequip()
    {
        if(equippedTo!= null)
        {
            equippedTo.weaponDisplay = null;
            equippedTo.character.weapon = null;
            equippedTo = null;
        }
        transform.SetParent(weaponRack.transform);
        returnPos = transform.localPosition;
    }

    public void setWeapon(Attack a)
    {
        weapon = a;
        image.sprite = a.icon;
    }

}