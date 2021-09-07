using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int currentLives = 10;
    [SerializeField] int damage = 1;

    Text livesText;

    void Start()
    {
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
            FindObjectOfType<LevelLoader>().LoadYouLoseScene();
    }
}
