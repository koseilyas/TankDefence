using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private DefenceManager _defenceManager;
    private LevelLoader _levelLoader;
    private LevelCreator _levelCreator;
    private void Awake()
    {
        _levelLoader = new LevelLoader();
        _levelCreator = new LevelCreator();
    }

    private void Start()
    {
        _levelCreator.CreateLevel(_levelLoader.GetLevel(1),_defenceManager,_enemyManager);
    }
}