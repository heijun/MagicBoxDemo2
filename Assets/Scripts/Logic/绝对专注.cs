using System.Collections;

using UnityEngine;


public class 绝对专注 : BaseSkillEffect
{

    public override void ReleaseSkill(CharacterData playerData, CharacterData enemyData)
    {

            if (skill != null) {
              

                if (skill.SkillName == "绝对专注")
                {
                    enemyData.def -= 2;
                  

                }
   
            }
  
    }
}
