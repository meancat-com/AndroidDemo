using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction buttonClickAction;
    [SerializeField]
    public GameObject smallObjectPrefab;
    public Transform canvasTransform;
    public TextMeshProUGUI wackyText;
    public Button helloButton;

    private int i;
    
    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        buttonClickAction = playerInput.actions.FindAction("ButtonClick");

    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
        buttonClickAction.performed += OnClick;
        //helloButton.onClick.AddListener(()=> OnClick(new InputAction.CallbackContext()));
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        TouchState value = context.ReadValue<TouchState>();
        Debug.Log($"touch pressed {value.position}");
        
        GameObject smallObject = Instantiate(smallObjectPrefab, canvasTransform);
        var world = Camera.main.ScreenToWorldPoint(value.position);
        world.z = Camera.main.nearClipPlane;
        smallObject.transform.position = world;
    }

    public void DoCLicky()
    {
        Debug.Log("TouchManager.DoClicky");
        i++;
        wackyText.text = "Number is " + i; 
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("TouchManager.OnClick");
        i++;
        wackyText.text = "Number is " + i;
    }
    
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        buttonClickAction.performed -= OnClick;
        helloButton.onClick.RemoveAllListeners();
    }
}
