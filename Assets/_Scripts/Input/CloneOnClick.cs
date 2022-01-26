using UnityEngine;
public class CloneOnClick : MonoBehaviour
{
    private GameObject _prefab;
    private Transform _parent;
    private InventoryTankObject _inventoryTankObject;

    public void Initialize(GameObject prefab, Transform parent,InventoryTankObject inventoryTankObject)
    {
        _inventoryTankObject = inventoryTankObject;
        _prefab = prefab;
        _parent = parent;
    }

    private void OnMouseDown()
    {
        Spawn();
    }

    void Spawn()
    {
        _inventoryTankObject.TankSpawned();
        GameObject go = Instantiate(_prefab, _parent);
        go.transform.position = _prefab.transform.position;
        if (go.TryGetComponent(out CloneOnClick cloneOnClick))
        {
            Destroy(cloneOnClick);
        }

        DraggableObject draggableObject = go.AddComponent<DraggableObject>();
    }
}
