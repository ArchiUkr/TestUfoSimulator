using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UfoUI : MonoBehaviour
{
    private TMP_Text hpText;
    private TMP_Text nameCharacter;

    private void Awake()
    {
        hpText = GameObject.Find("UI_TextHP").GetComponent<TMP_Text>();
        nameCharacter = GameObject.Find("UI_TextName").GetComponent<TMP_Text>();

    }

    private void OnMouseDown()
    {
        nameCharacter.text = "NAME:" + name;
        hpText.text = "PILOT HP:" + gameObject.GetComponent<UfoMovement>().health.ToString();
    }
}
