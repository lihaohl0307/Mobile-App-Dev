using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{
    private Transform player;
    private GameObject interactableHint;
    private float distanceThreshold = 1f;
    private float halfWidth;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player transform not assigned to Collectible script!");
        }
        GameObject res = Resources.Load<GameObject>("interactableHint");
        interactableHint = Instantiate(res, transform.position, Quaternion.identity);
        if (interactableHint == null)
        {
            Debug.LogError("Indicator image not assigned to Collectible script!");
        }
        interactableHint.transform.SetParent(GameObject.Find("Canvas").transform, false);
        halfWidth = GetComponent<Collider2D>().bounds.size.x / 4f;

        interactableHint.SetActive(false);
    }

    public void Update()
    {
        float distance = Mathf.Abs(transform.position.x + halfWidth - player.position.x - 1);
        Debug.Log("Distance: " + distance);

        if (distance <= distanceThreshold)
        {
            // Show the icon above the collectible on screen
            Debug.Log(transform.position);
            Vector2 pos = transform.position;
            pos.x += halfWidth;
            pos.y += GetComponent<Collider2D>().bounds.size.y;
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(pos);
            interactableHint.transform.position = screenPoint;
            interactableHint.SetActive(true);
        }
        else
        {
            interactableHint.SetActive(false);
            if (interactableHint != null)
            {
                Debug.Log("not active");
            }
            else
            {
                Debug.LogError("interactableHint is null!");
            }

        }
    }
}
