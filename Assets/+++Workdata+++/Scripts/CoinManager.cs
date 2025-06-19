using UnityEngine;

public class CoinManager : MonoBehaviour
{
    
    [SerializeField] private int flyCounter = 0;
    [SerializeField] private int GoldenFlyCounter = 0;
    [SerializeField] private UIManager uiManager;

    public void AddCoin()
    {
        flyCounter++;
        uiManager.UpdateTextCoinCount(flyCounter);
    }
    
    public void AddDiamond()
    {
        GoldenFlyCounter++;
        uiManager.UpdateTextDiamondCount(GoldenFlyCounter);
    }
}

