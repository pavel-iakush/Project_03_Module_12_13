using UnityEngine;

public class CollectCoinsAtTime : MonoBehaviour
{
    [SerializeField] private float _countdown;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject[] _coinsArray;

    private int _coinsToVictory;

    private void Awake()
    {
        _coinsToVictory = _coinsArray.Length;
    }

    private void Update()
    {
        _countdown -= Time.deltaTime;
        PrintCountdownTimer();

        if (WinConditionComplete())
        {
            VictoryMessage();
            PauseGame();
        }

        if (FailConditionComplete())
        {
            FailMessage();
            PauseGame();
        }
    }

    private void PauseGame()
        => Time.timeScale = 0.0f;

    private void VictoryMessage()
        => Debug.Log("Victory!");

    private void FailMessage()
        => Debug.Log("Failed..");

    private void PrintCountdownTimer()
        => Debug.Log($"Timeleft: {_countdown}");

    private bool WinConditionComplete()
        => _wallet.CollectedCoins == _coinsToVictory;

    private bool FailConditionComplete()
        => _countdown <= 0;
}
