using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class ButtonActionsScript : MonoBehaviour, IPointerClickHandler
{
    private int i;

    [SerializeField]
    public TextMeshProUGUI wackyText;

    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;
    }

    private void Awake()
    {
        Debug.Log("Awake!");
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // Prevent event propagation to the Canvas
        eventData.Use();

        Debug.Log("OnPointerClick");
        i++;
        SetText($"Number is NOW {i}");
    } 
   
    private void SetText(string s)
    {
        if (wackyText != null)
        {
            wackyText.text = s;
        }
    }
}
