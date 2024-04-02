using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    public UIDocument menuUI;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("InventoryButton").RegisterCallback<ClickEvent>(OnInventoryButtonClicked);

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnInventoryButtonClicked(ClickEvent ev)
    {
        // Refetch the UIDocument reference when needed
        UIDocument menuUIObj = menuUI.GetComponent<UIDocument>();
        if (menuUIObj != null)
        {
            menuUIObj.GetComponent<DocumentInventoryController>().Display();
        }
    }
}
