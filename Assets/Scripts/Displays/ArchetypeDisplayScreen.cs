using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*used to set which archetype each Archetype display shows, also prompts them to check if they should updated if the archetype has been encountered
 * 
*/

public class ArchetypeDisplayScreen : MonoBehaviour
{
    public ArchetypeManager ArchetypeManager;
    public List<ArchetypeDisplay> displays;
    private void OnEnable()
    {
        setDisplays();
    }
    void setDisplays()
    {
        for (int i = 0; i < ArchetypeManager.archetypes.Count; i++)
        {
            displays[i].setArchetype(ArchetypeManager.archetypes[i]);
            displays[i].gameObject.SetActive(true);
        }
    }
}
