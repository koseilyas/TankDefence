using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig/DefenceTank", fileName = "DefenceTankSpecs", order = 0)]
public class DefenceTankSpecs : ScriptableObject
{
    public int damage;
    public int range;
    public int interval;
    public Vector2[] direction;
}