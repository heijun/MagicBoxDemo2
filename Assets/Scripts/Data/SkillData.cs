using System;
using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillName", menuName = "��������", order = 1)]
public class SkillData : ScriptableObject
{
   
    public BaseSkillEffect skillEffect;
    /// <summary>
    /// ��������
    /// </summary>
    public string skillParentName;
    /// <summary>
    /// ������
    /// </summary>
    public string skillName;

    /// <summary>
    /// ��������
    /// </summary>
    public SkillType skillType;

    /// <summary>
    /// ����Ŀ��
    /// </summary>
    public SkillTarget skillTarget;


    /// <summary>
    /// SkillЧ��
    /// </summary>
    //public SkillEffect skillEffect;

    public int level;

    /// <summary>
    /// �Ƿ�������
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
    /// ������
    /// </summary>
    public string SkillName;

    /// <summary>
    /// ��������
    /// </summary>
    public SkillType SkillType;

    /// <summary>
    /// ����Ŀ��
    /// </summary>
    public SkillTarget SkillTarget;


    /// <summary>
    /// SkillЧ��
    /// </summary>
    //public SkillEffect SkillEffect;


    public int Level;
    /// <summary>
    /// �Ƿ�������
    /// </summary>
    public bool Heal;

    public bool Unlock;
}

[Serializable]
public enum SkillType : byte
{
    ���� = 0,
    ���� = 1
}

[Serializable]
public enum SkillTarget : byte
{
    �ҷ� = 0,
    ����� = 1,
    ��Ѫ����=2,
    ��ʬ��=3
}

/*[Serializable]
public enum SkillEffect : byte
{
    �˺� = 0,
    ���� = 1,
    ���� = 2,
    ���� = 3,
    ���� = 4,
}*/
