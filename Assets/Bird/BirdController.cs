using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public GameObject gameOverPanel;
    private bool isGameOver = false;

    public float upperLimit = 5f; // Set this to the top of your screen
    public float lowerLimit = -5f; // Set this to the bottom of your screen

    public AudioSource jumpSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGameOver) return;

        if (transform.position.y > upperLimit || transform.position.y < lowerLimit)
        {
            GameOver();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        jumpSFX.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameOver) return; 

        ScoreManager.score++;
        Debug.Log("Score: " + ScoreManager.score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            // Game over
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true; 

        rb.velocity = Vector2.zero;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
