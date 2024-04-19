using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    public GameObject popupPanel;

    void Start()
    {
        popupPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPos);
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                popupPanel.SetActive(true);
            }
        }
    }

    public void ClosePopupPanel()
    {
        popupPanel.SetActive(false);
    }
}
