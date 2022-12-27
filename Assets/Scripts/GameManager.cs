using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private int numWords;

    [SerializeField] private int maxWordsPerRound = 100;
    [SerializeField] private int mode;
    
    private WordFeed wordFeed;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        wordFeed = GameObject.Find("WordFeed").GetComponent<WordFeed>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        for (int i = 0; i < numWords; i++) {
            Instantiate(prefab, spawnPosition, Quaternion.AngleAxis(-90, new Vector3(1, 0, 0)));
        }
    }

    public void checkEndGame()
    {
        Debug.Log("checking End Game");
        // limited words mode
        if (mode == 0)
        {
            Debug.Log("checking total word count");
            if (wordFeed.totalWords >= maxWordsPerRound)
            {
                endGame();
            }

        }

        // survival mode
        else if (mode == 1)
        {

        }

        // 
        else if (mode == 2)
        {

        }

        // time limit mode
        else if (mode == 3)
        {

        }

    }

    void endGame()
    {
        Debug.Log("Game has ended");
    }

    // Update is called once per frame
    void Update()
    {
        // check for mode ending based on time passed
        if (mode == 3)
        {
            checkEndGame();
        }
        
    }
}
