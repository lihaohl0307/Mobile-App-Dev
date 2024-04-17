using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_script : InteractableItem
{
    bool used = false;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0) && !used)
        {
            // get click position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the click hits the clickable area
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                used = true;
                Debug.Log("Clicked poster");
                DocumentStore.documents.Add(new Document("Notebook in the theater", "Shhh... leave while they're still watching the movie!\nOtherwise, they'll come looking for you when the movie ends!\nThe theater exit is on the right.\nThey like to sit in odd-numbered seats.\nDon't block their view for too long!"));
            }
        }
    }
}
