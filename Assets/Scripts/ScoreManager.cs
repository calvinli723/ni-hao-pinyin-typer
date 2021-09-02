using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int comboCount;
    private int wordsMatched;
    private int wordsFailed;
    private int compoundWordsMatched;
    private int totalWords;

    [SerializeField]
    private int scorePerWord = 50;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        comboCount = 0;
        wordsMatched = 0;
        wordsFailed = 0;
        compoundWordsMatched = 0;
    }

    public void WordSuccess()
    {
        comboCount += 1;
        score += comboCount * scorePerWord;
        wordsMatched += 1;
    }

    public void CompoundWord()
    {
        score *= 2;
        compoundWordsMatched += 1;
    }

    public void WordFail()
    {
        comboCount = 0;
        wordsFailed += 1;
    }

    void Update()
    {
        GetComponent<Text>().text = "Score: " + score + ", " + "Words Matched: " + wordsMatched + ", " + "Words Failed: " + wordsFailed + ", " + "Combo: " + comboCount + ", " + "Compound Words Found: " + compoundWordsMatched;
    }

}
