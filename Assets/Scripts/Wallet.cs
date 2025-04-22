using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _collectedCoins = 0;

    public int CollectedCoins => _collectedCoins;

    public void AddCoin()
        => _collectedCoins++;
}
