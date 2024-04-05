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
    private Label title;
    private Label content;

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
            title = root.Q<Label>("Title");
            content = root.Q<Label>("Content"); 

            closeButton.RegisterCallback<ClickEvent>(ev => ui.rootVisualElement.style.display = DisplayStyle.None);
            inventoryList.makeItem = MakeItem;
            inventoryList.bindItem = BindItem;
            inventoryList.itemsSource = DocumentStore.documents;
        }
    }

    public void Display()
    {
        ui.enabled = true;
        InitializeUIElements();
        ui.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    private VisualElement MakeItem()
    {
        var button = new Button();
        button.AddToClassList("list-view-item");
        button.style.flexWrap = Wrap.Wrap;

        return button;
    }

    private void BindItem(VisualElement element, int index)
    {
        var button = element as Button;
        var document = DocumentStore.documents[index];

        button.text = document.title;
        button.clicked += () =>
        {
            title.text = document.title;
            content.text = document.content;
        };
    }
}
