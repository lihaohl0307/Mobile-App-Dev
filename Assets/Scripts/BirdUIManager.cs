using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdUIManager : MonoBehaviour
{
    public GameObject popupWindow;

    void Start()
    {
        popupWindow.SetActive(false);
    }

    public void ShowPopupWindow()
    {
        popupWindow.SetActive(true);
    }

    public void ConfirmButtonClicked()
    {
        SceneManager.LoadScene("BirdGame");
    }

    public void CancelButtonClicked()
    {
        popupWindow.SetActive(false);
    }
}
