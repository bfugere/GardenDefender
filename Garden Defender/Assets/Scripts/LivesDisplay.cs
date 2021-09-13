using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float startingLives = 3f;
    [SerializeField] int damage = 1;

    float currentLives;

    Text livesText;

    void Start()
    {
        currentLives = startingLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        livesText.text = currentLives.ToString();
    }

    public void RemoveLives()
    {
        currentLives -= damage;
        UpdateLivesText();

        if (currentLives <= 0)
            FindObjectOfType<LevelController>().HandleLoseCondition();
    }
}
