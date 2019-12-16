using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetWeather : MonoBehaviour
{
    string key = "49fd35a8da2650013f629c4d0fce42f8";
    public string theData;
    //public bool Contains(string theData, startIndex);
    int startIndex = 0;
    public GameObject rain;
    public GameObject snow;    

    public static int Length { get; internal set; }

    public static int IndexOf { get; internal set; }


    void Start()
    {  
    StartCoroutine(AskForWeather());
    }

    internal static string Substring(int v1, int v2)
    {
    throw new NotImplementedException();
    }

    
    void Update()
    {
        //check for rain
        if (theData.Contains("rain"))
        {
            Debug.Log("rain");
            rain.SetActive(true);
            snow.SetActive(false);            
        }
        else
        {
            Debug.Log("no rain");
        }
        //check for snow
        if (theData.Contains("snow"))
        {
            Debug.Log("snow");
            snow.SetActive(true);
            rain.SetActive(false);            
        }
        else
        {
            Debug.Log("no snow");
        }

        //check for temperature
        if (theData.Contains("temperature value="))
        {
            Debug.Log("there is a temp val we need to find");           
            }
        else
        {
            Debug.Log("no snow");
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

    internal static bool Contains(string v)
    {
        throw new NotImplementedException();
    }
    void ReadTemp()
    {
        if (theData.Length < 8)
        {
            Debug.Log("Password not long enough!");
        }
        //Check if the length of the string is more than or equal to 8
        if (theData.Length >= 8)
        {
            Debug.Log("Password Accepted!");
        }
    }
}
//http://api.openweathermap.org/data/2.5/weather?zip=11238&mode=xml&APPID=49fd35a8da2650013f629c4d0fce42f8
//equation to convert kelvin to c
//(0K − 273.15) × 9/5 + 32 =
//https://docs.unity3d.com/ScriptReference/String.Length.html
//<temperature value="285.65" min="283.71" max="287.59" unit="kelvin"></temperature>