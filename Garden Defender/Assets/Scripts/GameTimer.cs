using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTimer = 10f;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);
        if (timerFinished)
        {
            Debug.Log("Level Timer Expired!");
        }
    }
}
