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
    private GameObject panelPilot;
 
    private void Awake()
    {     
       nameCharacter = GameObject.Find("UI_TextName").GetComponent<TMP_Text>();
       hpText = GameObject.Find("UI_TextHP").GetComponent<TMP_Text>();
        panelPilot = GameObject.Find("PilotBackGround");
    }

    private void Start()
    {
        panelPilot.SetActive(false);
    }

    private void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                if(panelPilot != null)
                {
                    panelPilot.SetActive(true);
                }
                selection = raycastHit.transform;
                nameCharacter.text = "NAME:" + raycastHit.collider.name;
            }
           
        }
        if (selection != null)
        {
            hpText.text = "PILOT HP:" + selection.gameObject.GetComponent<UfoMovement>().health.ToString();
        }
        else
        {
            panelPilot.SetActive(false);
        }
    }

   

}
