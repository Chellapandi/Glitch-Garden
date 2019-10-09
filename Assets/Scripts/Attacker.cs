using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float walkSpeed = 1f;

    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
       if(!currentTarget)
       {
            GetComponent<Animator>().SetBool("IsAttacking", false);
       }
    }

    public void SetMoveSpeed(float speed)
    {
        this.walkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking",true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DamageDeal(damage);
        }
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();

        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }
}
