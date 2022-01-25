using UnityEngine;

public class LevelLoader
{
    private string _path = "Levels/";

    public LevelData GetLevel(int levelNum)
    {
        var levelData = Resources.Load<LevelData>($"{_path}Level{levelNum}");
        return levelData;
    }
}