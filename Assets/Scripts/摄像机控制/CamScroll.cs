using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamScroll : MonoBehaviour
{

    public int maxdis;
    public int mindis;
    private void Update()
    {

            CameraFOV();
    
    }
    /// <summary>
    /// ���ֿ�������ӽ�����
    /// </summary>
    public void CameraFOV()
    {
        //��ȡ�����ֵĻ�����
        float wheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 40;


        this.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance += wheel;

        if (this.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance < mindis) {
            this.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = mindis;
        }

        if (this.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance >maxdis)
        {
            this.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = maxdis;
        }
    }
}
