using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>接地判定用のスクリプト</summary>
public class Ground : MonoBehaviour
{
    /// <summary>Trueだったら接地しています</summary>
    bool _isGround;
    [SerializeField, Tooltip("接地判定のためのRayの長さ")] float _rayLength;
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
