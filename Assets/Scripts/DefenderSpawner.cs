using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetClickedPosition());
    }

    public void SetDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int starCost = defender.GetStarCost();

        if (starDisplay.HaveEnoughStar(starCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(starCost);
        }
    }

    private Vector2 GetClickedPosition()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return SnapToGrid(Camera.main.ScreenToWorldPoint(mousePos));
    }

    private Vector2 SnapToGrid(Vector2 rawWordlPosition)
    {
        float newX = Mathf.RoundToInt(rawWordlPosition.x);
        float newY = Mathf.RoundToInt(rawWordlPosition.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
    }
}
