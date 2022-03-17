using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
