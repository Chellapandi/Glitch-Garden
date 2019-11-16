using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 3;

    Shooter shooter;

    private void Start()
    {
        shooter = FindObjectOfType<Shooter>();
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }

    private void OnMouseDown()
    {
        shooter.Fire();
    }
}