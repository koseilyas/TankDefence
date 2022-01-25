public class LevelCreator
{
    private EnemyManager _enemyManager;
    private DefenceManager _defenceManager;
    

    public void CreateLevel(LevelData levelData, DefenceManager defenceManager, EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
        _defenceManager = defenceManager;
        _defenceManager.InitDefenceManager(levelData.defenceTanks);
        _enemyManager.InitEnemyManager(levelData.enemyTanks);
    }
}