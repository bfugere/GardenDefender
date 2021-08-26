using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<TowerButton>();

        foreach (TowerButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(50, 50, 50, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<TowerSpawner>().SetSelectedTower(towerPrefab);
    }
}
