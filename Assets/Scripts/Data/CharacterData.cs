using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterData : ScriptableObject
{

    /// <summary>
    /// ��ɫ��
    /// </summary>
    public string characterName;

    public byte selftag;
    /// <summary>
    /// ��ɫѪ��
    /// </summary>
    public int hp;

    /// <summary>
    /// ��ɫ������
    /// </summary>
    public int atk;

    /// <summary>
    /// ��ɫ������
    /// </summary>
     public int def;

    /// <summary>
    /// ��ɫħ������
    /// </summary>
    public int magicdef;

    /// <summary>
    /// ��ɫħ������
    /// </summary>
    public int magicatk;

    /// <summary>
    /// ��ɫħ����������
    /// </summary>
    [Range(0, 100)] public int magicRate;

    public bool canMagic;

    /// <summary>
    /// ��ɫ�ȼ�
    /// </summary>
    public int level;

    /// <summary>
    /// ����
    /// </summary>
    public List<SkillData> skills;


    /// <summary>
    /// ��ɫ�Ƿ�����
    /// </summary>
    public bool Dead => hp <= 0;
}

