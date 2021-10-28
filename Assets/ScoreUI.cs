using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public Text ScoreText; // variable that keeps track of our score on screen
    public Text LivesText; // variable that keeps track of our lives on screen
    public Text GameOverText; // a text prompt when we lose
    public Button Replay; // a button to retart the game
    private void Start()
    { // set both gameover objects to be hidden when we start the game
        GameOverText.gameObject.SetActive(false);
        Replay.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + FindObjectOfType<BagMovement>().score; // continually update score and lives
        LivesText.text = "Lives: " + FindObjectOfType<BagMovement>().lives;

        if(FindObjectOfType<BagMovement>().lives <= 0) // when we run out of lives show the 2 game over objects
        {
            GameOverText.gameObject.SetActive(true);
            Replay.gameObject.SetActive(true);
            Time.timeScale = 0; // pause the game
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0); // load the scene again, refreshing everything
    }
}
