
using System.Collections.Generic;
using UnityEngine;

public class DefenceManager : MonoBehaviour
{
    [SerializeField] private InventoryTankObject _inventoryTankPrefab;
    [SerializeField] private Transform _inventoryParent;
    public void InitDefenceManager(List<LevelObjectDefence> defenceTanks)
    {
        for (var i = 0; i < defenceTanks.Count; i++)
        {
            var tankData = defenceTanks[i];
            InventoryTankObject tank = Instantiate(_inventoryTankPrefab, _inventoryParent);
            tank.Init(tankData.defenceTank, tankData.count);
            tank.transform.position = new Vector3(-1 + i, 0, 0);
        }
    }
}

public class InventoryTankObject : MonoBehaviour
{
    public void Init(DefenceTank tankDataDefenceTank, int tankDataCount)
    {
        
    }
}
