using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Health : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject particle;

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
            GameObject particleEffect = Instantiate(particle, transform.position, Quaternion.identity);
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
