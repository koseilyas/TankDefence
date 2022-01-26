using TMPro;
using UnityEngine;

public class InventoryTankObject : MonoBehaviour
{
    private int _tankCount;
    private Transform _spawnedParent;
    [SerializeField] private TMP_Text _tankCountText;
    
    public void Init(DefenceTank defenceTank,Transform spawnedParent, int tankDataCount)
    {
        _spawnedParent = spawnedParent;
        _tankCount = tankDataCount;
        UpdateTankCountText();
        SetPosition(defenceTank);
        CloneOnClick cloneOnClick = defenceTank.gameObject.AddComponent<CloneOnClick>();
        cloneOnClick.Initialize(defenceTank.gameObject,_spawnedParent,this);
    }

    private void SetPosition(DefenceTank tankDataDefenceTank)
    {
        Transform tankTransform = tankDataDefenceTank.transform;
        tankTransform.SetParent(transform);
        tankTransform.localPosition = Vector3.zero;
        tankTransform.SetSiblingIndex(0);
    }

    void UpdateTankCountText()
    {
        _tankCountText.SetText($"x{_tankCount}");
    }
    
    public void TankSpawned()
    {
        _tankCount--;
        UpdateTankCountText();
        if (_tankCount == 0)
        {
            gameObject.SetActive(false);
        }
    }
}