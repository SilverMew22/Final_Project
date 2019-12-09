﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GetWeather : MonoBehaviour
{
    string key = "49fd35a8da2650013f629c4d0fce42f8";
    public string theData;
    //public bool Contains(string theData, startIndex);
    int startIndex = 0;
    void Start()
    {
        StartCoroutine(AskForWeather());
        //if (theData == "0")
        //{
        //    Debug.Log("yes");
        //}
        //else
        //{
        //    Debug.Log("no");
        //}

        if (theData.Contains("hello"))
            Debug.Log("It says hello");
        else
            Debug.Log("It doesn't say hello");
    }
    void Update()
    {
        if (theData.Contains("rain"))
        {
            Debug.Log("rain");
        }
        else
        {
            Debug.Log("no rain");
        }
    }
    IEnumerator AskForWeather()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://api.openweathermap.org/data/2.5/weather?zip=11238&mode=xml&APPID=" + key);
        Debug.Log("Request sent, pending response...");
        yield return www.SendWebRequest();
        if (!www.isNetworkError && !www.isHttpError)
        {
            // Get text content like this:
            theData = www.downloadHandler.text;
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.error + " " + www);
        }
    }
}
//http://api.openweathermap.org/data/2.5/weather?zip=11238&mode=xml&APPID=49fd35a8da2650013f629c4d0fce42f8