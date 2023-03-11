using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    //////////////カーソルの方に向かって移動する時に使う変数/////////////
    Plane _plane = new Plane();
    float pos;
    Vector3 _cursorPos;
    Vector3 _frontframeCursorPos;
    /////////////////////////////////////////////////////////////////////
    
    Rigidbody _rb;
    [SerializeField, Tooltip("歩行速度")] float _walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルの方に向かって移動するようにした
        //カメラからレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //無限の平面をPlayerと同じ高さに設定
        _plane.SetNormalAndPosition(Vector3.up, transform.position);
        //レイが平面に当たった場合、当たった場所を取得
        if(_plane.Raycast(ray, out pos))
        { 
            _cursorPos = ray.GetPoint(pos);
        }
        //前フレームと比べてカーソルを動かしている時かつオブジェクトとカーソルが同じ位置にいない時
        if (_frontframeCursorPos != _cursorPos && Vector3.Distance(transform.position, _cursorPos) > 4)
        {
            //カーソルの方に向きを変える
            transform.LookAt(_cursorPos);
        }
        float z = Input.GetAxisRaw("Vertical");
        _rb.velocity = transform.rotation * new Vector3(0, 0, z * _walkSpeed);
        _frontframeCursorPos = _cursorPos;
    }
}
