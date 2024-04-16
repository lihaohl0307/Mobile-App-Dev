using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Picture1 : InteractableItem
{   
    public GameObject popUpWindow;

    new void Start()
    {
        base.Start();
        if (popUpWindow != null) {
            popUpWindow.SetActive(false);
        }
    }

    new void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
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

    public void OnYesButtonClick() {
        SceneManager.LoadScene("Mini Game1");
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
