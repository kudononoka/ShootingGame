using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�ڒn����p�̃X�N���v�g</summary>
public class Ground : MonoBehaviour
{
    /// <summary>True��������ڒn���Ă��܂�</summary>
    bool _isGround;
    [SerializeField, Tooltip("�ڒn����̂��߂�Ray�̒���")] float _rayLength;
    [SerializeField] LayerMask _layerMask;
    public bool IsGround => _isGround;
    
    void Update()
    {
        Ray ray = new Ray(transform.position,-transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayLength,_layerMask) && !_isGround)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;  
        }
    }
}
