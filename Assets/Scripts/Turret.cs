using UnityEngine;

public abstract class Turret : MonoBehaviour
{

    [Header("References")]
    [SerializeField] protected Transform turretRotationPoint;
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] protected float targetingRange = 5f;
    [SerializeField] protected float rotationSpeed = 200f;
    [SerializeField] protected float bps = 1f; // bullets per second
    [SerializeField] public float damageMultiplier = 1f;
    [SerializeField] public float damageAddition = 0f;

    protected Transform target;
    protected float timeUntilFire;
    public int identifier;


    protected void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        bulletObj.gameObject.GetComponent<Bullet>().DamageCalc(damageMultiplier, damageAddition);
    }

    protected int CheckTargetsInRange()
    {
        if (EnemySpawner.main.GetEnemies().Count > 0)
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

        return -1;
    }

    protected void FindTarget()
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

    //checks to see if the targetted enemy is actually in range of the turret
    protected bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    protected void RotateTowardsTarget()
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
