using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DamageDeal(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            DeathTriggerVFX();
            Destroy(gameObject);
        }

    }

    private void DeathTriggerVFX()
    {

        if (!deathVFX) return;

        GameObject deathVFXObject =  Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
