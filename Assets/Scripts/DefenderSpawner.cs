using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender currentDefender;

    private void OnMouseUp()
    {
        if (!currentDefender) return;
        AddDefender(GetSquareClicked());
    }

    public void SetDefender(Defender defender)
    {
        this.currentDefender = defender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        var newX = Mathf.RoundToInt(worldPos.x);
        var newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }

    private void AddDefender(Vector2 roundedPosition)
    {
        Instantiate(currentDefender, roundedPosition, transform.rotation);
    }
}