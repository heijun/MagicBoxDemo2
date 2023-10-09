using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

/// <summary>
/// ����۲���
/// </summary>
public class CameraViewer : MonoBehaviour
{
    public float rotateSpeed=2;
    private Vector3 centerPoint;
    private float minRotAngle=-360f;
    private float maxRotAngle=360f;
    private float angle;
    public Camera _mainCamera;

    private void Start()
    {
        centerPoint = Vector3.zero;


    }

    private void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        float _mouseY = Input.GetAxis("Mouse Y");
        CameraRotate(_mouseX, _mouseY);
       // CameraMove(_mouseX, _mouseY);
    }

    public void CameraRotate(float _mouseX, float _mouseY)
    {
        //ע��!!! �˴��� GetMouseButton() ��ʾһֱ���������������� GetMouseButtonDown()
        if (Input.GetMouseButton(1))
        {
    
            //������������ĵ�(centerPoint)ˮƽ��ת
            _mainCamera.transform.RotateAround(centerPoint, Vector3.up, _mouseX * rotateSpeed);

            //������������ĵ㴹ֱ��ת(��ע��˴�����ת��ʱ��������x��������)
            _mainCamera.transform.RotateAround(centerPoint, -_mainCamera.transform.right, _mouseY * rotateSpeed);

            //��¼��������ĵ㴹ֱ��ת���ܽǶ�
            angle += _mouseY * rotateSpeed;

            //����ܽǶȳ���ָ����Χ��������һ֡�������ڽ�������ת��ģ�͵ײ���Bug����
            //����������ʵ����СС��Bug���ܷ��ֵ������鷳���Ը�֪����취���������õķ�����
            if (angle > maxRotAngle || angle < minRotAngle)
            {
                return;
            }


        }
    }

/*    /// <summary>
    /// �����������ǳ�������м��϶��ģ�ʵ��ʹ�������⣬��Ҫ��
    /// </summary>
    /// <param name="_mouseX"></param>
    /// <param name="_mouseY"></param>
    public void CameraMove(float _mouseX, float _mouseY)
    {
        if (Input.GetMouseButton(2))
        {
*//*            //����С�ֵ���ԴͼƬ
            Texture2D cursorTex = Utils.LoadTexture("hand");

            //���ͼ�껻���Զ���С��
            Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);*//*

            //���λ�õ�ƫ������Vector3���ͣ�ʵ��ԭ���ǣ������ļӷ���
            Vector3 moveDir = (_mouseX * -_mainCamera.transform.right + _mouseY * -_mainCamera.transform.forward);

            //����y���ƫ����
            moveDir.y = 0;
            _mainCamera.transform.position += moveDir * 0.5f;
        }
*//*        else
        {
            //���ָ�Ĭ��ͼ�꣬��null����
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }*//*
    }*/
}
