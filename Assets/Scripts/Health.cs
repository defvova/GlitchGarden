using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] private GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (!HasHealth())
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        var newVFX = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(newVFX, 1f);
    }

    public bool HasHealth()
    {
        return health > 0f;
    }
}