using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Arduino : MonoBehaviour
{
    

    public Text text;

    
    

    void   Start()
    {
         StartCoroutine(Wait());
       
        
    }
    void Print_Text(int value)
    {
        text.text = value.ToString(); 
       Rect GraphRect;
    float xSize = 0.5f * Screen.width;
    float ySize = 0.1f * Screen.height;
    float xPos = 0.2f * Screen.width;
    float yPos = 0.05f * Screen.height;

    GraphRect = new Rect(xPos, yPos, xSize, ySize);
    GraphManager.Graph.Plot("Test_ScreenSpace", value, Color.green, GraphRect);
   }

    IEnumerator Wait()
    {
        int value = Random.Range(60, 90);
        Debug.Log("Hi1");
        yield return new WaitForSeconds(0.5f);
        Print_Text(value);
        StartCoroutine(Wait());
        Debug.Log("hi2");

        
    }

}

