using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class ButtonActionsScript : MonoBehaviour
{
    private int i;

    [SerializeField]
    public TextMeshProUGUI wackyText;
    
    private void Awake()
    {
        Debug.Log("Awake!");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is any touch or mouse click
        /*
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Handle the touch or click event here
            SetText($"{DateTime.Now.ToFileTimeUtc()}");
        }
        */
        /*
        if (Input.mousePresent && Mouse.current?.leftButton.wasPressedThisFrame == true)
        {
            Debug.Log("left button pressed");
            Vector3 mousePos = Mouse.current.position.ReadValue();   
            mousePos.z = Camera.main.nearClipPlane;
            Debug.Log($"pos is {mousePos.ToString()}");
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousePos);  
            GameObject smallObject = Instantiate(smallObjectPrefab, canvasTransform);
            smallObject.transform.position = worldpos;
        }
*/
        /*
        if (Touchscreen.current?.touches.Count > 0)
        {
            Debug.Log("touched!");
            Vector3 touch = Touchscreen.current.position.ReadValue();
            Debug.Log($"Touch Screen Position: {touch}");
            var world = Camera.main.ScreenToWorldPoint(touch);
            Debug.Log($"Touch World Position: {world}");
            GameObject smallObject = Instantiate(smallObjectPrefab, canvasTransform);
            smallObject.transform.position = world; 
        }
        */

/*        if (Input.touchSupported && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("touched!");
            Vector3 touchPos = Input.touches[0].position;
            touchPos.z = Camera.main.nearClipPlane;
            Debug.Log($"pos is {touchPos.ToString()}");
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(touchPos);  
            GameObject smallObject = Instantiate(smallObjectPrefab, canvasTransform);
            smallObject.transform.position = worldpos; 
        }
        */
        /*
        if (Input.GetMouseButtonDown(0))
        {
           Debug.Log("mouse button");
            // Convert the touch position to world space
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Canvas"))
            {
                // Instantiate a new small object within the canvas
                GameObject smallObject = Instantiate(smallObjectPrefab, canvasTransform);
                smallObject.transform.position = hit.point;
            }

            // Optionally, destroy the small object after a short delay
            //Destroy(smallObjectPrefab, 1.0f); 
        }
        */
        
        /*
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is "Began"
            if (touch.phase == TouchPhase.Began)
            {
                // Convert the touch position to world space
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Instantiate the small object at the touch position
                Instantiate(smallObjectPrefab, touchPosition, Quaternion.identity);

                // Optionally, destroy the small object after a short delay
                //Destroy(smallObjectPrefab, 1.0f);
            }
        } 
        */
        
    }
   
    public void OnClick()
    {
        Debug.Log("button clicked");
        i++;
        SetText($"Number is {i}");
    }

    private void SetText(string s)
    {
        if (wackyText != null)
        {
            wackyText.text = s;
        }
    }
}
