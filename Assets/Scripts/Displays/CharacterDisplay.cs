﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;
    public Text displayName;
    public Text displayClass;
    public Image weaponIcon;
    // Start is called before the first frame update
    void Start()
    {
        displayName.text = character.name;
        displayClass.text = character.archetype.name;
        weaponIcon.sprite = character.weapon.icon;
    }

    public void updateText()
    {
        displayName.text = character.name;
        displayClass.text = character.archetype.name;
        weaponIcon.sprite = character.weapon.icon;
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
        weaponIcon.sprite = null;
    }
}
