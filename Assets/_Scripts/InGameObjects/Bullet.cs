using System;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _isActive;
    private Vector2 _moveDir;
    private float _speed = 1;
    private float _range = 0;
    private float _timer;
    [SerializeField]private Rigidbody2D _rb;
    
    public int damage;
    public static event Action<Bullet> OnBulletCreated;
    public static event Action<Bullet> OnBulletDestroyed;

    private void OnEnable()
    {
        OnBulletCreated?.Invoke(this);
    }

    private void OnDisable()
    {
        OnBulletDestroyed?.Invoke(this);
    }

    public void Init(Vector2 pos, Vector2 dir, DefenceTankSpecs spec)
    {
        transform.rotation = Quaternion.Euler(0,0,Vector2.SignedAngle(Vector2.up, dir));
        _range = spec.range;
        _isActive = true;
        transform.position = pos;
        damage = spec.damage;
        _moveDir = dir;
        _timer = 0;
    }

    public void PhysicsTick()
    {
        if(!_isActive)
            return;
        _rb.MovePosition(_rb.position+_moveDir * _speed * Time.fixedDeltaTime);
        _timer += Time.fixedDeltaTime;
        if(_timer > _range)
        {
            Hit();
        }
    }

    public void Hit()
    {
        _isActive = false;
        ObjectPool.Instance.ReturnGameObject(gameObject);
    }
}