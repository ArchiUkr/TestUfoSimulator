using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCalculator : MonoBehaviour
{
    public GameObject calculator;


    private void Awake()
    {
        calculator.SetActive(false);
    }

    public void Open()
    {
       if(calculator != null)
        {
            bool isActive = calculator.activeSelf;

            calculator.SetActive(!isActive);
        }
    }
}
