using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物体上下浮动+旋转效果
/// </summary>
public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // 上下移动的幅度
    public float frequency = 1f; // 上下移动的频率
    public float rotationSpeed = 10f; // 绕 Y 轴旋转的速度

    private Vector3 _initialPosition; // 物品的初始位置

    private void Start()
    {
        _initialPosition = transform.position; // 保存物品的初始位置
    }

    private void Update()
    {
        // 根据时间和幅度计算物品下一帧的位置
        float newY = _initialPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 让物品绕 Y 轴旋转
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);
    }
}
