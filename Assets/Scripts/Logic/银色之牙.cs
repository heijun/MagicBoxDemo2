using System.Collections;

using UnityEngine;


public class 银色之牙 : BaseSkillEffect
{

    public override void ReleaseSkill(CharacterData playerData, CharacterData enemyData)
    {

            if (skill != null) {
           

                if (skill.SkillName == "银色之牙")
                {
                    var atk = playerData.atk;
                    if ((byte)skill.SkillTarget == enemyData.selftag)
                    {

                        playerData.atk += 2;
                  
                    }
                    else
                    {
                        playerData.atk = atk;
                     
                    }
                }

      
   
            }
  
    }
}
