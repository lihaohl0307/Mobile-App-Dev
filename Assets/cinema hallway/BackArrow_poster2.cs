using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackArrow_poster1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get click position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // check if the click hits the clickable area
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                ///load scene
                SceneManager.LoadScene("cinema hallway");
            }
        } 
    }
}
