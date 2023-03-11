using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    //////////////�J�[�\���̕��Ɍ������Ĉړ����鎞�Ɏg���ϐ�/////////////
    Plane _plane = new Plane();
    float pos;
    Vector3 _cursorPos;
    Vector3 _frontframeCursorPos;
    /////////////////////////////////////////////////////////////////////
    
    Rigidbody _rb;
    [SerializeField, Tooltip("���s���x")] float _walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\���̕��Ɍ������Ĉړ�����悤�ɂ���
        //�J�������烌�C���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //�����̕��ʂ�Player�Ɠ��������ɐݒ�
        _plane.SetNormalAndPosition(Vector3.up, transform.position);
        //���C�����ʂɓ��������ꍇ�A���������ꏊ���擾
        if(_plane.Raycast(ray, out pos))
        { 
            _cursorPos = ray.GetPoint(pos);
        }
        //�O�t���[���Ɣ�ׂăJ�[�\���𓮂����Ă��鎞���I�u�W�F�N�g�ƃJ�[�\���������ʒu�ɂ��Ȃ���
        if (_frontframeCursorPos != _cursorPos && Vector3.Distance(transform.position, _cursorPos) > 4)
        {
            //�J�[�\���̕��Ɍ�����ς���
            transform.LookAt(_cursorPos);
        }
        float z = Input.GetAxisRaw("Vertical");
        _rb.velocity = transform.rotation * new Vector3(0, 0, z * _walkSpeed);
        _frontframeCursorPos = _cursorPos;
    }
}