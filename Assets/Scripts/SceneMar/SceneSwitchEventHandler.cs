using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneSwitchEventHandler
{

     public static Action<string> SwitchScenes;

       public static void CallSwitchScenes(string targetScene){
       SwitchScenes?.Invoke(targetScene);
       }

}
