using System;
using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillName", menuName = "创建技能", order = 1)]
public class SkillData : ScriptableObject
{
   
    public BaseSkillEffect skillEffect;
    /// <summary>
    /// 父技能名
    /// </summary>
    public string skillParentName;
    /// <summary>
    /// 技能名
    /// </summary>
    public string skillName;

    /// <summary>
    /// 技能类型
    /// </summary>
    public SkillType skillType;

    /// <summary>
    /// 技能目标
    /// </summary>
    public SkillTarget skillTarget;


    /// <summary>
    /// Skill效果
    /// </summary>
    //public SkillEffect skillEffect;

    public int level;

    /// <summary>
    /// 是否是治疗
    /// </summary>
    public bool heal;

    public bool unlock;

    public bool isreleased;
    public Skill ToSkill()
    {
        return new Skill()
        {
            SkillParentName = skillParentName,
            SkillName = skillName,
            SkillType = skillType,
            SkillTarget = skillTarget,
            //SkillEffect = skillEffect,
            Heal = heal,
            Unlock = unlock,
            Level = level

        };
    }


    public void ReleaseSkill(CharacterData playerData,CharacterData enemyData) {
        if (skillEffect != null) {
            skillEffect.ReleaseSkill(playerData,enemyData);
        }

    
    }



}


public class Skill
{
    public string SkillParentName;
    /// <summary>
    /// 技能名
    /// </summary>
    public string SkillName;

    /// <summary>
    /// 技能类型
    /// </summary>
    public SkillType SkillType;

    /// <summary>
    /// 技能目标
    /// </summary>
    public SkillTarget SkillTarget;


    /// <summary>
    /// Skill效果
    /// </summary>
    //public SkillEffect SkillEffect;


    public int Level;
    /// <summary>
    /// 是否是治疗
    /// </summary>
    public bool Heal;

    public bool Unlock;
}

[Serializable]
public enum SkillType : byte
{
    主动 = 0,
    被动 = 1
}

[Serializable]
public enum SkillTarget : byte
{
    我方 = 0,
    鬼魂类 = 1,
    吸血鬼类=2,
    僵尸类=3
}

/*[Serializable]
public enum SkillEffect : byte
{
    伤害 = 0,
    治疗 = 1,
    增益 = 2,
    减益 = 3,
    控制 = 4,
}*/
