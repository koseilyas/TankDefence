using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private WaitForSeconds _oneSecond = new WaitForSeconds(1);
    [SerializeField] private GameObject _explosionPrefab;

    private void OnEnable()
    {
        EnemyTank.OnEnemyKilled += EnemyTankKilled;
        DefenceTank.OnDefenceTankKilled += DefenceTankKilled;
    }
    
    private void OnDisable()
    {
        EnemyTank.OnEnemyKilled -= EnemyTankKilled;
        DefenceTank.OnDefenceTankKilled -= DefenceTankKilled;
    }

    void EnemyTankKilled(EnemyTank tank)
    {
        CreateExplosionAnimation(tank.transform.position);
    }

    void DefenceTankKilled(DefenceTank tank)
    {
        CreateExplosionAnimation(tank.transform.position);
    }

    public void CreateExplosionAnimation(Vector3 pos)
    {
        var exp = ObjectPool.Instance.GetObject(_explosionPrefab);
        exp.transform.position = pos;
        StartCoroutine(DisableExplosion(exp));
    }

    private IEnumerator DisableExplosion(GameObject exp)
    {
        yield return _oneSecond;
        ObjectPool.Instance.ReturnGameObject(exp);
    }
}
