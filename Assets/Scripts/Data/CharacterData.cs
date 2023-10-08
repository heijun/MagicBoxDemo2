using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterData : ScriptableObject
{

    /// <summary>
    /// 角色名
    /// </summary>
    public string characterName;

    public byte selftag;
    /// <summary>
    /// 角色血量
    /// </summary>
    public int hp;

    /// <summary>
    /// 角色攻击力
    /// </summary>
    public int atk;

    /// <summary>
    /// 角色防御力
    /// </summary>
     public int def;

    /// <summary>
    /// 角色魔法抗性
    /// </summary>
    public int magicdef;

    /// <summary>
    /// 角色魔法攻击
    /// </summary>
    public int magicatk;

    /// <summary>
    /// 角色魔法攻击概率
    /// </summary>
    [Range(0, 100)] public int magicRate;

    public bool canMagic;

    /// <summary>
    /// 角色等级
    /// </summary>
    public int level;

    /// <summary>
    /// 技能
    /// </summary>
    public List<SkillData> skills;


    /// <summary>
    /// 角色是否死亡
    /// </summary>
    public bool Dead => hp <= 0;
}

