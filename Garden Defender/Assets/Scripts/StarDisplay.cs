using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int currentStars = 100;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateStarText();
    }

    void UpdateStarText()
    {
        starText.text = currentStars.ToString();
    }

    public void AddStars(int amount)
    {
        currentStars += amount;
        UpdateStarText();
    }

    public void RemoveStars(int amount)
    {
        if (currentStars >= amount )
        {
            currentStars -= amount;
            UpdateStarText();
        }
        else
            NotEnoughStarsMessage();
    }

    void NotEnoughStarsMessage()
    {
        throw new NotImplementedException();
    }
}
