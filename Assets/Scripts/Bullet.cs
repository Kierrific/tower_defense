using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Turret turret;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private int bulletDamage = 1;

    private float lifetime = 0f;
    private Vector2 direction;

    public void SetTarget(Transform _target)
    {
        target = _target;
        
    }

    //constantly updates the target and actually moves the bullet for whenever it fires
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * bulletSpeed;
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

    public void damageCalc(float multiplier)
    {
        bulletDamage = Mathf.RoundToInt(bulletDamage * multiplier);
    } 

}
