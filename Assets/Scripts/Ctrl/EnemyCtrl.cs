using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyCtrl :MonoBehaviour
{
    public Animator ani;
    public GameObject player;

    public Button �Ի�;
    public Button ս��;

    // �����ĸ����������
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    // �������ߵĳ���
    private float rayLength = 1.2f;

    // �������ߵ���ɫ
    private Color rayColor = Color.red;

    // ����������ײ�Ĳ�
    private LayerMask rayLayer;

    Vector3 euler;


    // ���������¼����������岻ͬ��Ϊ�Ĳ�ͬ��Ӧ
    public event Action<Collider> OnRayEnter;
    public event Action<Collider> OnRayStay;
    public event Action<Collider> OnRayExit;
    // ����������һ������ɨ��������
    public Collider previousCollider_left;
    // ����������һ������ɨ��������
    public Collider previousCollider_right;
    // ����������һ������ɨ��������
    public Collider previousCollider_up;
    // ����������һ������ɨ��������
    public Collider previousCollider_down;

    public void PlayAtkAnim()
    {
        ani.SetBool("isatk", true);
    }

    public void PlayHurtAnim()
    {
        ani.SetBool("ishurt", true);

    }


    // �¼������� ��Ҫ���õķ���
    public void IsHurtEventTrigger()
    {

        ani.SetBool("ishurt", false);
    }

    public void IsAtkEventTrigger()
    {
        �Ի�.gameObject.SetActive(true);
        ս��.gameObject.SetActive(true);
        ani.SetBool("isatk", false);
    }
    private void Start()
    {
        // ����������ײ�Ĳ�Ϊ Default ��
        rayLayer = LayerMask.GetMask("ħ��");
        OnRayEnter += colliderEnter;
        OnRayStay += colliderStay;
        OnRayExit += colliderExit;
    }
    void Update()
    {
        Debug.Log(rayLength);
        // ʹ�� Debug.DrawLine ���������ĸ����������
        Debug.DrawLine(upRay.origin, upRay.origin + upRay.direction * rayLength, rayColor);
        Debug.DrawLine(downRay.origin, downRay.origin + downRay.direction * rayLength, rayColor);
        Debug.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayLength, rayColor);
        Debug.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayLength, rayColor);

        Debug.Log(player.transform.localEulerAngles.z);

        // �����ĸ� RaycastHit �������洢������ײ����Ϣ
        RaycastHit hitUp;
        RaycastHit hitDown;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        // ����������ĵ㷢���ĸ���������ߣ��������������ת�ı䷽��
        upRay = new Ray(transform.position, transform.up);
        downRay = new Ray(transform.position, -transform.up);
        leftRay = new Ray(transform.position, -transform.right);
        rightRay = new Ray(transform.position, transform.right);

        Physics.Raycast(upRay, out hitUp, rayLength, rayLayer);

        CollisionProcess_up(hitUp.collider);


        Physics.Raycast(downRay, out hitDown, rayLength, rayLayer);

        CollisionProcess_down(hitDown.collider);

        Physics.Raycast(rightRay, out hitRight, rayLength, rayLayer);

        CollisionProcess_right(hitRight.collider);

        Physics.Raycast(leftRay, out hitLeft, rayLength, rayLayer);

        CollisionProcess_left(hitLeft.collider);




    }


    private void CollisionProcess_left(Collider current)
    {

        // ִ�������뿪���崥�����¼�
        // ����ڵ�ǰ֡�У�����û����ײ���κ����壬�����ڼ�¼�б��浽��ײ�岻Ϊ�գ��ʹ���������Ľ���������ײ�¼�
        if (current == null)
        {
            if (previousCollider_left != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_left);
                previousCollider_left = null;
            }

        }

        // ����ͣ����ĳ������ʱ�������¼�
        // �����ǰ������ײ���������һ��������ײ��������ͬ���򴥷�����ͣ���¼�
        else if (previousCollider_left == current)
        {
            OnRayStay?.Invoke(current);
        }

        // ���߸����¼�
        // �����ǰ���ߺ���һ��������ײ�����岻��ͬһ��������һ�����崥�������뿪�¼�����ǰ���崥��������ײ�¼�
        else if (previousCollider_left != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_left);
        }
        // ���֮ǰ֡��û��������ײ�����壬��ǰ֡��������ײ�����壬�򴥷����¼���
        else
        {
            if (current != null && current.gameObject.tag == "player")
            {
                // no collider on last frame
                OnRayEnter?.Invoke(current);
            }
        }

        if (current != null && current.gameObject.tag == "player")
        {
            // ����ǰ������ײ�����屣��Ϊ ��һ����ײ������
            previousCollider_left = current;
        }

    }

    private void CollisionProcess_right(Collider current)
    {

        // ִ�������뿪���崥�����¼�
        // ����ڵ�ǰ֡�У�����û����ײ���κ����壬�����ڼ�¼�б��浽��ײ�岻Ϊ�գ��ʹ���������Ľ���������ײ�¼�
        if (current == null)
        {
            if (previousCollider_right != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_right);
                previousCollider_right = null;
            }

        }

        // ����ͣ����ĳ������ʱ�������¼�
        // �����ǰ������ײ���������һ��������ײ��������ͬ���򴥷�����ͣ���¼�
        else if (previousCollider_right == current)
        {
            OnRayStay?.Invoke(current);
        }

        // ���߸����¼�
        // �����ǰ���ߺ���һ��������ײ�����岻��ͬһ��������һ�����崥�������뿪�¼�����ǰ���崥��������ײ�¼�
        else if (previousCollider_right != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_right);
        }
        // ���֮ǰ֡��û��������ײ�����壬��ǰ֡��������ײ�����壬�򴥷����¼���
        else
        {
            if (current != null && current.gameObject.tag == "player")
            {
                // no collider on last frame
                OnRayEnter?.Invoke(current);
            }
        }

        if (current != null && current.gameObject.tag == "player")
        {
            // ����ǰ������ײ�����屣��Ϊ ��һ����ײ������
            previousCollider_right = current;
        }

    }


    private void CollisionProcess_up(Collider current)
    {

        // ִ�������뿪���崥�����¼�
        // ����ڵ�ǰ֡�У�����û����ײ���κ����壬�����ڼ�¼�б��浽��ײ�岻Ϊ�գ��ʹ���������Ľ���������ײ�¼�
        if (current == null)
        {
            if (previousCollider_up != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_up);
                previousCollider_up = null;
            }

        }

        // ����ͣ����ĳ������ʱ�������¼�
        // �����ǰ������ײ���������һ��������ײ��������ͬ���򴥷�����ͣ���¼�
        else if (previousCollider_up == current)
        {
            OnRayStay?.Invoke(current);
        }

        // ���߸����¼�
        // �����ǰ���ߺ���һ��������ײ�����岻��ͬһ��������һ�����崥�������뿪�¼�����ǰ���崥��������ײ�¼�
        else if (previousCollider_up != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_up);
        }
        // ���֮ǰ֡��û��������ײ�����壬��ǰ֡��������ײ�����壬�򴥷����¼���
        else
        {
            if (current != null && current.gameObject.tag == "player")
            {
                // no collider on last frame
                OnRayEnter?.Invoke(current);
            }
        }

        if (current != null && current.gameObject.tag == "player")
        {
            // ����ǰ������ײ�����屣��Ϊ ��һ����ײ������
            previousCollider_up = current;
        }

    }


    private void CollisionProcess_down(Collider current)
    {

        // ִ�������뿪���崥�����¼�
        // ����ڵ�ǰ֡�У�����û����ײ���κ����壬�����ڼ�¼�б��浽��ײ�岻Ϊ�գ��ʹ���������Ľ���������ײ�¼�
        if (current == null)
        {
            if (previousCollider_down != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_down);
                previousCollider_down = null;
            }

        }

        // ����ͣ����ĳ������ʱ�������¼�
        // �����ǰ������ײ���������һ��������ײ��������ͬ���򴥷�����ͣ���¼�
        else if (previousCollider_down == current)
        {
            OnRayStay?.Invoke(current);
        }

        // ���߸����¼�
        // �����ǰ���ߺ���һ��������ײ�����岻��ͬһ��������һ�����崥�������뿪�¼�����ǰ���崥��������ײ�¼�
        else if (previousCollider_down != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_down);
        }
        // ���֮ǰ֡��û��������ײ�����壬��ǰ֡��������ײ�����壬�򴥷����¼���
        else
        {
            if (current != null && current.gameObject.tag == "player")
            {
                // no collider on last frame
                OnRayEnter?.Invoke(current);
            }
        }

        if (current != null && current.gameObject.tag == "player")
        {
            // ����ǰ������ײ�����屣��Ϊ ��һ����ײ������
            previousCollider_down = current;
        }

    }







    void colliderEnter(Collider collider) {
        Debug.Log(345);
        FightMgr.Instance.Enemy = this.gameObject;
        FightMgr.Instance.enemyData = (EnemyData)GetComponent<SkillCtrl>().playerData;
        //collider.GetComponent<BoxCollider>().enabled = false;//ע�⣬����뿪�����Ҫ����ײ��enabled=true,��ʱδд

    
        transform.eulerAngles = player.transform.eulerAngles;

         �Ի�.gameObject.SetActive(true);
         ս��.gameObject.SetActive(true);


    }

    void colliderStay(Collider collider)
    {
        euler = transform.eulerAngles;
        Debug.Log(675);

        //collider.GetComponent<BoxCollider>().enabled = false;
    }
    void colliderExit(Collider collider)
    {
        if (euler == player.transform.eulerAngles) {
            // collider.GetComponent<BoxCollider>().enabled = true;
            �Ի�.gameObject.SetActive(false);
            ս��.gameObject.SetActive(false);
        }



    }

}
