using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    void Start()
    {
        TowerCostLabels();
    }

    void TowerCostLabels()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = towerPrefab.GetStarCost().ToString();

        /*
        if (!costText)
            Debug.LogError(name + " has no cost text assigned to it.");
        else
            costText.text = towerPrefab.GetStarCost().ToString();
        */
    }

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
