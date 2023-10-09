using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

/// <summary>
/// 相机观察器
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
        //注意!!! 此处是 GetMouseButton() 表示一直长按鼠标左键；不是 GetMouseButtonDown()
        if (Input.GetMouseButton(1))
        {
    
            //控制相机绕中心点(centerPoint)水平旋转
            _mainCamera.transform.RotateAround(centerPoint, Vector3.up, _mouseX * rotateSpeed);

            //控制相机绕中心点垂直旋转(！注意此处的旋转轴时相机自身的x轴正方向！)
            _mainCamera.transform.RotateAround(centerPoint, -_mainCamera.transform.right, _mouseY * rotateSpeed);

            //记录相机绕中心点垂直旋转的总角度
            angle += _mouseY * rotateSpeed;

            //如果总角度超出指定范围，结束这一帧（！用于解决相机旋转到模型底部的Bug！）
            //（这样做其实还有小小的Bug，能发现的网友麻烦留言告知解决办法或其他更好的方法）
            if (angle > maxRotAngle || angle < minRotAngle)
            {
                return;
            }


        }
    }

/*    /// <summary>
    /// 这个鼠标缩放是长按鼠标中键拖动的，实际使用有问题，需要改
    /// </summary>
    /// <param name="_mouseX"></param>
    /// <param name="_mouseY"></param>
    public void CameraMove(float _mouseX, float _mouseY)
    {
        if (Input.GetMouseButton(2))
        {
*//*            //加载小手的资源图片
            Texture2D cursorTex = Utils.LoadTexture("hand");

            //鼠标图标换成自定义小手
            Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);*//*

            //相机位置的偏移量（Vector3类型，实现原理是：向量的加法）
            Vector3 moveDir = (_mouseX * -_mainCamera.transform.right + _mouseY * -_mainCamera.transform.forward);

            //限制y轴的偏移量
            moveDir.y = 0;
            _mainCamera.transform.position += moveDir * 0.5f;
        }
*//*        else
        {
            //鼠标恢复默认图标，置null即可
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }*//*
    }*/
}
