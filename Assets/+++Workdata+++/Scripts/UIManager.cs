using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI textCoinCount;
      
      [SerializeField] GameObject LostPanel;
      [SerializeField] GameObject WinPanel;
      
      [SerializeField] Button buttonRestartGame;
      
      private void Start()
      {
          LostPanel.SetActive(false);
          WinPanel.SetActive(false);
          buttonRestartGame.onClick.AddListener(RestartGame);
      }
  
      void RestartGame()
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
      
      public void UpdateTextCoinCount(int newCount)
      {
          textCoinCount.text = newCount.ToString();
      }
  
      public void ShowPanelLost()
      {
          LostPanel.SetActive(true);
      }
}
