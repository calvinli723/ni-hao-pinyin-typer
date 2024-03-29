using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFeed : MonoBehaviour
{
    private Queue wordFeed;
    private LinkedList<string> compoundWordQueue;
    private CompoundWordFileReader reader;
    private string lastWord = "";
    private ScoreManager scoreManager;
    private GameManager gameManager;
    public int totalWords = 0;

    [SerializeField]
    private int maxWordFeedCount = 5;

    [SerializeField]
    private int maxCompoundWordLength = 5;

    void Start()
    {
        wordFeed = new Queue();
        compoundWordQueue= new LinkedList<string>();
        reader = GameObject.Find("CompoundWordFileReader").GetComponent<CompoundWordFileReader>();
        scoreManager= GameObject.Find("Score").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void AddWord(string word)
    {
        string[] wordComponents = word.Split(',');
        wordFeed.Enqueue(word);
        lastWord = word;
        if (wordComponents[2] == "Y")
        {
            compoundWordQueue.AddLast(word);
            if (compoundWordQueue.Count > maxCompoundWordLength)
                compoundWordQueue.RemoveFirst();
            FindCompoundWords();
            scoreManager.WordSuccess();
        }
        else if (wordComponents[2] == "N")
        {
            compoundWordQueue.Clear();
            // check that word isnt initial empty word
            if (wordComponents[0] != "")
                scoreManager.WordFail();
        }
        UpdateWordFeed();
        // check that word isnt initial empty word
        if (wordComponents[0] != "")
            totalWords += 1;

        gameManager.checkEndGame();
    }

    // Show last <maxWordFeedCount> number of words
    void UpdateWordFeed()
    {
        GetComponent<TextMesh>().text = "";
        if (wordFeed.Count > maxWordFeedCount)
            wordFeed.Dequeue();

        // format each word with color to be displayed
        foreach (string word in wordFeed)
        {
            string[] word_components = word.Split(',');
            string color;

            if (word_components[2] == "Y")
                color = "lime";
            else if (word_components[2] == "C")
                color = "orange";
            else
                color = "red";
            string word_formatted = "<color=" + color + '>' + word_components[0] + ' ' + word_components[1] + "</color>";
            GetComponent<TextMesh>().text += word_formatted + '\n';
        }
    }

    void FindCompoundWords()
    {
        string compoundWord = "";
        string compoundWordPinyin = "";
        string[] lastWordComponents = lastWord.Split(',');
        LinkedListNode<string> node = compoundWordQueue.Last;

        // check that the last successful word is included in the compound word
        if (node.Value != lastWord)
            return;
        while (node != null)
        {
            string word = node.Value;
            string[] wordComponents = word.Split(',');
            compoundWord = wordComponents[1] + compoundWord;
            compoundWordPinyin = wordComponents[0] + ' ' + compoundWordPinyin;

            // Successful compound word if the word is in the compoundWords set
            if (reader.compoundWords.Contains(compoundWord))
            {
                AddWord(compoundWordPinyin + ',' + compoundWord + ",C");
                AudioSource au = GetComponent<AudioSource>();
                au.Play();
                scoreManager.CompoundWord();
            }
            node = node.Previous;
        }
     }
}
