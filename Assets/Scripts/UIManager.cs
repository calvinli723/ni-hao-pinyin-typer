using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    ScoreManager scoreManager;
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameManager.gameEnded)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            } else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }


   public void showPaused()
   {
        foreach(GameObject g in pauseObjects)
            g.SetActive(true);
   }

   public void hidePaused()
   {
        foreach(GameObject g in pauseObjects)
            g.SetActive(false);
   }

   public void showFinalScore()
   {
        GameObject finalScorePanel = GameObject.Find("FinalScore").transform.Find("Panel").gameObject;
        finalScorePanel.SetActive(true);
        scoreManager.showFinalScore(finalScorePanel);
   }

   public void exitGame()
   {
        Application.Quit();
   }

   public void Menu()
   {
        SceneManager.LoadScene("MainMenu");
   }

   public void PlayAgain()
   {
        Debug.Log("Reloading scene");
        SceneManager.LoadScene("nihao");
   }
}
