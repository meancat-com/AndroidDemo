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
        plantAction.performed += CreatePlant;
    }

    private void OnDisable()
    {
        plantAction.performed -= CreatePlant;
    }

    private void CreatePlant(InputAction.CallbackContext context)
    {
        Debug.Log("Create a plant!");
        var tapPos = context.ReadValue<Vector2>();
        Debug.Log($"clicked at {tapPos}");
        GameObject obj = Instantiate(smallObjectPrefab, canvas);
        var worldPoint = Camera.main.ScreenToWorldPoint(tapPos);
        worldPoint.z = Camera.main.nearClipPlane;
        obj.transform.position = worldPoint;
    }
}
