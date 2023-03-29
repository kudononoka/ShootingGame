using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField, Header("’e¶¬êŠ")] Transform[] _spawnTrans;
    [SerializeField, Header("Emeny’ePrefab")] GameObject _bulletPrefab;
    [SerializeField, Header("¶¬‚ÌƒCƒ“ƒ^[ƒoƒ‹")] float _spawnTime;
    float _timer;
    float _angle;
    // Start is called before the first frame update
    void Start()
    {
        _angle = 45 / (_spawnTime - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnTime)
        {
            Spawn();
            _timer = 0;
        }

        if (_timer < _spawnTime - 0.5)
        {
            transform.Rotate(0, _angle * Time.deltaTime, 0);
        }
        
    }

    void Spawn()
    {
        for(int i = 0; i < _spawnTrans.Length; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _spawnTrans[i].position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().Dir = Quaternion.LookRotation(_spawnTrans[i].transform.forward);
            
        }
    }
}
