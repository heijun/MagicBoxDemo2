using System.Collections;

using UnityEngine;

public class 僵尸攻击 : BaseSkillEffect
{

    public override void ReleaseSkill(CharacterData playerData, CharacterData enemyData)
    {
        Debug.Log("怪物释放技能");

    }


}
