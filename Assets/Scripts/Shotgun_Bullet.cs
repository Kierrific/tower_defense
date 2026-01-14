using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shotgun_Bullet : MonoBehaviour
{
    private Transform target;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletDamage = 1;
    [SerializeField] public int pelletCount = 8;

    private float lifetime = 0f;
    private Vector2 direction;
    private float baseDamage = 1f;

    private float _randX;
    private float _randY;
    [SerializeField]private float laksdfjf;

    public void SetTarget(Transform _target)
    {
        _randX = Random.Range(-laksdfjf, laksdfjf);
        _randY = Random.Range(-laksdfjf, laksdfjf);

        Vector2 variation = new Vector2(_randX, _randY);

        target = _target;
        direction = ((Vector2)target.position - (Vector2)transform.position + variation * 0.1f);
    }

    //constantly updates the target and actually moves the bullet for whenever it fires
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }

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

    public void damageCalc(float multiplier, float addition)
    {
        bulletDamage = baseDamage + addition;
        bulletDamage = bulletDamage * multiplier;
    }

    public int GetPelletCount()
    {
        return pelletCount;
    }

}
