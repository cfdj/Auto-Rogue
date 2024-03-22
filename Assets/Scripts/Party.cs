using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Party", menuName = "Party")]
/*Preperation for having the player manage multiple different parties
 * Actually implementing this requiers further UI changes to swap between the present party and a manager who which part is currently acitve and why they change
 */
public class Party : ScriptableObject
{
    public new string name;
    public List<Character> characters;
    public Inventory inventory;
}
