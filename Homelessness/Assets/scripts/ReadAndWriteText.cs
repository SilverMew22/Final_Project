using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;public class ReadAndWriteText : MonoBehaviour
{
    Text myText;
    string myString = "";

    void Start()
    {
        myText = GetComponent<Text>();
        myText.text = myString;
    }    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (c != '\n' || c != '\b')
                {
                    myString += Input.inputString;
                }
                if (c == '\b')
                {
                    Debug.Log("Backspace detected");
                    int lengthOfString = myString.Length;
                    if (lengthOfString > 1)
                    {
                        Debug.Log("String is longer than 0");
                        string myStringShortenedByOne = myString.Substring(0, lengthOfString - 2);
                        myString = myStringShortenedByOne;
                    }
                }
            }
        }
        if (myString.Contains("Weather"))
        {
            myText.color = Color.red;
            Debug.Log(myString.IndexOf("Weather"));
        }
        myText.text = myString;
    }
}

