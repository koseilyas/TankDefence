using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public DefenceTank defenceTank;

    public void PutTank(DefenceTank tank)
    {
        defenceTank = tank;
        tank.SetGridTile(this);
    }
}
