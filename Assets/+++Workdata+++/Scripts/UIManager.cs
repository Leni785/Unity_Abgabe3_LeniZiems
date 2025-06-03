using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI textCoinCount;
      
      [SerializeField] GameObject PanelLost;
      
      [SerializeField] Button buttonRestartGame;
      
      private void Start()
      {
          PanelLost.SetActive(false);
          buttonRestartGame.onClick.AddListener(RestartGame);
      }
  
      void RestartGame()
      {
          // gerade aktive Scene neu laden
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
      
      public void UpdateTextCoinCount(int newCount)
      {
          textCoinCount.text = newCount.ToString();
      }
  
      public void ShowPanelLost()
      {
          PanelLost.SetActive(true);
      }
}
