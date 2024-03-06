using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveData[] _wave;

    public int currentWaveIndex;
    public int currentGroupIndex;

    public bool isWaveEnd = false;

    public Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentGroupIndex = 0;
        currentWaveIndex = 0;
        StartCoroutine(WaveCoroutine());
    }

    private IEnumerator WaveCoroutine()
    {
        while (currentWaveIndex < _wave.Length)
        {
            WaveData waveTemp = _wave[currentWaveIndex];
            yield return new WaitForSeconds(waveTemp.delayBeforeWave);

            while (currentGroupIndex < waveTemp.groups.Length)
            {
                EnemyGroup groupTemp = waveTemp.groups[currentGroupIndex];
                for (int i = 0; i < groupTemp.enemyCount; i++)
                {
                    if (MainGameController.instance.isEndGame)
                    {
                        yield break;
                    }

                    GameObject go = Instantiate(groupTemp.enemyPrefeb, Vector3.zero, Quaternion.identity);
                    EnemyController enemy = go.GetComponent<EnemyController>();
                    if (enemy == null)
                    {
                        Destroy(go);
                    }
                    else
                    {
                        //Set Up Enemy Path
                        enemy.SetUp(wayPoints);
                    }
                    yield return new WaitForSeconds(groupTemp.enemyDelay);
                }
                yield return new WaitForSeconds(groupTemp.nextGroupDelay);
                currentGroupIndex++;
            }
            currentGroupIndex = 0;
            currentWaveIndex++;
        }
        isWaveEnd = true;
    }
}

[System.Serializable]
public class WaveData
{
    public EnemyGroup[] groups;
    public float delayBeforeWave;
}

[System.Serializable]
public class EnemyGroup
{
    public GameObject enemyPrefeb;
    public int enemyCount;
    public float enemyDelay;
    public float nextGroupDelay;
}
