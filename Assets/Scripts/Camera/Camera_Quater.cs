using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera_Quater : MonoBehaviour
{
    [Header("카메라")]
    [SerializeField] private Camera _camera;

    [Header("플레이어")]
    [SerializeField] private Transform _player;


    private float sharpness = 5f;
    private float lookHeight = 2f;
    private Vector3 quarterOffset = new Vector3(0f, 8f, -3f);
    private Transform _camTr;
    private bool snap = true;


    void Start()
    {
        if (_camera == null)
        {
            GameObject mainCamGo = GameObject.FindGameObjectWithTag("MainCamera");

            if (mainCamGo != null)
            {
                _camera = mainCamGo.GetComponent<Camera>();
            }
        }

        _camTr = _camera.transform;
        InitQuarter();

    }


    void Update()
    {
        if (_player == null || _camTr == null)
        {
            return;
        }


        TickQuarter();

    }



    private void InitQuarter()
    {
        Vector3 desiredPos;
        Quaternion desiredRot;

        BuildQuarterPose(out desiredPos, out desiredRot);

        ApplyPos(desiredPos, desiredRot, sharpness, snap);

    }


    private void TickQuarter()
    {
        Vector3 desiredPos;
        Quaternion desiredRot;

        BuildQuarterPose(out desiredPos, out desiredRot);

        ApplyPos(desiredPos, desiredRot, sharpness, false);

    }


    private void BuildQuarterPose(out Vector3 desiredPos, out Quaternion desiredRot)
    {
        
        desiredPos = _player.position + quarterOffset;
               
        Vector3 lookPos = _player.position + Vector3.up * lookHeight;
               
        Vector3 lookDir = lookPos - desiredPos;


        desiredRot = Quaternion.LookRotation(lookPos - desiredPos, Vector3.up);


    }


    private float GetSmoothT(float sharpness)
    {
        return 1f - Mathf.Exp(-sharpness * Time.deltaTime);
    }


    private void ApplyPos(Vector3 desiredPos, Quaternion desiredRot, float sharpness, bool snap)
    {
        if (snap)
        {
            _camTr.position = desiredPos;
            _camTr.rotation = desiredRot;

            return;
        }


        float t = GetSmoothT(sharpness);

        _camTr.position = Vector3.Lerp(_camTr.position, desiredPos, t);
        _camTr.rotation = Quaternion.Slerp(_camTr.rotation, desiredRot, t);

    }

}
