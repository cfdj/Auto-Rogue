using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*Handles displaying characters
 * Used by ItemDisplays and WeaponDisplays to determine which characters they're being used on/equipped to
 * Next piece of functionality to implement is un-equipping weapons when a character no longer meets the requirements
 */
public class CharacterDisplay : MonoBehaviour
{
    public Character character;
    public Text displayName;
    public Text displayClass;
    public WeaponDisplay weaponDisplay;
    public RectTransform weaponLocation;
    // Start is called before the first frame update
    void Start()
    {
        updateText();
        weaponDisplay.setWeapon(character.weapon);
    }

    public void updateText()
    {
        displayName.text = character.name;
        displayClass.text = character.archetype.name;
    }

    public void SetCharacter(Character newCharacter)
    {
        character = newCharacter;
        updateText();
    }
    public void RemoveCharacter()
    {
        character = null;
        displayName.text = "";
        displayClass.text = "";
        //weaponIcon.sprite = null;
    }
    public void equipWeapon(WeaponDisplay weapon)
    {
        weaponDisplay = weapon;
        character.weapon = weapon.weapon;
        weapon.transform.SetParent(transform);
        (weapon.transform as RectTransform).anchorMax = weaponLocation.anchorMax;
        (weapon.transform as RectTransform).anchorMin = weaponLocation.anchorMin;
        //(weapon.transform as RectTransform).localScale = weaponLocation.localScale;
        (weapon.transform as RectTransform).position = weaponLocation.position;

    }
}
