using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelLoader _levelLoader;
    private LevelCreator _levelCreator;
    private static int _levelNo = 1;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private DefenceManager _defenceManager;
    [SerializeField] private ResultPanel _resultPanel;
    public static event Action OnLevelRestart;

    private void Awake()
    {
        _levelLoader = new LevelLoader();
        _levelCreator = new LevelCreator();
    }

    private void OnEnable()
    {
        DefenceTank.OnTankCreated += TankCreated;
        EnemyTank.OnEnemyReachedToLine += FailLevel;
        EnemyTank.OnAllEnemiesDestroyed += WinLevel;
    }
    private void OnDisable()
    {
        DefenceTank.OnTankCreated -= TankCreated;
        EnemyTank.OnEnemyReachedToLine -= FailLevel;
        EnemyTank.OnAllEnemiesDestroyed -= WinLevel;
    }

    private void Start()
    {
        CreateLevel();
        _resultPanel.DisablePanel();
    }

    private void WinLevel()
    {
        _levelNo++;
        _resultPanel.WinScreen();
        StartCoroutine(RestartLevel());
    }

    private void FailLevel()
    {
        _resultPanel.LoseScreen();
        StartCoroutine(RestartLevel());
    }

    private void TankCreated(DefenceTank tank)
    {
        if (tank.tankIndex == 0)
        {
            _enemyManager.StartAttacking();
        }
    }


    private void CreateLevel()
    {
        _levelCreator.CreateLevel(_levelLoader.GetLevel(_levelNo), _defenceManager, _enemyManager);
    }

    private IEnumerator RestartLevel()
    {
        OnLevelRestart?.Invoke();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}