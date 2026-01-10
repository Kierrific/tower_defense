using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Shotgun_Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float bps = 1f; // bullets per second
    [SerializeField] public float damageMultiplier = 1f;
    [SerializeField] public float damageAddition = 0f;

    private Transform target;
    private float timeUntilFire;
    public int identifier;

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

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        bulletObj.gameObject.GetComponent<Bullet>().damageCalc(damageMultiplier, damageAddition);
    }

    private void FindTarget()
    {
        //RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        //if (hits.Length > 0)
        //{
        //    target = hits[0].transform;
        //}
        if (EnemySpawner.main.GetEnemies().Count > 0)
        {
            if (CheckTargetsInRange() != -1)
            {
                target = EnemySpawner.main.GetEnemies()[CheckTargetsInRange()].transform;
            }
        }
    }

    private int CheckTargetsInRange()
    {
        for (int i = 0; i < EnemySpawner.main.GetEnemies().Count; i++)
        {
            if (Vector2.Distance(EnemySpawner.main.GetEnemies()[i].transform.position, transform.position) <= targetingRange)
            {
                return i;
            }
        }
        return -1;
    }

    //checks to see if the targetted enemy is actually in range of the turret
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void addMultiplier(int mult)
    {
        damageMultiplier = damageMultiplier * mult;
    }

    public void addDamage(int damage)
    {
        damageAddition += damage;
    }

    public void addBPS(float addition)
    {
        bps += addition;
    }

    public int getIdentifier()
    {
        return identifier;
    }
}
