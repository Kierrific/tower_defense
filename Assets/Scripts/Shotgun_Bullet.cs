using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shotgun_Bullet : Bullet
{
    [SerializeField] public int pelletCount = 8;

    private float _randX;
    private float _randY;
    [SerializeField]private float laksdfjf;

    public override void SetTarget(Transform _target)
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

    public int GetPelletCount()
    {
        return pelletCount;
    }

}
