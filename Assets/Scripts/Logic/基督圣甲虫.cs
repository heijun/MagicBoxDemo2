using System.Collections;

using UnityEngine;


public class 基督圣甲虫 : BaseSkillEffect
{

    public override void ReleaseSkill(CharacterData playerData, CharacterData enemyData)
    {

            if (skill != null) {
             

                if (skill.SkillName == "基督圣甲虫")
                {
                    var magicatk = playerData.magicatk;
                    if (playerData.canMagic)
                    {
                        playerData.atk += 2 * playerData.magicatk;

                        playerData.magicatk = 0;
                  
                    }
                    else
                    {
                        playerData.magicatk = magicatk;
                  
                    }



                }

   
            }
  
    }
}
