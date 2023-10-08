using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<PlayerData> ChangeUIEvent;

    public static void CallChangeUIEvent(PlayerData character)
    {
        Debug.Log("����HP����");
        ChangeUIEvent?.Invoke(character);
    }

    public static event Action SayDialogEvent;

    public static void CallSayDialogEvent()
    {
      
       SayDialogEvent?.Invoke();
    }
}

