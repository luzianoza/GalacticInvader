using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTerret : MonoBehaviour
{
    public Transform target;
    public Transform pathToRotate;

    public EnemyController enemyTarget;//ªÈÕ¡Lazer

    public float range = 5f;

    public int sellPrice;

    // Start is called before the first frame update
    public virtual void Start()
    {
        StartCoroutine(UpDateTarget());
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (MainGameController.instance.isEndGame)//µ—«‡™Á§°“√®∫‡°¡
        {
            return;
        }

        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        dir.y = 0f;
        pathToRotate.rotation = Quaternion.LookRotation(dir);
    }

    private IEnumerator UpDateTarget()
    {
        while (true)
        {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            float shortestDistance = float.MaxValue;
            GameObject nearestEnemy = null;

            for (int i = 0; i < enemy.Length; i++)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy[i].transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy[i];
                }
            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                enemyTarget = target.GetComponent<EnemyController>();//ªÈÕ¡Lazer
            }
            else
            {
                target = null;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
