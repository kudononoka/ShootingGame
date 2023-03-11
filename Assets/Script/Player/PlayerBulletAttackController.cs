using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletAttackController : MonoBehaviour
{
    [SerializeField, Tooltip("�e��Prefab")] GameObject _bulletPrefab;
    [SerializeField, Tooltip("�e�ې���Intervaltime")] float _bulletInstanceInterval;
    float _timer;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            BulletInstantiate();
        }
    }

    void BulletInstantiate()
    {
        _timer += Time.deltaTime;
        if(_timer > _bulletInstanceInterval)
        {
            Instantiate(_bulletPrefab,transform.position,Quaternion.identity);
            _timer = 0;
        }
    }
}
