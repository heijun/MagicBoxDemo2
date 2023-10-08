using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayCtrl : MonoBehaviour
{
    [Header("npc名字，需与Block名字一致")]
    public string npcName;

    private Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        EventHandler.SayDialogEvent += Say;
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
   
        
    }

    void Say()
    {
            if (flowchart.HasBlock(npcName))
            {
                flowchart.ExecuteBlock(npcName);
            }
    }

}
