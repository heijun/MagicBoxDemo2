using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterName", menuName = "�������", order = 1)]
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
            bellevel = Bellevel.ʥĸ;
        }
        else if (defeatnum > 0 && defeatnum <= 5)
        {
            bellevel = Bellevel.�º�;
        }
        else if (defeatnum < 10)
        {
            bellevel = Bellevel.��ս;
        }
        if (defeatnum == 10||(defeatnum > 5&& defeatmerchant))
        {
            bellevel = Bellevel.���Ⱥ�ս;
        }
    }
}


[Serializable]
public enum Bellevel : byte
{
    ʥĸ = 0,
    �º� = 1,
    ��ս = 2,
    ���Ⱥ�ս = 3
}
