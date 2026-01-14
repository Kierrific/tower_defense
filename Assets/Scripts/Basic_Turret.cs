using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Basic_Turret : Turret
{
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
}
