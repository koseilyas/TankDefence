
using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameMonoBehaviour : MonoBehaviour
{
    private List<DefenceTank> _activeDefenceTanks;
    private List<EnemyTank> _activeEnemyTanks;
    private List<Bullet> _activeBullets;

    private void OnEnable()
    {
        _activeDefenceTanks = new List<DefenceTank>();
        _activeEnemyTanks = new List<EnemyTank>();
        _activeBullets = new List<Bullet>();
        DefenceTank.OnTankCreated += AddDefenceTank;
        DefenceTank.OnDefenceTankKilled += RemoveDefenceTank;

        EnemyTank.OnEnemyCreated += AddEnemyTank;
        EnemyTank.OnEnemyKilled += RemoveEnemyTank;

        Bullet.OnBulletCreated += AddBullet;
        Bullet.OnBulletDestroyed += RemoveBullet;
        
    }

    private void OnDisable()
    {
        DefenceTank.OnTankCreated -= AddDefenceTank;
        DefenceTank.OnDefenceTankKilled -= RemoveDefenceTank;

        EnemyTank.OnEnemyCreated -= AddEnemyTank;
        EnemyTank.OnEnemyKilled -= RemoveEnemyTank;

        Bullet.OnBulletCreated -= AddBullet;
        Bullet.OnBulletDestroyed -= RemoveBullet;
        
    }


    private void RemoveBullet(Bullet obj)
    {
        _activeBullets.Remove(obj);
    }

    private void AddBullet(Bullet obj)
    {
        _activeBullets.Add(obj);
    }

    private void RemoveEnemyTank(EnemyTank obj)
    {
        _activeEnemyTanks.Remove(obj);
    }

    private void AddEnemyTank(EnemyTank obj)
    {
        _activeEnemyTanks.Add(obj);
    }

    private void RemoveDefenceTank(DefenceTank obj)
    {
        _activeDefenceTanks.Remove(obj);
    }

    private void AddDefenceTank(DefenceTank obj)
    {
        _activeDefenceTanks.Add(obj);
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < _activeBullets.Count; i++)
        {
            _activeBullets[i].PhysicsTick();
        }
        
        for (int i = 0; i < _activeEnemyTanks.Count; i++)
        {
            _activeEnemyTanks[i].PhysicsTick();
        }
        
        for (int i = 0; i < _activeDefenceTanks.Count; i++)
        {
            _activeDefenceTanks[i].PhysicsTick();
        }
    }
}
