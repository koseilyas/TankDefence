using TMPro;
using UnityEngine;

public class InventoryTankObject : MonoBehaviour
{
    [SerializeField] private TMP_Text _tankCountText;
    private int _tankCount;
    private Transform _spawnedParent;
    
    public void Init(DefenceTank defenceTank,Transform spawnedParent, int tankDataCount)
    {
        _spawnedParent = spawnedParent;
        _tankCount = tankDataCount;
        UpdateTankCountText();
        SetPosition(defenceTank);
        CloneOnClick cloneOnClick = defenceTank.gameObject.AddComponent<CloneOnClick>();
        cloneOnClick.Initialize(defenceTank.gameObject,_spawnedParent);
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
}