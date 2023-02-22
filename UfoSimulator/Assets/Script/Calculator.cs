using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TMP_Text resultText;
    private bool pushButton = false;
    private int number = 0;

    public void AddNumber(int numeric)
    {
        if (number < 100 && pushButton == false)
        {
            number = number * 10 + numeric;
            resultText.text = number.ToString();
        }

    }

    public void CheckNumber()
    {
        pushButton = true;
        if (number <= 100 && number != 0)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                resultText.text = "MarkoPolo";
            }
            else if (number % 3 == 0)
            {
                resultText.text = "Marco";
            }
            else if (number % 5 == 0)
            {
                resultText.text = "Polo";
            }
            else
            {
                resultText.text = number.ToString();
            }
        }
        else
        {
            resultText.text = "Denied";
        }

        StartCoroutine(ClearText());
    }

    public void ClearNumber()
    {
        number = 0;
        resultText.text = "";
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2);
        number = 0;
        resultText.text = "";
        pushButton = false;
    }
}
