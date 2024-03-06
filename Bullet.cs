using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float damage;
    public float speed;

    public void SetUpBullet(Transform mTarget, float mDamage)
    {
        target = mTarget;
        damage = mDamage;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float deltaDistance = speed * Time.deltaTime;
        if (dir.magnitude <= deltaDistance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * deltaDistance, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        // -HP Enemy Target
        EnemyController enemy = target.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        Destroy(gameObject);
    }
}
