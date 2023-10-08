using System.Collections;
using UnityEngine;


public class LoadScene : MonoBehaviour
{

    public void SwitchScene(string sceneName)
    {
        SceneSwitchEventHandler.CallSwitchScenes(sceneName);
    }

}
