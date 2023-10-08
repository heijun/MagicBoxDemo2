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

    public Button 对话;
    public Button 战斗;

    // 定义四个方向的射线
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    // 定义射线的长度
    private float rayLength = 1.2f;

    // 定义射线的颜色
    private Color rayColor = Color.red;

    // 定义射线碰撞的层
    private LayerMask rayLayer;

    Vector3 euler;


    // 定义三个事件，用来定义不同行为的不同相应
    public event Action<Collider> OnRayEnter;
    public event Action<Collider> OnRayStay;
    public event Action<Collider> OnRayExit;
    // 用来保存上一个射线扫到的物体
    public Collider previousCollider_left;
    // 用来保存上一个射线扫到的物体
    public Collider previousCollider_right;
    // 用来保存上一个射线扫到的物体
    public Collider previousCollider_up;
    // 用来保存上一个射线扫到的物体
    public Collider previousCollider_down;

    public void PlayAtkAnim()
    {
        ani.SetBool("isatk", true);
    }

    public void PlayHurtAnim()
    {
        ani.SetBool("ishurt", true);

    }


    // 事件触发后 将要调用的方法
    public void IsHurtEventTrigger()
    {

        ani.SetBool("ishurt", false);
    }

    public void IsAtkEventTrigger()
    {
        对话.gameObject.SetActive(true);
        战斗.gameObject.SetActive(true);
        ani.SetBool("isatk", false);
    }
    private void Start()
    {
        // 设置射线碰撞的层为 Default 层
        rayLayer = LayerMask.GetMask("魔方");
        OnRayEnter += colliderEnter;
        OnRayStay += colliderStay;
        OnRayExit += colliderExit;
    }
    void Update()
    {
        Debug.Log(rayLength);
        // 使用 Debug.DrawLine 方法绘制四个方向的射线
        Debug.DrawLine(upRay.origin, upRay.origin + upRay.direction * rayLength, rayColor);
        Debug.DrawLine(downRay.origin, downRay.origin + downRay.direction * rayLength, rayColor);
        Debug.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayLength, rayColor);
        Debug.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayLength, rayColor);

        Debug.Log(player.transform.localEulerAngles.z);

        // 定义四个 RaycastHit 变量来存储射线碰撞的信息
        RaycastHit hitUp;
        RaycastHit hitDown;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        // 从物体的中心点发出四个方向的射线，并根据物体的旋转改变方向
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

        // 执行射线离开物体触发的事件
        // 如果在当前帧中，射线没有碰撞到任何物体，并且在记录中保存到碰撞体不为空，就触发该物体的结束射线碰撞事件
        if (current == null)
        {
            if (previousCollider_left != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_left);
                previousCollider_left = null;
            }

        }

        // 射线停留在某个物体时触发的事件
        // 如果当前射线碰撞的物体和上一个射线碰撞到物体相同，则触发射线停留事件
        else if (previousCollider_left == current)
        {
            OnRayStay?.Invoke(current);
        }

        // 射线更新事件
        // 如果当前射线和上一个射线碰撞的物体不是同一个，则上一个物体触发射线离开事件，当前物体触发射线碰撞事件
        else if (previousCollider_left != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_left);
        }
        // 如果之前帧中没有射线碰撞的物体，当前帧有射线碰撞到物体，则触发此事件。
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
            // 将当前射线碰撞的物体保存为 上一个碰撞的物体
            previousCollider_left = current;
        }

    }

    private void CollisionProcess_right(Collider current)
    {

        // 执行射线离开物体触发的事件
        // 如果在当前帧中，射线没有碰撞到任何物体，并且在记录中保存到碰撞体不为空，就触发该物体的结束射线碰撞事件
        if (current == null)
        {
            if (previousCollider_right != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_right);
                previousCollider_right = null;
            }

        }

        // 射线停留在某个物体时触发的事件
        // 如果当前射线碰撞的物体和上一个射线碰撞到物体相同，则触发射线停留事件
        else if (previousCollider_right == current)
        {
            OnRayStay?.Invoke(current);
        }

        // 射线更新事件
        // 如果当前射线和上一个射线碰撞的物体不是同一个，则上一个物体触发射线离开事件，当前物体触发射线碰撞事件
        else if (previousCollider_right != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_right);
        }
        // 如果之前帧中没有射线碰撞的物体，当前帧有射线碰撞到物体，则触发此事件。
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
            // 将当前射线碰撞的物体保存为 上一个碰撞的物体
            previousCollider_right = current;
        }

    }


    private void CollisionProcess_up(Collider current)
    {

        // 执行射线离开物体触发的事件
        // 如果在当前帧中，射线没有碰撞到任何物体，并且在记录中保存到碰撞体不为空，就触发该物体的结束射线碰撞事件
        if (current == null)
        {
            if (previousCollider_up != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_up);
                previousCollider_up = null;
            }

        }

        // 射线停留在某个物体时触发的事件
        // 如果当前射线碰撞的物体和上一个射线碰撞到物体相同，则触发射线停留事件
        else if (previousCollider_up == current)
        {
            OnRayStay?.Invoke(current);
        }

        // 射线更新事件
        // 如果当前射线和上一个射线碰撞的物体不是同一个，则上一个物体触发射线离开事件，当前物体触发射线碰撞事件
        else if (previousCollider_up != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_up);
        }
        // 如果之前帧中没有射线碰撞的物体，当前帧有射线碰撞到物体，则触发此事件。
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
            // 将当前射线碰撞的物体保存为 上一个碰撞的物体
            previousCollider_up = current;
        }

    }


    private void CollisionProcess_down(Collider current)
    {

        // 执行射线离开物体触发的事件
        // 如果在当前帧中，射线没有碰撞到任何物体，并且在记录中保存到碰撞体不为空，就触发该物体的结束射线碰撞事件
        if (current == null)
        {
            if (previousCollider_down != null)
            {
                Debug.Log(233);
                OnRayExit?.Invoke(previousCollider_down);
                previousCollider_down = null;
            }

        }

        // 射线停留在某个物体时触发的事件
        // 如果当前射线碰撞的物体和上一个射线碰撞到物体相同，则触发射线停留事件
        else if (previousCollider_down == current)
        {
            OnRayStay?.Invoke(current);
        }

        // 射线更新事件
        // 如果当前射线和上一个射线碰撞的物体不是同一个，则上一个物体触发射线离开事件，当前物体触发射线碰撞事件
        else if (previousCollider_down != null)
        {
            OnRayEnter?.Invoke(current);
            OnRayExit?.Invoke(previousCollider_down);
        }
        // 如果之前帧中没有射线碰撞的物体，当前帧有射线碰撞到物体，则触发此事件。
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
            // 将当前射线碰撞的物体保存为 上一个碰撞的物体
            previousCollider_down = current;
        }

    }







    void colliderEnter(Collider collider) {
        Debug.Log(345);
        FightMgr.Instance.Enemy = this.gameObject;
        FightMgr.Instance.enemyData = (EnemyData)GetComponent<SkillCtrl>().playerData;
        //collider.GetComponent<BoxCollider>().enabled = false;//注意，如果离开检测需要让碰撞体enabled=true,暂时未写

    
        transform.eulerAngles = player.transform.eulerAngles;

         对话.gameObject.SetActive(true);
         战斗.gameObject.SetActive(true);


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
            对话.gameObject.SetActive(false);
            战斗.gameObject.SetActive(false);
        }



    }

}
