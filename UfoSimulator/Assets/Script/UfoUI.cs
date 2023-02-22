using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UfoUI : MonoBehaviour
{    
    private TMP_Text nameCharacter;
    private TMP_Text hpText;
    private RaycastHit raycastHit;
    private Transform selection;
    private void Awake()
    {     
        nameCharacter = GameObject.Find("UI_TextName").GetComponent<TMP_Text>();
        hpText = GameObject.Find("UI_TextHP").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            if (Input.GetMouseButtonDown(0))
            {
              
                hpText.text = "PILOT HP:" + raycastHit.collider.GetComponent<UfoMovement>().health.ToString();
                nameCharacter.text = "NAME:" + raycastHit.collider.name;
                selection = raycastHit.transform;
            }
           
        }

    }

    public void CheckHP()
    {
        if (selection != null)
        {
            hpText.text = "PILOT HP:" + selection.gameObject.GetComponent<UfoMovement>().health.ToString();
        }
    }

}
