using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    //public Sprite BlackHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
   public void ChangeHpUI() {
        GetComponent<Image>().color = new Color(1,1,1,1);
    
   }


}
