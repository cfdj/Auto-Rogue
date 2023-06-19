using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Line : MonoBehaviour
{
    public List<Image> icons;
    public void SetInvisible()
    {
        foreach(Image i in icons)
        {
            i.gameObject.SetActive(false);
        }
    }
}
