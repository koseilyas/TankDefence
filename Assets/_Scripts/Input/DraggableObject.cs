using System;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Camera _cam;
    private bool _canDrag = true;
    private float elapsingTime = 0.3f;
    private DefenceTank _draggingTank; 

    void Awake() {
        _cam = Camera.main;
        _draggingTank = GetComponent<DefenceTank>();
    }

    void Update()
    {
        if (!_canDrag)
            return;
        transform.position = GetMousePos();
        ClickLock();
    }

    private void ClickLock()
    {
        if (elapsingTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _canDrag = false;
                PutObject();
            }
        }
        else
        {
            elapsingTime -= Time.deltaTime;
        }
    }

    private void PutObject()
    {
        var position = transform.position;
        position = position.Snap(0.5f);
        transform.position = position;
        GridTile tile = GridContainer.Instance.GetEmptyTile(position);
        if (tile == null)
        {
            _canDrag = true;
        }
        else
        {
            tile.PutTank(_draggingTank);
            _draggingTank.Activate();
            Destroy(this);
        }
    }

    Vector3 GetMousePos() {
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos = mousePos.SnapToTile(1f);
        return mousePos;
    }
}
