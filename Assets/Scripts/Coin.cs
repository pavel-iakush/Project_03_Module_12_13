using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CollectCoinsAtTime _gameRules; 

    private void OnTriggerEnter(Collider other)
    {
        RigidbodyRoller player = other.GetComponent<RigidbodyRoller>();

        if (player != null)
        {
            gameObject.SetActive(false);
            _gameRules.AddCoinCounter();
        }
    }
}
