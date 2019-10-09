using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        DisplayStar();
    }

    public void DisplayStar()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStar(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int star)
    {
        stars += star;
        DisplayStar();
    }

    public void SpendStars(int star)
    {
        if (stars >= star)
        {
            stars -= star;
            DisplayStar();
        }
    }
}
