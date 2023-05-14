using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFileReader : MonoBehaviour
{
    // chinese character to pinyin
    public Dictionary<string, string> wordPairs;
    public string[] words;

    [SerializeField]
    private TextAsset csvFile;
    // Start is called before the first frame update
    void Start()
    {
        readData();
    }

    // read word and pinyin pairs from csv file
    private void readData()
    {
        wordPairs = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split('\n');
        words = new string[lines.Length - 1]; // exclude last line which is empty for some reason
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string[] wordPair = lines[i].Split(',');
            if (wordPair.Length != 2) {
                Debug.LogError("Improper format of word csv file");
                return;
            }
            wordPairs[wordPair[1]] = wordPair[0];
            words[i] = wordPair[1];
        }
    }
}
