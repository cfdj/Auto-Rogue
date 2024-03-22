using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Enemy asset, used for creating enemies for encounters
 * 
 */
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int health;
    public int Attack;
    public Sprite icon;
    public int reward;
}
