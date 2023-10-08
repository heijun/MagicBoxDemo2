using System.Collections;
using UnityEngine;

public class BaseSkillEffect : MonoBehaviour
{
 
    public Skill skill;
    public virtual void ReleaseSkill(CharacterData playerData,CharacterData enemyData) {

        Debug.Log("释放技能");
    }

}
