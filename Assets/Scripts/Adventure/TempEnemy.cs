using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Used for temporarily holding enemy stats during encounters, so base stats aren't effected
*/
public class TempEnemy
{
    public string name;
    public bool alive;
    public int health;
    public int Attack;
    public Sprite icon;
    public TempEnemy(Enemy e)
    {
        name = e.name;
        alive = true;
        health = e.health;
        Attack = e.Attack;
        icon = e.icon;
    }
    public void Damage(float hit)
    {
        health -= Mathf.FloorToInt(hit);
        if (health < 0)
        {
            alive = false;
        }
    }
}
