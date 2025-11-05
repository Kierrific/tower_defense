using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private int hitPoints = 2;

    private bool isDestroyed = false;
    private int holdHP = 2;

    //used in the Bullet script to allow the enemy objects to take damage
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public void calcHealth(int healthNum)
    {
        hitPoints = holdHP + healthNum;
    }

    public void updateHealth()
    {
        holdHP = hitPoints;
    }
}
