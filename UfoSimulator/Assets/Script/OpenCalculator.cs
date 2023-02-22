using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCalculator : MonoBehaviour
{
    public GameObject calculator;


    public void Open()
    {
       if(calculator != null)
        {
            bool isActive = calculator.activeSelf;

            calculator.SetActive(!isActive);
        }
    }
}
