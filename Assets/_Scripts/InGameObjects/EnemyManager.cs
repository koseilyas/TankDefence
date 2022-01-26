using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    private WaitForSeconds _spawnInterval = new WaitForSeconds(3f);
    [SerializeField] private Transform _enemySpawnTransform;
    public List<EnemyTank> deactiveEnemyTanks = new List<EnemyTank>();
    public List<EnemyTank> allEnemyTanks = new List<EnemyTank>();

    private void OnEnable()
    {
        EnemyTank.OnEnemyKilled += TankExploded;
    }
    

    private void OnDisable()
    {
        EnemyTank.OnEnemyKilled -= TankExploded;
    }

    void TankExploded(EnemyTank tank)
    {
        allEnemyTanks.Remove(tank);
    }        

    public void InitEnemyManager(List<LevelObjectEnemy> levelDataEnemyTanks)
    {
        foreach (var tankData in levelDataEnemyTanks)
        {
            for (int i = 0; i < tankData.count; i++)
            {
                EnemyTank enemyTank  = Instantiate(tankData.enemyTank, _enemySpawnTransform);
                enemyTank.transform.localPosition = Vector3.zero;
                enemyTank.gameObject.name = $"{tankData.enemyTank.name}_{(i + 1)}";
                enemyTank.gameObject.SetActive(false);
                deactiveEnemyTanks.Add(enemyTank);
                allEnemyTanks.Add(enemyTank);
                EnemyTank.enemyTankCount++;
            }
        }
    }

    public void StartAttacking()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        int deactiveTankCount = deactiveEnemyTanks.Count;
        for (int i=0 ; i<deactiveTankCount ; i++)
        {
            if(deactiveEnemyTanks.Count <= 0)
                yield break;
            int random = Random.Range(0, deactiveEnemyTanks.Count);
            deactiveEnemyTanks[random].Activate();
            deactiveEnemyTanks.Remove(deactiveEnemyTanks[random]);
            yield return _spawnInterval;
        }
    }
}
