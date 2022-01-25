using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig/EnemyTank", fileName = "EnemyTankSpecs", order = 1)]
public class EnemyTankSpecs : ScriptableObject
{
    public int health;
    public float speed;
}