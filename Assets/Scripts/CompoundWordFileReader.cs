using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundWordFileReader : MonoBehaviour
{
    public HashSet<string> compoundWords;

    [SerializeField]
    private TextAsset txtFile;
    // Start is called before the first frame update
    void Start()
    {
        compoundWords = new HashSet<string>();
        readData();
    }

    void readData()
    {
        string[] lines = txtFile.text.Split('\n');
        for (int i = 0; i < lines.Length - 1; i++)
        {
            compoundWords.Add(lines[i].Replace(" ", ""));
        }
    }
}
