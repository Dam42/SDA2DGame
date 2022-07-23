using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event System.Action EnterGameplay;
    public static event System.Action<Vector3> PlayerPositionUpdate;
    public static event System.Action<int> CurrentScoreUpdated;
    public static event System.Action PlayerFallenOff;
    public static void EnterGameplayButton()
    {
        EnterGameplay?.Invoke();
    }

    public static void OnUpdatePlayerPosition(Vector3 position)
    {
        if (PlayerPositionUpdate != null)
        {
            PlayerPositionUpdate(position);
        }
    }

    public static void OnUpdateScore(int score)
    {
        if(CurrentScoreUpdated != null)
        {
            CurrentScoreUpdated(score);
        }
    }

    public static void OnPlayerFallenOff()
    {
        if (PlayerFallenOff != null)
        {
            PlayerFallenOff();
        }
    }
}
