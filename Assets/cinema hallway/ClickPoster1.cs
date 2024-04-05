using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickPoster1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if poster1 collider clicked
        if (Input.GetMouseButtonDown(0))
        {
            // get click position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the click hits the clickable area
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                ///load scene
                // SceneManager.LoadScene("Poster1");
                Debug.Log("Clicked poster");
                DocumentStore.documents.Add(new Document("Note written on the hallway poster", "Don't go to the screening room next to this poster!!!\nIt almost cost my life to get out of there!"));
            }
        }
    }
}
