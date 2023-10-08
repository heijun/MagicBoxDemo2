using System.Collections;

using UnityEngine;


public class 猎魂感官 : BaseSkillEffect
{

    public override void ReleaseSkill(CharacterData playerData, CharacterData enemyData)
    {

            if (skill != null) {
                if (skill.SkillName == "猎魂感官")
                {
                    var atk = playerData.atk;
                    if ((byte)skill.SkillTarget == enemyData.selftag)
                    {

                        playerData.atk += 1;
                  
                    }
                    else
                    {
                        playerData.atk = atk;
                   
                    }

                }
   
            }
  
    }
}
