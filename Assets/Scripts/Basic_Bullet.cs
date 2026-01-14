using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Basic_Bullet : Bullet
{
    public override void SetTarget(Transform _target)
    {
        target = _target;
        direction = (target.position - transform.position).normalized;
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
}
