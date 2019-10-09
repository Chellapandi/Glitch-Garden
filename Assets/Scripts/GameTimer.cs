using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Game timer in Seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    
    void Update()
    {
        if (triggeredLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool isLevelFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (isLevelFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
