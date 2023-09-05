using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction plantAction;

   // [SerializeField] 
    public GameObject smallObjectPrefab;

    public Transform canvas;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        plantAction = playerInput.actions["Plant"];
    }

    private void OnEnable()
    {
        plantAction.performed += OnTouch;
    }

    private void OnDisable()
    {
        plantAction.performed -= OnTouch;
    }

    private void OnTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Create a plant!");
        CreatePlant(context.ReadValue<Vector2>());
    }
    
    private void CreatePlant(Vector2 uiPosition)
    {
        Debug.Log("Create a plant!");
        GameObject obj = Instantiate(smallObjectPrefab, canvas);
        var worldPoint = Camera.main.ScreenToWorldPoint(uiPosition);
        worldPoint.z = Camera.main.nearClipPlane;
        obj.transform.position = worldPoint;
    }
}
