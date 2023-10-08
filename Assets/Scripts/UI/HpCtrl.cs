using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCtrl : MonoBehaviour
{
    public List<GameObject> Hearts;
    public CharacterData characterData;

    // Start is called before the first frame update
    void Start()
    {
    

    }
    private void OnEnable()
    {
        EventHandler.ChangeUIEvent += HpChange;
    }

    private void OnDisable()
    {
        EventHandler.ChangeUIEvent -= HpChange;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void HpChange(PlayerData character)
    {
        if (character.hp < 10 && character.hp >= 8) {
            Hearts[0].GetComponent<HpUI>().ChangeHpUI();
        }
        if (character.hp < 8 && character.hp >= 6)
        {
          
            Hearts[1].GetComponent<HpUI>().ChangeHpUI();
        }
        if (character.hp < 6 && character.hp >= 4)
        {
    
            Hearts[2].GetComponent<HpUI>().ChangeHpUI();
        }
        if (character.hp < 4 && character.hp >= 2)
        {

            Hearts[3].GetComponent<HpUI>().ChangeHpUI();
        }
        if (character.hp < 2 && character.hp >= 0)
        {
            Hearts[4].GetComponent<HpUI>().ChangeHpUI();
        }
    }



    
}
