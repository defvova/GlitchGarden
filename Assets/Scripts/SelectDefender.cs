using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDefender : MonoBehaviour
{
    [SerializeField] private Defender defender;

    private void OnMouseDown()
    {
        var defenders = FindObjectsOfType<SelectDefender>();
        foreach (SelectDefender selectedDefender in defenders)
        {
            selectedDefender.GetComponent<SpriteRenderer>().color = new Color32(46, 46, 46, 255);
        }
        FindObjectOfType<DefenderSpawner>().SetDefender(defender);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}