using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "player")
        {
            Debug.Log("nij");

      
            transform.DOLocalMoveY(transform.localPosition.y +0.4f, 2f);
             if (GetComponent<Animator>().GetBool("istrigger") != true)
             {
                   GetComponent<Animator>().SetBool("istrigger", true);
             }
             else {
                    Debug.Log("°¡¹þ¹þ");
                GetComponent<Animator>().SetBool("istrigger", false);
            }
        }
    }

    public void UnableColider() {

        GetComponent<BoxCollider>().enabled = false;
    }


}
