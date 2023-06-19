using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdventureDisplay : MonoBehaviour
{
    public Text adventureName;
    public List<Character> characters;
    public Adventure adventure;
    public AdventureLog log;

    public List<Line> Lines;
    public List<EncounterDisplay> encounterDisplays;

    public Button thisAdventureButton;
    void Awake()
    {
        foreach(Line l in Lines)
        {
            l.SetInvisible();
        }
        for(int i = 0; i < Lines.Count &&i<encounterDisplays.Count*2; i += 2)
        {
            encounterDisplays[i/2].FrontIcons = Lines[i].icons;
            encounterDisplays[i/2].BackIcons = Lines[i + 1].icons;
        }
    }
    public void SetAdventure(Adventure newAdventure)
    {
        adventure = newAdventure;
        adventureName.text = adventure.name;
        for(int i = 0; i< adventure.encounters.Count; i++)
        {
            encounterDisplays[i].SetEncounter(adventure.encounters[i]);
        }
    }
    public void OnClick()
    {
        adventure.log = log;
        log.ClearLog();
        thisAdventureButton.interactable = false;
        adventure.StartAdventure(characters);
    }
}
