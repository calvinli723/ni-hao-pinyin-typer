using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TypingManager : MonoBehaviour
{
    public string currInputBuffer = "";

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = currInputBuffer;
        string input = Input.inputString;
        if (input.Equals("")) //if not typing, do nothing
            return;

        char c = input[0];

        /*
        // space to reset
        if (c == ' ')
            currInputBuffer = "";
        */
        // backspace to remove last character
        if (c == '\b' && currInputBuffer.Length > 0)
            currInputBuffer = currInputBuffer.Remove(currInputBuffer.Length-1);
        else if (Input.GetKeyDown(KeyCode.Return) || c == ' ')
        {
            checkText();
            currInputBuffer = "";
        }
        // add character to buffer
        else
            currInputBuffer += c;
    }

    // check if current input buffer matches the pinyin of any text object
    void checkText()
    {
        GameObject[] textObjects = GameObject.FindGameObjectsWithTag("Text");
        List<GameObject> matchedTextObjects = new List<GameObject>();
        foreach (GameObject obj in textObjects)
        {
            if (obj.GetComponent<TextSpawn>().GetPinyin() == currInputBuffer)
                matchedTextObjects.Add(obj);
        }

        // for any matched text object, find the text that is closest to the bottom
        float lowestY = 100;
        int matched_index = -1;
        for (int i = 0; i < matchedTextObjects.Count; i++)
        {
            TextSpawn textObj = matchedTextObjects[i].GetComponent<TextSpawn>();
            string curr_pinyin = textObj.GetPinyin();
            float curr_y_pos = textObj.transform.position.y;
            if (curr_pinyin == currInputBuffer && curr_y_pos < lowestY)
            {
                lowestY = curr_y_pos;
                matched_index = i;
            }
        }

        // matched text that is closest to the bottom
        if (matched_index != -1)
            matchedTextObjects[matched_index].GetComponent<TextSpawn>().WordMatch();
    }
}
