using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Vector3 _playerforwerd;
    Quaternion _dre;
    [SerializeField, Tooltip("スピード")] float _moveSpeed;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerforwerd = GameObject.FindWithTag("Player").transform.forward.normalized;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        _dre = Quaternion.LookRotation(_playerforwerd);
        _rb.velocity =  _dre * new Vector3(0,0,_moveSpeed);
    }
}
