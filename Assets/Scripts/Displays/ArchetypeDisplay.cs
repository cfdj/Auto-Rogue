using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Used to show Archetypes in the class window
 * These only display details if the archetype has been encountered
 */
public class ArchetypeDisplay : MonoBehaviour
{
    private Archetype archetype;
    public Text nameText;
    public Text requirmentsText;
    public List<Image> requirementsImages;
    public void setArchetype(Archetype newarchetype)
    {
        archetype = newarchetype;
        if (archetype.encountered) {
            nameText.text = archetype.name;
            int[] statReqs = archetype.getRequirements();
            if (!archetype.maxRequirement)
            {
                requirmentsText.text = "None";
            }
            for(int r = 0; r < statReqs.Length; r++)
            {
                if(statReqs[r] == 1)
                {
                    requirementsImages[r].enabled = true; //Done like this so the image disappears but the grid position of others doesn't change
                }
                else
                {
                    requirementsImages[r].enabled = false;
                }
            }
        }
        else
        {
            nameText.text = "????";
            requirmentsText.text = "????";
            foreach (Image i in requirementsImages)
            {
                i.enabled = false;
            }
        }
    }
    
}
