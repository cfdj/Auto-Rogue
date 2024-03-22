using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Used to check which archetype a character should be based on their stats
 * Setup to allow variation in available archetypes in future
*/
[CreateAssetMenu(fileName = "New ArchetypeManager", menuName = "ArchetypeManager")]
public class ArchetypeManager : ScriptableObject
{
    public List<Archetype> archetypes;

    public Archetype GetArchetype(Character character)
    {
        Archetype fits = archetypes[0];
        foreach(Archetype archetype in archetypes)
        {
            if (archetype.fitsRequirements(character))
            {
                fits = archetype;
            }
        }
        return fits;
    }
}
