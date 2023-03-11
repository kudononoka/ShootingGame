using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    PlayerMoveController _playerMoveScript;
    Quaternion _forwerd;
    [SerializeField, Tooltip("スピード")] float _moveSpeed;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMoveScript = GameObject.Find("Player").GetComponent<PlayerMoveController>();
        _forwerd = Quaternion.LookRotation(_playerMoveScript.CursorPos);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _forwerd * new Vector3(0,0,_moveSpeed);
    }
}
