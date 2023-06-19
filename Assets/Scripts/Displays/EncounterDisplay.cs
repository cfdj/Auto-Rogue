using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EncounterDisplay : MonoBehaviour
{
    public List<Image> FrontIcons,BackIcons;
    Encounter currentEncounter;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetEncounter(Encounter e)
    {
        currentEncounter = e;
        currentEncounter.StartEncounter();
        currentEncounter.display = this;
        for(int i = 0; i <currentEncounter.FrontLine.Count; i++)
        {
            FrontIcons[i].sprite = currentEncounter.FrontLine[i].icon;
            FrontIcons[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < currentEncounter.BackLine.Count; i++)
        {
            BackIcons[i].sprite = currentEncounter.BackLine[i].icon;
            BackIcons[i].gameObject.SetActive(true);
            
        }
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < currentEncounter.FrontLine.Count; i++)
        {
            if (currentEncounter.FrontLine[i].health <= 0)
            {
                //EnemyIcons[i].sprite = currentEncounter.FrontLine[i].icon;
                FrontIcons[i].gameObject.SetActive(false);
                
            }
        }
        for (int i = 0; i < currentEncounter.BackLine.Count; i++)
        {
            if (currentEncounter.BackLine[i].health <= 0)
            {
                //EnemyIcons[i + tracker].sprite = currentEncounter.BackLine[i].icon;
                BackIcons[i].gameObject.SetActive(false);
            }
        }
        if(currentEncounter.FrontLine.Count == 0)
        {
            foreach(Image i in FrontIcons)
            {
                i.gameObject.SetActive(false);
            }
        }
        if (currentEncounter.BackLine.Count == 0)
        {
            foreach (Image i in BackIcons)
            {
                i.gameObject.SetActive(false);
            }
        }
    }
}
