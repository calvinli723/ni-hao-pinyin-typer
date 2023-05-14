using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int streakCount;
    private int wordsMatched;
    private int wordsFailed;
    private int compoundWordsMatched;
    private int totalWords;
    private int maxStreak;

    [SerializeField]
    private int scorePerWord = 50;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        streakCount = 0;
        wordsMatched = 0;
        wordsFailed = 0;
        compoundWordsMatched = 0;
        maxStreak = 0;
        
    }

    public void WordSuccess()
    {
        streakCount += 1;
        score += streakCount * scorePerWord;
        wordsMatched += 1;
        if (streakCount > maxStreak)
            maxStreak = streakCount;
    }

    public void CompoundWord()
    {
        score *= 2;
        compoundWordsMatched += 1;
    }

    public void WordFail()
    {
        streakCount = 0;
        wordsFailed += 1;
    }

    void Update()
    {
        GetComponent<Text>().text = "Score: " + score + ", " + "Words Matched: " + wordsMatched + ", " + "Words Failed: " + wordsFailed + ", " + "streak: " + streakCount + ", " + "Compound Words Found: " + compoundWordsMatched;
    }

    int successPercent()
    {
        totalWords = wordsFailed + wordsMatched;
        double proportion = (double) wordsMatched / totalWords;
        return (int) (proportion * 100);
    }

    public void showFinalScore(GameObject finalScorePanel)
    {
        string out_string = "";
        TMP_Text finalScoreText = finalScorePanel.transform.Find("FinalScoreText").gameObject.GetComponent<TMP_Text>();
        out_string += "Final Score: " + score + "\n";
        out_string += "Success Rate: " + successPercent() + "%\n";
        out_string += "Words Matched: " + wordsMatched + "\n";
        out_string += "Words Failed: " + wordsFailed + "\n";
        out_string += "Compound words found: " + compoundWordsMatched + "\n";
        out_string += "Max streak: " + maxStreak;

        finalScoreText.text = out_string;
    }

}
