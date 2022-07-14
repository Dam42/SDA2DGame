using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event System.Action EnterGameplay;

    public static void EnterGameplayButton()
    {
        EnterGameplay?.Invoke();
    }
}
