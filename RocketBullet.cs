using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public Transform _target;

    public float _speed = 10f;
    public float damage;
    public float bomeRange;


    public void SetUpRocket(Transform mTarget, float mDamage, float mBomeRange)
    {
        _target = mTarget;
        damage = mDamage;
        bomeRange = mBomeRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float deltaDistance = _speed * Time.deltaTime;

        if (dir.magnitude <= deltaDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * deltaDistance, Space.World);
        transform.LookAt(_target);
    }


    private void HitTarget()
    {
        Collider[] allOB = Physics.OverlapSphere(_target.position, bomeRange);

        for (int i = 0; i < allOB.Length; i++)
        {
            EnemyController enemy = allOB[i].GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                
            }
        }
        Destroy(gameObject);
    }
}
