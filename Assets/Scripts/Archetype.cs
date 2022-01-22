using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Archetype", menuName = "Archetype")]
public class Archetype : ScriptableObject
{
    public new string name;
    public bool gapRequirement;
    [SerializeField] int healthReq; //0 = no requirement, 2 this must be highest
    [SerializeField] int manaReq;
    [SerializeField] int attackReq;
    [SerializeField] int magicReq;
    public bool maxRequirement;
    [SerializeField] int healthMax;
    [SerializeField] int manaMax;
    [SerializeField] int attackMax;
    [SerializeField] int magicMax;
    
    public bool fitsRequirements(Character character)
    {
        int[] characterStats = { 0, 0, 0, 0 };
        int lowestStat =
        return false;
    }
    public void setArchetype(Character character)
    {
        if (fitsRequirements(character))
        {
            character.archetype = this;
        }
    }

}
