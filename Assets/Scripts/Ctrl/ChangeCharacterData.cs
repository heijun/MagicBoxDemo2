using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterData : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") {

            other.GetComponent<SkillCtrl>().playerData.magicatk += 5;
        }

        if (other.tag == "enemy") {
            if (other.GetComponent<SkillCtrl>().playerData.def - 5 > 0)
            {
                other.GetComponent<SkillCtrl>().playerData.def -= 5;
            }
            else {
                other.GetComponent<SkillCtrl>().playerData.def =0;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {

            other.GetComponent<SkillCtrl>().playerData.magicatk -= 5;
        }
        if (other.tag == "enemy")
        {

                other.GetComponent<SkillCtrl>().playerData.def += 5;
        }
    }
}
