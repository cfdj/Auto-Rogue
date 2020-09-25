using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
public class Shop : ScriptableObject { 
    public new string name;
    public int level;
    public int Tier;
    public List<Item> inventory;
    public List<Item> current;
}
