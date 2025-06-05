using UnityEngine;
using System.Collections;
using TMPro;
public class Timer : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] int TimeCounter = 10;
    
    [SerializeField] GameObject LostPanel;
    
    void Start()
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
    

