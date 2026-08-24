using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("플레이어")]
    [SerializeField] private Transform _player;

    [Header("카메라")]
    [SerializeField] private Camera _camera;

    [Header("이동속도")]
    [SerializeField] private float _speed = 3f;

    [Header("구르기 거리")]
    [SerializeField] private float _rollSpeed = 10f;

    [Header("구르기 시간")]
    [SerializeField] private float _rollTime = 0.3f;

    [Header("캐릭터 애니메이션")]
    [SerializeField] private Animator _animator;



    private bool _isrolling = false;
    private float _timer;
    

    void Start()
    {
        
    }



    void Update()
    {
        Move();
        LookMouse();
    }


    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, 0f, v);
        Vector3 dir = move.normalized;

        transform.position += dir * _speed * Time.deltaTime;


        if(move.magnitude == 0)
        {
            _animator.SetFloat("Speed", 0f);
        }
        else if(_speed < 8f)
        {
            _animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            _animator.SetFloat("Speed", 1.0f);
        }











        if (_isrolling)
        {
            _timer += Time.deltaTime;

            float t = _timer / _rollTime;

            float _rolling = Mathf.Lerp(_rollSpeed, 2f, t);

            _player.position += dir * _rolling * Time.deltaTime;

            if (_timer >= _rollTime)
            {
                _isrolling = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("구르기");

            _timer = 0f;
            _isrolling = true;

        }



    }



    private void LookMouse()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 lookDir = hit.point - _player.position;
            lookDir.y = 0f;

            if(lookDir != Vector3.zero)
            {
                _player.rotation = Quaternion.LookRotation(lookDir);
            }


        }




    }





}
