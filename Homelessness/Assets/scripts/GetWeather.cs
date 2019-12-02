using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GetWeather : MonoBehaviour
{
    string key = "PUTYOURKEYHERE";
    void Start()
    {
        StartCoroutine(AskForWeather());
    }
    IEnumerator AskForWeather()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://api.openweathermap.org/data/2.5/weather?zip=11238&mode=xml&APPID=" + key);
        Debug.Log("Request sent, pending response...");
        yield return www.SendWebRequest();
        if (!www.isNetworkError && !www.isHttpError)
        {
            // Get text content like this:
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.error + " " + www);
        }
    }
}