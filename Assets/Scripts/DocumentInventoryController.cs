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
    private List<Document> mockDocuments;
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

            mockDocuments = new List<Document>()
            {
                new Document("Sample Document 1", "Content of the first document"),
                new Document("Technical Report", "This report details the project findings..."),
                new Document("User Manual", "Instructions on how to use the software effectively."),
            };

            closeButton.RegisterCallback<ClickEvent>(ev => ui.rootVisualElement.style.display = DisplayStyle.None);
            inventoryList.makeItem = MakeItem;
            inventoryList.bindItem = BindItem;
            inventoryList.itemsSource = mockDocuments;
            inventoryList.RefreshItems();
            inventoryList.Rebuild();
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

        return button;
    }

    private void BindItem(VisualElement element, int index)
    {
        var button = element as Button;
        var document = mockDocuments[index];

        button.text = document.title;
        button.clicked += () =>
        {
            title.text = document.title;
            content.text = document.content;
        };
    }
}
