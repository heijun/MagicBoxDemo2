using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator ani;
    // 定义四个方向的射线
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    Ray innerRay;
    public bool isup;
    public bool isdown;
    public bool isright;
    public bool isleft;

   
    // 定义射线的长度
    private float rayLength = 0.6f;

    // 定义射线的颜色
    private Color rayColor = Color.red;

    // 定义射线碰撞的层
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
        // 设置射线碰撞的层为 Default 层
        rayLayer = LayerMask.GetMask("魔方");

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(transform.position);
        // 使用 Debug.DrawLine 方法绘制四个方向的射线
        Debug.DrawLine(upRay.origin, upRay.origin + upRay.direction * rayLength, rayColor);
        Debug.DrawLine(downRay.origin, downRay.origin + downRay.direction * rayLength, rayColor);
        Debug.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayLength, rayColor);
        Debug.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayLength, rayColor);


        Debug.DrawLine(innerRay.origin, innerRay.origin + innerRay.direction * 0.1f, rayColor);
        // 定义四个 RaycastHit 变量来存储射线碰撞的信息
        RaycastHit hitUp;
        RaycastHit hitDown;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        RaycastHit hitInner;


        // 从物体的中心点发出四个方向的射线，并根据物体的旋转改变方向
        upRay = new Ray(transform.position, transform.up);
        downRay = new Ray(transform.position, -transform.up);
        leftRay = new Ray(transform.position, -transform.right);
        rightRay = new Ray(transform.position, transform.right);

        innerRay = new Ray(transform.position, transform.forward);

        // 使用 Physics.Raycast 方法检测四个方向的射线是否碰撞到物体，并输出碰撞信息
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

      


        if (魔方.Instance.是否正在旋转 == false)
        {


            if (Input.GetKeyDown(KeyCode.W) && isup&& !ismove_up && !ismove_left && !ismove_down && !ismove_right)
            {
                //这里应该是玩家缓动的效果，这里实现的不对
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

            //玩家往里也发出射线检测，用于更新玩家的偏移量
            if (Physics.Raycast(innerRay, out hitInner, innner_Length, rayLayer))
            {
                this.transform.GetComponent<小方块>().相对于魔方中心的偏移量 = hitInner.collider.GetComponent<小方块>().相对于魔方中心的偏移量;
            }

        }
    }



}
