using UnityEngine;
using System.Collections;
using TMPro;
public class Timer : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] private int TimeCounter = 0;
    void Start()
    {
        Debug.Log(message: "Start");
        StartCoroutine(AfterOneSecond());
    }

    IEnumerator AfterOneSecond()
    {
        Debug.Log(message: "Schleife ANFANG");
        
        
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(message: "Ich habe eine Schleife geschrieben" + i);
            Debug.Log(message: "one second later...");
            TimeCounter++;
            textTimer.text = TimeCounter.ToString();
            yield return new WaitForSeconds(1f);
        }
        Debug.Log(message: "Schleife ENDE");
        
       
    }
    
}
    

