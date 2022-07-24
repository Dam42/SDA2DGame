using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    const string HIGH_SCORE_KEY = "high_score";
    int currentScore, highScore;
    public int CurrentScore { get { return currentScore; } }
    public int HighScore { get { return highScore; } }

    [SerializeField] int scoreMultiplier = 100;
    float maxPositionY;
    bool firstUpdate;
    private void Awake()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        EventManager.PlayerLost += EventManager_PlayerFallenOff;
        EventManager.EnterGameplay += EventManager_EnterGameplay;
        EventManager.PlayerPositionUpdate += EventManager_PlayerPositionUpdate;
    }

    private void EventManager_EnterGameplay()
    {
        firstUpdate = true;
        currentScore = 0;
    }

    private void EventManager_PlayerPositionUpdate(Vector3 obj)
    {
        if(firstUpdate)
        {
            maxPositionY = obj.y;
            currentScore = 0;
            firstUpdate = false;
            return;
        }

        if(obj.y > maxPositionY)
        {
            float difference = obj.y - maxPositionY;
            currentScore += (int)(difference * scoreMultiplier);

            maxPositionY = obj.y;

            EventManager.OnUpdateScore(currentScore);
        }
    }

    private void EventManager_PlayerFallenOff()
    {
        SaveHighScore();
    }

    void SaveHighScore()
    {
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentScore);
            highScore = currentScore;
        }
    }

    private void OnDestroy()
    {
        EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
        EventManager.EnterGameplay -= EventManager_EnterGameplay;
        EventManager.PlayerLost -= EventManager_PlayerFallenOff;
    }
}
