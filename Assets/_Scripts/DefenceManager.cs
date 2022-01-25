
using System.Collections.Generic;
using UnityEngine;

public class DefenceManager : MonoBehaviour
{
    [SerializeField] private InventoryTankObject _inventoryTankPrefab;
    [SerializeField] private Transform _inventoryParent;
    [SerializeField] private Transform _spawnedTanksParent;
    public void InitDefenceManager(List<LevelObjectDefence> defenceTanks)
    {
        for (var i = 0; i < defenceTanks.Count; i++)
        {
            SetupTankInventory(defenceTanks, i);
        }
    }

    private void SetupTankInventory(List<LevelObjectDefence> defenceTanks, int i)
    {
        var tankData = defenceTanks[i];
        InventoryTankObject tankInventory = Instantiate(_inventoryTankPrefab, _inventoryParent);
        tankInventory.name = _inventoryParent.name + i;
        var tankObj = Instantiate(tankData.defenceTank, transform);
        tankObj.name = tankData.defenceTank.name;
        tankInventory.Init(tankObj,_spawnedTanksParent, tankData.count);
        tankInventory.transform.localPosition = new Vector3(-1.25f + i * 1.25f, 0, 0);
    }
}