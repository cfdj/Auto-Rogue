using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;
    public Text displayName;
    public Text displayClass;
    // Start is called before the first frame update
    void Start()
    {
        displayName.text = character.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
