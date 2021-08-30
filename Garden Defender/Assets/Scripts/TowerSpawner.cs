using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    Tower tower;

    void OnMouseDown()
    {
        // Spawn Tower
        AttemptToPlaceTowerAt(GetSquareClicked());
    }

    public void SetSelectedTower(Tower towerToSelect)
    {
        tower = towerToSelect;
    }

    void AttemptToPlaceTowerAt(Vector2 gridPosition)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int towerCost = tower.GetStarCost();

        // Spawn Tower
        if (starDisplay.HasEnoughStars(towerCost))
        {
            SpawnTower(gridPosition);
            starDisplay.RemoveStars(towerCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }

    void SpawnTower(Vector2 roundedPosition)
    {
        Tower newTower = Instantiate(tower, roundedPosition, Quaternion.identity) as Tower;
    }
}
