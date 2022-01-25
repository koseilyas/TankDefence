using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel",menuName = "Levels/NewLevel")]
public class LevelData : ScriptableObject
{
    public List<LevelObjectDefence> defenceTanks;
    public List<LevelObjectEnemy> enemyTanks;
}
