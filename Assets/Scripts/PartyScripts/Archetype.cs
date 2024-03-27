using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Archetypes determine available weapons and attacks
 * Characters fit archetypes by having their highest stats match those of the archetype
 * Currently stores stat requirements as ints because of a potential design change to thresholds rather than highest
*/
[CreateAssetMenu(fileName = "New Archetype", menuName = "Archetype")]
public class Archetype : ScriptableObject
{
    public new string name;
    public bool maxRequirement;
    [SerializeField] int healthReq; //0 = no requirement, 1 this must be highest
    [SerializeField] int manaReq;
    [SerializeField] int attackReq;
    [SerializeField] int magicReq;
    public bool encountered = false;
    public int[] getRequirements()
    {
        int[] archetypeStats = { healthReq, manaReq, attackReq, magicReq};
        return archetypeStats;
    }
    public int[] getCharacterArray(Character character)
    {
        int[] characterStats = {0,0,0,0};
        int[] characterValues = character.getStats();
        for(int i = 0; i < 4; i++)
        {
            int isHighest = 1;
            for(int x = 0; x< 4; x++)
            {
                if(characterValues[i] < characterValues[x])
                {
                    isHighest = 0;
                }
            }
            characterStats[i] = isHighest;
        }
        return characterStats;
    }

    public bool fitsRequirements(Character character)
    {
        int[] characterStats = { 0, 0, 0, 0 };
        int[] archetypeStats = getRequirements();
        characterStats = getCharacterArray(character);
        //Debug.Log("Stats array: " + characterStats[0] + characterStats[1] + characterStats[2] + characterStats[3]);
        //Debug.Log("" + name + " array: " + archetypeStats[0] + archetypeStats[1] + archetypeStats[2] + archetypeStats[3]);
        bool equals = true;
        if (maxRequirement)
        {
            for (int i = 0; i < 4; i++)
            {
                if (characterStats[i] != archetypeStats[i])
                {
                    equals = false;
                }
            }
        }
        return equals;
    }
    public void setArchetype(Character character)
    {
        if (fitsRequirements(character))
        {
            character.archetype = this;
            encountered = true;
        }
    }

}
