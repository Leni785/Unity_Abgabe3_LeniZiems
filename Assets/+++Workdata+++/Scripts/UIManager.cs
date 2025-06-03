using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI textCoinCount;
      
      [SerializeField] GameObject MenuPanel;
      [SerializeField] GameObject StartPanel;
      [SerializeField] GameObject LostPanel;
      [SerializeField] GameObject WinPanel;
      
      [SerializeField] Button buttonStartGame;
      [SerializeField] Button buttonRestartGame;
      
      private void Start()
      {
          MenuPanel.SetActive(true);
          StartPanel.SetActive(false);
          LostPanel.SetActive(false);
          WinPanel.SetActive(false);
          
          buttonStartGame.onClick.AddListener(StartGame);
          buttonRestartGame.onClick.AddListener(RestartGame);
      }
  
      
      void StartGame()
      {
          MenuPanel.SetActive(false);
          StartPanel.SetActive(true);
      }
      
      void RestartGame()
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
      
      public void UpdateTextCoinCount(int newCount)
      {
          textCoinCount.text = newCount.ToString();
      }
  
      public void ShowLostPanel()
      {
          LostPanel.SetActive(true);
      }
      
      public void ShowWinPanel()
      {
          WinPanel.SetActive(true);
      }
}
