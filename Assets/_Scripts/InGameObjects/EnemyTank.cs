using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTank : MonoBehaviour
{
    private Vector2 _moveDir = Vector2.down;
    private int _health;
    private float _speed;
    private bool _isActive;
    [SerializeField] private Rigidbody2D _rb;
    public EnemyTankSpecs enemyTankSpecs;
    public static int enemyTankCount;
    public static event Action<EnemyTank> OnEnemyCreated; 
    public static event Action<EnemyTank> OnEnemyKilled; 
    public static event Action OnEnemyReachedToLine; 
    public static event Action OnAllEnemiesDestroyed;

    public void Activate()
    {
        _health = enemyTankSpecs.health;
        SetPosition();
        gameObject.SetActive(true);
        _isActive = true;
        OnEnemyCreated?.Invoke(this);
    }

    private void SetPosition()
    {
        int column = SelectColumn();
        Vector3 gridPos = GridContainer.Instance.tiles[column].transform.position;
        transform.position = new Vector3(gridPos.x, gridPos.y + 2, 0);
    }

    private int SelectColumn()
    {
        int columnCount = (int)(GridContainer.Instance.rightMost - GridContainer.Instance.leftMost) + 1;
        return Random.Range(0, columnCount );
    }

    public void PhysicsTick()
    {
        if(!_isActive)
            return;
        _rb.MovePosition(_rb.position+_moveDir * enemyTankSpecs.speed * Time.fixedDeltaTime);
    }
    
    private void GetHit(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Explode();
    }

    private void Explode()
    {
        enemyTankCount--;
        if(enemyTankCount == 0)
            OnAllEnemiesDestroyed?.Invoke();
        OnEnemyKilled?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out DefenceTank defenceTank))
        {
            defenceTank.Kill();
        }

        if (col.TryGetComponent(out Bullet bullet))
        {
            bullet.Hit();
            GetHit(bullet.damage);
        }

        if (col.TryGetComponent(out DeadLine deadLine))
        {
            OnEnemyReachedToLine?.Invoke();
        }
    }


}