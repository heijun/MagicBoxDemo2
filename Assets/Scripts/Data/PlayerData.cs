using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterName", menuName = "创建玩家", order = 1)]
public class PlayerData : CharacterData
{
    public Bellevel bellevel;

    public int exp;

    public int defeatnum;

    public bool defeatmerchant;

    public void ChangeBellevel()
    {

/*        character.Atk = atk;
        character.Def = def;
        character.MagicDef = magicdef;
        character.MagicAtk = magicatk;*/
        if (defeatnum == 0)
        {
            bellevel = Bellevel.圣母;
        }
        else if (defeatnum > 0 && defeatnum <= 5)
        {
            bellevel = Bellevel.温和;
        }
        else if (defeatnum < 10)
        {
            bellevel = Bellevel.好战;
        }
        if (defeatnum == 10||(defeatnum > 5&& defeatmerchant))
        {
            bellevel = Bellevel.极度好战;
        }
    }
}


[Serializable]
public enum Bellevel : byte
{
    圣母 = 0,
    温和 = 1,
    好战 = 2,
    极度好战 = 3
}
