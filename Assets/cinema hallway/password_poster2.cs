using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class password_poster2 : MonoBehaviour
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
                Debug.Log("Clicked poster2");
                DocumentStore.documents.Add(new Document("Numbers written on the ticket", "Password: 1234"));
            }
        }
    }
}
