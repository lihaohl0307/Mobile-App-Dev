using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCurlScript : MonoBehaviour
{
    public GameObject smallPaperCurl;  
    public GameObject mediumPaperCurl; 
    public GameObject largePaperCurl; 
    public GameObject key_poster1;

    private int clickCount = 0;

    void Start()
    {
        smallPaperCurl.SetActive(false);
        mediumPaperCurl.SetActive(false);
        largePaperCurl.SetActive(false);
        key_poster1.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                clickCount++;

                switch (clickCount)
                {
                    case 1:
                        break;
                    case 2:
                        smallPaperCurl.SetActive(true);
                        mediumPaperCurl.SetActive(false);
                        largePaperCurl.SetActive(false);
                        break;
                    case 3:
                        break;
                    case 4:
                        // Disable Small Paper Curl, enable Medium Paper Curl
                        smallPaperCurl.SetActive(false);
                        mediumPaperCurl.SetActive(true);
                        break;
                    case 5:
                        break;
                    case 6:
                        // Disable Medium Paper Curl, enable Large Paper Curl
                        mediumPaperCurl.SetActive(false);
                        largePaperCurl.SetActive(true);
                        key_poster1.SetActive(true);
                        break;
                
                }
            }
        }
    }
}
