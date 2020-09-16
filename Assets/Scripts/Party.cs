using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Party", menuName = "Party")]
public class Party : ScriptableObject
{
    public new string name;
    public List<Character> characters;
    public int coin;
}
