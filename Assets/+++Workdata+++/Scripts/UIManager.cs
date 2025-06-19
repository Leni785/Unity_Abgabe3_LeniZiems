using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI textFlyCount;
  [SerializeField] TextMeshProUGUI textGoldenFlyCount;
  
  [SerializeField] TextMeshProUGUI WintextFlyCount;
  [SerializeField] TextMeshProUGUI WintextGoldenFlyCount;
  
      [Header("Panels")]   
      [SerializeField] GameObject MenuPanel;
      [SerializeField] GameObject StartPanel;
      [SerializeField] GameObject LostPanel;
      [SerializeField] GameObject WinPanel;
      
      [Header("Buttons")] 
      [SerializeField] Button buttonStartGame;
      [SerializeField] Button buttonRestartGame;
      
      [Header("Countdown")] 
      [SerializeField] TextMeshProUGUI textCountdown;
      [SerializeField] int TimeCounter = 3;
      
      [Header("Movement")] [SerializeField] private CharacterController characterController;
      [Header("Timer")] [SerializeField] private Timer_TimeToWin timerTime;
      [SerializeField] TextMeshProUGUI textTimer;
      

      
      private void Start()
      {
          MenuPanel.SetActive(true);
          StartPanel.SetActive(false);
          LostPanel.SetActive(false);
          WinPanel.SetActive(false);
          
          characterController.enabled = false;
          
          buttonStartGame.onClick.AddListener(StartGame);
          buttonRestartGame.onClick.AddListener(RestartGame);
      }
  
      
      void StartGame()
      {
          MenuPanel.SetActive(false);
          StartPanel.SetActive(true);
          StartCoroutine(AfterOneSecond());
      }
      
      IEnumerator AfterOneSecond()
      {
          while(TimeCounter > 0)
          {
              TimeCounter--;
              textCountdown.text = TimeCounter.ToString();
              yield return new WaitForSeconds(1f);
          }
        
          textCountdown.text = "0";
          Destroy(textCountdown.gameObject);
          characterController.enabled = true;
          timerTime.StartTimer();
      }
      
      
      void RestartGame()
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
      
      public void UpdateTextCoinCount(int newCount)
      {
          textFlyCount.text = newCount.ToString();
          WintextFlyCount.text = newCount.ToString();
      }
      
      public void UpdateTextDiamondCount(int newCount)
      {
          textGoldenFlyCount.text = newCount.ToString();
          WintextGoldenFlyCount.text = newCount.ToString();
          
      }
  
      public void ShowLostPanel()
      {
          LostPanel.SetActive(true);
      }
      
      public void ShowWinPanel()
      {
          WinPanel.SetActive(true);
          Destroy(textTimer.gameObject);
          characterController.enabled = false;
      }
      
}
