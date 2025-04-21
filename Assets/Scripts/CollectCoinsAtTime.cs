using UnityEngine;

public class CollectCoinsAtTime : MonoBehaviour
{
    [SerializeField] private float _countdown;
    private int _collectedCoins = 0;
    private int _coinsToVictory = 10;

    private void Update()
    {
        _countdown -= Time.deltaTime;
        PrintCountdownTimer();

        if (_collectedCoins == _coinsToVictory)
        {
            VictoryMessage();
            PauseGame();
        }

        if (_countdown <= 0)
        {
            FailMessage();
            PauseGame();
        }
    }

    public void AddCoinCounter()
    {
        _collectedCoins += 1;
    }

    private void PauseGame()
        => Time.timeScale = 0.0f;

    private void VictoryMessage()
        => Debug.Log("Victory!");

    private void FailMessage()
        => Debug.Log("Failed..");

    private void PrintCountdownTimer()
        => Debug.Log($"Timeleft: {_countdown}");
}
