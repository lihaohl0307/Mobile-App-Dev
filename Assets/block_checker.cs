using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class block_checker : MonoBehaviour
{
    float countdown = 2f;
    bool blocking = false;
    public ClearSky.DemoCollegeStudentController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<ClearSky.DemoCollegeStudentController>();
        if (player == null )
        {
            Debug.Log("didn't get the player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (blocking)
            countdown -= Time.deltaTime;
        if (countdown <= 0 )
        {
            player.Die();
            StartCoroutine(loadSceneAfterDelay());
        }
    }

    IEnumerator loadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        blocking = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        blocking = false;
        countdown = 2f;
    }
}
