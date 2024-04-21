using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    private void Update()
    {
        // Update the text field with the current score
        scoreText.text = "Current Score: " + score.ToString();
    }


    public void OnRestartButtonClick() // Connect this function to your button's onClick event in the inspector
    {
        score = 0;
        SceneManager.LoadScene("hall1");
    }
}
