using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DocumentInventoryController : MonoBehaviour
{
    [SerializeField]
    private UIDocument ui;

    private Button closeButton;
    private ListView inventoryList;

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void InitializeUIElements()
    {
        gameObject.SetActive(true);
        if (closeButton == null || inventoryList == null)
        {
            var root = ui.rootVisualElement;
            closeButton = root.Q<Button>("closeButton");
            inventoryList = root.Q<ListView>("InventoryListView");

            closeButton.RegisterCallback<ClickEvent>(ev => ui.rootVisualElement.style.display = DisplayStyle.None);
        }
    }

    public void Display()
    {
        ui.enabled = true;
        InitializeUIElements();
        ui.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
