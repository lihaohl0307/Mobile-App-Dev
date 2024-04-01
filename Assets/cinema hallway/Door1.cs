using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour
{   
    public GameObject popUpWindow;

    void Start()
    {   
        // disable at the beginning
        if (popUpWindow != null) {
            popUpWindow.SetActive(false);
        }
    }

    void Update()
    {
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
        SceneManager.LoadScene("hall1");
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
