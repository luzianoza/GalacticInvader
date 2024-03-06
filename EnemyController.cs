using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform[] paths;

    public float hp;
    private float hpDamage;

    public float speed;
    private float speedMultiply = 1f;
    private float slowTimer = 0f;

    private int targetWayPointIndex;

    public int goldDrop;

    public void SetUp(Transform[] waypoints)
    {
        MainGameController.instance.enemyCount++;
        paths = waypoints;
        transform.position = paths[0].position;
        targetWayPointIndex = 1;
    }

    void Update()
    {
        if (MainGameController.instance.isEndGame)
        {
            Destroy(gameObject);
        }

        Vector3 dir = paths[targetWayPointIndex].position - transform.position;
        transform.Translate(dir.normalized * speed * speedMultiply * Time.deltaTime, Space.World);

        if (dir.magnitude < 0.1f)
        {
            targetWayPointIndex++;
            if (targetWayPointIndex >= paths.Length)
            {
                MainGameController.instance.life--;
                Destroy(gameObject);
                MainGameController.instance.enemyCount--;
            }
        }

        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
        }
        else
        {
            speedMultiply = 1f;
        }
    }

    public void TakeDamage(float damage)
    {
        hpDamage += damage;
        
        if (hpDamage >= hp)
        {
            MainGameController.instance.enemyCount--;
            // +Gold Player
            MainGameController.instance.gold += goldDrop;
            Destroy(gameObject);
        }
    }

    public void Slow(float slowPCT)
    {
        speedMultiply = 1f - slowPCT;
        slowTimer = 1f;
    }
}
