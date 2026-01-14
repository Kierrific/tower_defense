using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Bullet : MonoBehaviour
{
    protected Transform target;

    [Header("References")]
    [SerializeField] protected Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] protected float bulletSpeed = 20f;
    [SerializeField] protected float bulletDamage = 1;

    protected float lifetime = 0f;
    protected Vector2 direction;
    protected int baseDamage = 2;

    public abstract void SetTarget(Transform _target);

    public void DamageCalc(float multiplier, float addition)
    {
        bulletDamage = baseDamage + addition;
        bulletDamage = bulletDamage * multiplier;
    }

    //Allows for the enemies to take damage and destroys the bullet once it happens.
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 5f)
        {
            Destroy(gameObject);
        }
    }
}
