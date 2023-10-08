using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������¸���+��תЧ��
/// </summary>
public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // �����ƶ��ķ���
    public float frequency = 1f; // �����ƶ���Ƶ��
    public float rotationSpeed = 10f; // �� Y ����ת���ٶ�

    private Vector3 _initialPosition; // ��Ʒ�ĳ�ʼλ��

    private void Start()
    {
        _initialPosition = transform.position; // ������Ʒ�ĳ�ʼλ��
    }

    private void Update()
    {
        // ����ʱ��ͷ��ȼ�����Ʒ��һ֡��λ��
        float newY = _initialPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // ����Ʒ�� Y ����ת
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);
    }
}
