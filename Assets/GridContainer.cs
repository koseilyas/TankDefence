using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContainer : MonoBehaviour
{
    [SerializeField] private GridTile[] _tiles;
    [SerializeField] private GridTile _rightTopTileToPut, _leftBottomTileToPut;
    public float leftMost, rightMost, upMost, downMost;
    public static GridContainer Instance;

    private void Awake()
    {
        Instance = this;
        leftMost = _leftBottomTileToPut.transform.position.x;
        rightMost = _rightTopTileToPut.transform.position.x;
        upMost = _rightTopTileToPut.transform.position.y;
        downMost = _leftBottomTileToPut.transform.position.y;
    }

    public GridTile GetEmptyTile(Vector3 position)
    {
        var tile = GetTileAtPos(position);
        if (tile.defenceTank == null)
            return tile;
        else
            return null;
    }

    public GridTile GetTileAtPos(Vector3 position)
    {
        foreach (var tile in _tiles)
        {
            Vector3 tilePos = tile.transform.position;
            if (Mathf.Abs(position.x - tilePos.x) < 0.1f && Mathf.Abs(position.y - tilePos.y) < 0.1f)
            {
                return tile;
            }
        }

        return null;
    }
}
