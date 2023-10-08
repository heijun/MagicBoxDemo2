using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchScene : MonoBehaviour
{
    public string scenename;
    GameObject Canvas;
    GameObject FightMgr;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("player");
        Canvas = GameObject.FindGameObjectWithTag("ui");
        FightMgr = GameObject.Find("FightMgr");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") {
            SwitchScene(scenename);
        }
    }

    public void SwitchScene(string sceneName)
    {
        DontDestroyOnLoad(Canvas);
        DontDestroyOnLoad(FightMgr);
        player.transform.SetParent(null);
        DontDestroyOnLoad(player);

        Debug.Log("wai");
        SceneSwitchEventHandler.CallSwitchScenes(sceneName);
    }
}
