using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField, Header("’e‚Ì‘¬‚³")] float _speed;
    Quaternion _dir;
    Rigidbody _rb;
    public Quaternion Dir { get { return _dir; } set { _dir = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _dir * new Vector3(0, 0, _speed);
    }
}
