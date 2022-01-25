using UnityEngine;
public class CloneOnClick : MonoBehaviour
{
    private GameObject _prefab;
    private Transform _parent;

    public void Initialize(GameObject prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    private void OnMouseDown()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject go = Instantiate(_prefab, _parent);
        go.transform.position = _prefab.transform.position;
        if (go.TryGetComponent(out CloneOnClick cloneOnClick))
        {
            Destroy(cloneOnClick);
        }

        DraggableObject draggableObject = go.AddComponent<DraggableObject>();
    }
}
