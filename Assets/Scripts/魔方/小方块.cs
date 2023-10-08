using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class 小方块 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3Int 相对于魔方中心的偏移量;

    public void 更新偏移量(Axis axis, bool cw)
    {
        switch (axis)
        {
            case Axis.None:
                break;
            case Axis.X:
                更新X轴偏移量(cw);
                break;
            case Axis.Y:
                更新Y轴偏移量(cw);
                break;
            case Axis.Z:
                更新Z轴偏移量(cw);
                break;
            default:
                break;
        }
    }

    private void 更新Z轴偏移量(bool cw)
    {
        if (相对于魔方中心的偏移量.x == 0 && 相对于魔方中心的偏移量.y == 0) return;
        if (相对于魔方中心的偏移量.x == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.x += 相对于魔方中心的偏移量.y;
            }
            else
            {
                相对于魔方中心的偏移量.x -= 相对于魔方中心的偏移量.y;
            }
            相对于魔方中心的偏移量.y = 0;
        }
        else if (相对于魔方中心的偏移量.y == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.y -= 相对于魔方中心的偏移量.x;
            }
            else
            {
                相对于魔方中心的偏移量.y += 相对于魔方中心的偏移量.x;
            }
            相对于魔方中心的偏移量.x = 0;
        }
        else
        {
            if (cw)
            {
                if (相对于魔方中心的偏移量.x == 相对于魔方中心的偏移量.y)
                {
                    相对于魔方中心的偏移量.y = -相对于魔方中心的偏移量.x;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.x;
                    相对于魔方中心的偏移量.x = 相对于魔方中心的偏移量.y;
                    相对于魔方中心的偏移量.y = -temp;
                }
            }
            else
            {
                if (相对于魔方中心的偏移量.x == 相对于魔方中心的偏移量.y)
                {
                    相对于魔方中心的偏移量.x = -相对于魔方中心的偏移量.y;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.y;
                    相对于魔方中心的偏移量.y = 相对于魔方中心的偏移量.x;
                    相对于魔方中心的偏移量.x = -temp;
                }
            }
        }
    }

    private void 更新Y轴偏移量(bool cw)
    {
        if (相对于魔方中心的偏移量.x == 0 && 相对于魔方中心的偏移量.z == 0) return;
        if (相对于魔方中心的偏移量.x == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.x += 相对于魔方中心的偏移量.z;
            }
            else
            {
                相对于魔方中心的偏移量.x -= 相对于魔方中心的偏移量.z;
            }
            相对于魔方中心的偏移量.z = 0;
        }
        else if (相对于魔方中心的偏移量.z == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.z -= 相对于魔方中心的偏移量.x;
            }
            else
            {
                相对于魔方中心的偏移量.z += 相对于魔方中心的偏移量.x;
            }
            相对于魔方中心的偏移量.x = 0;
        }
        else
        {
            if (cw)
            {
                if (相对于魔方中心的偏移量.x == 相对于魔方中心的偏移量.z)
                {
                    相对于魔方中心的偏移量.z = -相对于魔方中心的偏移量.x;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.x;
                    相对于魔方中心的偏移量.x = 相对于魔方中心的偏移量.z;
                    相对于魔方中心的偏移量.z = -temp;
                }
            }
            else
            {
                if (相对于魔方中心的偏移量.x == 相对于魔方中心的偏移量.z)
                {
                    相对于魔方中心的偏移量.x = -相对于魔方中心的偏移量.z;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.z;
                    相对于魔方中心的偏移量.z = 相对于魔方中心的偏移量.x;
                    相对于魔方中心的偏移量.x = -temp;
                }
            }
        }
    }

    private void 更新X轴偏移量(bool cw)
    {
        if (相对于魔方中心的偏移量.y == 0 && 相对于魔方中心的偏移量.z == 0) return;
        if (相对于魔方中心的偏移量.y == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.y -= 相对于魔方中心的偏移量.z;
            }
            else
            {
                相对于魔方中心的偏移量.y += 相对于魔方中心的偏移量.z;
            }
            相对于魔方中心的偏移量.z = 0;
        }
        else if (相对于魔方中心的偏移量.z == 0)
        {
            if (cw)
            {
                相对于魔方中心的偏移量.z += 相对于魔方中心的偏移量.y;
            }
            else
            {
                相对于魔方中心的偏移量.z -= 相对于魔方中心的偏移量.y;
            }
            相对于魔方中心的偏移量.y = 0;
        }
        else
        {
            if (cw)
            {
                if (相对于魔方中心的偏移量.y == 相对于魔方中心的偏移量.z)
                {
                    相对于魔方中心的偏移量.y = -相对于魔方中心的偏移量.z;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.z;
                    相对于魔方中心的偏移量.z = 相对于魔方中心的偏移量.y;
                    相对于魔方中心的偏移量.y = -temp;
                }
            }
            else
            {
                if (相对于魔方中心的偏移量.y == 相对于魔方中心的偏移量.z)
                {
                    相对于魔方中心的偏移量.z = -相对于魔方中心的偏移量.y;
                }
                else
                {
                    int temp = 相对于魔方中心的偏移量.y;
                    相对于魔方中心的偏移量.y = 相对于魔方中心的偏移量.z;
                    相对于魔方中心的偏移量.z = -temp;
                }
            }
        }
    }
}
