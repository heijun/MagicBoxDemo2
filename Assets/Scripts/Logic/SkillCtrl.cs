using System.Collections;

using UnityEngine;


public class SkillCtrl : MonoBehaviour
{
    public BaseSkillEffect SkillEffect;

    public CharacterData playerData;
    public void AddSkill(SkillData skillData)
    {
        playerData.skills.Add(skillData);
    }

    public void RemoveSkill(SkillData skillData)
    {
        playerData.skills.Remove(skillData);
    }

    public void ChooseSkill(SkillData skillData)
    {
        if (!playerData.skills.Contains(skillData)) {
            AddSkill(skillData);
        }
   
        if (skillData.ToSkill().Level == playerData.level)
        {
           SkillEffect.skill = skillData.ToSkill();
            Debug.Log(SkillEffect.skill.SkillName);
        }

    }
}
