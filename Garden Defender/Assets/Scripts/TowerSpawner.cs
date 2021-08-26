using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject tower;

    void OnMouseDown()
    {
        SpawnTower(GetSquareClicked());
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
        GameObject newTower = Instantiate(tower, roundedPosition, Quaternion.identity) as GameObject;
    }
}
