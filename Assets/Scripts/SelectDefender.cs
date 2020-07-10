using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDefender : MonoBehaviour
{
    private void OnMouseDown()
    {
        var defenders = FindObjectsOfType<SelectDefender>();
        foreach (SelectDefender defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = new Color32(46, 46, 46, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}