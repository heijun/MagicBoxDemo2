using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTrigger : MonoBehaviour
{

    public Canvas Key;
    Canvas key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") {
 
            Vector2 pos = Camera.main.ScreenToViewportPoint(transform.position);
            Destroy(gameObject);
            key= Instantiate(Key);
            key.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
