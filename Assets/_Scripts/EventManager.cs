using UnityEngine;

public static class EventManager
{
    #region Button Events
    public static event System.Action EnterGameplay;
    public static void EnterGameplayButton()
    {
        EnterGameplay?.Invoke();
    }
    #endregion

    #region Player Events
    public static event System.Action<Vector3> PlayerPositionUpdate;
    public static event System.Action PlayerLost;
    public static void OnUpdatePlayerPosition(Vector3 position)
    {
        if (PlayerPositionUpdate != null)
        {
            PlayerPositionUpdate(position);
        }
    }
    public static void OnPlayerLost()
    {
        if (PlayerLost != null)
        {
            PlayerLost();
        }
    }
    #endregion

    #region Score Events
    public static event System.Action<int> CurrentScoreUpdated;
    public static void OnUpdateScore(int score)
    {
        if(CurrentScoreUpdated != null)
        {
            CurrentScoreUpdated(score);
        }
    }
    #endregion

    #region Enemy Events

    public static event System.Action EnemyHitPlayer;
    public static event System.Action EnemyDied;

    public static void OnEnemeyHitPlayer()
    {
        if (EnemyHitPlayer != null)
            EnemyHitPlayer();
    }

    public static void OnEnemeyDeath()
    {
        if (EnemyDied != null)
            EnemyDied();
    }

    #endregion
}
