using UnityEngine;

public class CollectCoinsAtTime : MonoBehaviour
{
    [SerializeField] private float _countdown;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject[] _coinsArray;

    private int _coinsToWin;

    private void Awake()
    {
        _coinsToWin = _coinsArray.Length;
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

        if (LoseConditionComplete())
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
        => _wallet.CollectedCoins == _coinsToWin;

    private bool LoseConditionComplete()
        => _countdown <= 0;
}
