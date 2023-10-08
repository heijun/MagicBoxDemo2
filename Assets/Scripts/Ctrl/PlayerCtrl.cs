using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator ani;
    // �����ĸ����������
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    Ray innerRay;
    public bool isup;
    public bool isdown;
    public bool isright;
    public bool isleft;

   
    // �������ߵĳ���
    private float rayLength = 0.6f;

    // �������ߵ���ɫ
    private Color rayColor = Color.red;

    // ����������ײ�Ĳ�
    private LayerMask rayLayer;

    private float innner_Length=0.1f;

    float time_up; float time_down; float time_right; float time_left;
    public bool ismove_up; public bool ismove_down; public bool ismove_right; public bool ismove_left;
    public void PlayAtkAnim()
    {
        if(ani.speed != 0)
        {
            ani.SetBool("ishurt", true);
           
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        isup = true;
        isright = true;
        isleft = true;
        isdown = true;
        // ����������ײ�Ĳ�Ϊ Default ��
        rayLayer = LayerMask.GetMask("ħ��");

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(transform.position);
        // ʹ�� Debug.DrawLine ���������ĸ����������
        Debug.DrawLine(upRay.origin, upRay.origin + upRay.direction * rayLength, rayColor);
        Debug.DrawLine(downRay.origin, downRay.origin + downRay.direction * rayLength, rayColor);
        Debug.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayLength, rayColor);
        Debug.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayLength, rayColor);


        Debug.DrawLine(innerRay.origin, innerRay.origin + innerRay.direction * 0.1f, rayColor);
        // �����ĸ� RaycastHit �������洢������ײ����Ϣ
        RaycastHit hitUp;
        RaycastHit hitDown;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        RaycastHit hitInner;


        // ����������ĵ㷢���ĸ���������ߣ��������������ת�ı䷽��
        upRay = new Ray(transform.position, transform.up);
        downRay = new Ray(transform.position, -transform.up);
        leftRay = new Ray(transform.position, -transform.right);
        rightRay = new Ray(transform.position, transform.right);

        innerRay = new Ray(transform.position, transform.forward);

        // ʹ�� Physics.Raycast ��������ĸ�����������Ƿ���ײ�����壬�������ײ��Ϣ
        if (Physics.Raycast(upRay, out hitUp, rayLength, rayLayer))
        {
            isup = false;
        }
        else {
            isup = true;
        }
        if (Physics.Raycast(downRay, out hitDown, rayLength, rayLayer))
        {
            isdown = false;
        }
        else {
            isdown =true;
        }
        if (Physics.Raycast(leftRay, out hitLeft, rayLength, rayLayer))
        {
            isleft = false;
        }
        else {
            isleft = true;
        
        }

        if (Physics.Raycast(rightRay, out hitRight, rayLength, rayLayer))
        {
            isright =false;
        }
        else {
            isright = true;
        }

      


        if (ħ��.Instance.�Ƿ�������ת == false)
        {


            if (Input.GetKeyDown(KeyCode.W) && isup&& !ismove_up && !ismove_left && !ismove_down && !ismove_right)
            {
                //����Ӧ������һ�����Ч��������ʵ�ֵĲ���
                // transform.position += transform.up;
      
                    transform.DOMove(transform.position + transform.up, 1F);
                    ismove_up = true;

            }
            if (ismove_up) {
                time_up += Time.deltaTime;
                if (time_up > 1f)
                {
                    time_up = 0;
                    ismove_up = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && isleft && !ismove_up && !ismove_left && !ismove_down && !ismove_right)
            {
                    transform.DOMove(transform.position - transform.right, 1F);
                    ismove_left = true;

            }

            if (ismove_left) {
                time_left += Time.deltaTime;
                if (time_left > 1f)
                {
                    time_left = 0;
                    ismove_left = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.S) && isdown && !ismove_up && !ismove_left && !ismove_down && !ismove_right)
            {
                    transform.DOMove(transform.position - transform.up, 1F);
                    ismove_down = true;

            }

            if (ismove_down) {
                time_down += Time.deltaTime;
                if (time_down > 1f)
                {
                    time_down = 0;
                    ismove_down = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.D) && isright && !ismove_up && !ismove_left && !ismove_down && !ismove_right)
            {

                    transform.DOMove(transform.position + transform.right, 1F);
                    ismove_right = true;

            }

            if (ismove_right) {
                time_right += Time.deltaTime;
                if (time_right > 1f)
                {
                    time_right = 0;
                    ismove_right = false;
                }
            }

            //�������Ҳ�������߼�⣬���ڸ�����ҵ�ƫ����
            if (Physics.Raycast(innerRay, out hitInner, innner_Length, rayLayer))
            {
                this.transform.GetComponent<С����>().�����ħ�����ĵ�ƫ���� = hitInner.collider.GetComponent<С����>().�����ħ�����ĵ�ƫ����;
            }

        }
    }



}
