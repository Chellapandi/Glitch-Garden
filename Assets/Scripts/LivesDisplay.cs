using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    Text livesText;
    float lives;

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        DisplayStar();
    }

    public void DisplayStar()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        DisplayStar();

        Debug.Log(" lives remaning "+lives);

        if(lives <= 0)
		{
            FindObjectOfType<LevelController>().HandleLoseCondition();
		}
    }

}
