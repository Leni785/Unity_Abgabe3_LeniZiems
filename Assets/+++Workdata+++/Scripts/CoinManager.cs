using UnityEngine;

public class CoinManager : MonoBehaviour
{
    
    [SerializeField] private int coinCounter = 0;
    [SerializeField] private UIManager uiManager;

    public void AddCoin()
    {
        coinCounter++;
        uiManager.UpdateTextCoinCount(coinCounter);
    }
}

