using UnityEngine;
using System.Collections;
using TMPro;
public class Timer_TimeToWin : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] int TimeCounter = 100;
    
    [SerializeField] GameObject LostPanel;
    [SerializeField] private UIManager uiManager;
    
    public void StartTimer()
    {
        StartCoroutine(AfterOneSecond());
    }

    IEnumerator AfterOneSecond()
    {
        while(TimeCounter > 0)
        //for (int i = 0; i < 10; i++)
        {
            TimeCounter--;
            textTimer.text = TimeCounter.ToString();
            yield return new WaitForSeconds(1f);
        }
        
            textTimer.text = "0";
            LostPanel.SetActive(true);
        
    }
    
}
    

