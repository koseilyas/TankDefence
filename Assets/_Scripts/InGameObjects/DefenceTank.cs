using System;
using UnityEngine;

public class DefenceTank : MonoBehaviour
{
    private bool _isActive;
    private GridTile _gridTile;
    private float _attackInterval,_timer;
    [SerializeField] private Bullet _bullet;
    public DefenceTankSpecs defenceTankSpecs;
    public int tankIndex;
    public static int tankCount;
    public static event Action<DefenceTank> OnDefenceTankKilled;
    public static event Action<DefenceTank> OnTankCreated;

    public void Activate()
    {
        _attackInterval = defenceTankSpecs.interval;
        tankIndex = tankCount;
        tankCount++;
        OnTankCreated?.Invoke(this);
        _isActive = true;
    }

    public void Kill()
    {
        if(_gridTile == null)
            return;
        tankCount--;
        _isActive = false;
        OnDefenceTankKilled?.Invoke(this);
        gameObject.SetActive(false);
        _gridTile.defenceTank = null;
    }

    public void PhysicsTick()
    {
        if(!_isActive)
            return;
        _timer += Time.fixedDeltaTime;
        if(_timer > _attackInterval)
        {
            _timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        foreach (var direction in defenceTankSpecs.direction)
        {
            Bullet bul = ObjectPool.Instance.GetObject(_bullet.gameObject).GetComponent<Bullet>();
            bul.transform.position = transform.position;
            bul.Init(transform.position,direction,defenceTankSpecs);
        }
    }

    public void SetGridTile(GridTile gridTile)
    {
        _gridTile = gridTile;
    }
}