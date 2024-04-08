using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door1 : InteractableItem
{   
    public GameObject popUpWindow;
    private string passcode = "1234";
    private InputField input;

    new void Start()
    {
        base.Start();
        // disable at the beginning
        if (popUpWindow != null) {
            popUpWindow.SetActive(false);
            input = popUpWindow.GetComponentInChildren<InputField>();
        }
    }

    new void Update()
    {
        base.Update();
        // check if door collider clicked
        if (Input.GetMouseButtonDown(0))
        {
            // get click position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the click hits the clickable area
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                // click on the door, show pop up window
                ShowPopUpWindow();
            }
        }
    }

    public void ShowPopUpWindow() {
        
        if (popUpWindow != null)
        {
            popUpWindow.SetActive(true);
        }
    }

    // Button Yes
    public void OnYesButtonClick() {
        
        //load scene
        Debug.Log("Input: " + input.text.ToString());
        if (input.text.Equals(passcode))
        {
            SceneManager.LoadScene("hall1");
        } else
        {
            input.text = "";
        }
    }

    public void OnNoButtonClick() {
        
        HidePopUpWindow();
    }

    public void HidePopUpWindow() {
        
        if (popUpWindow != null) {

            popUpWindow.SetActive(false);
        }
    }
}
