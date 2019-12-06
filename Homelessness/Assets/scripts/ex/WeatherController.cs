using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "49fd35a8da2650013f629c4d0fce42f8";
    string key = "49fd35a8da2650013f629c4d0fce42f8";
    private const float API_CHECK_MAXTIME = 10 * 60.0f; 
    public string CityId;
    public GameObject SnowSystem;
    public GameObject RainSystem;
    private float apiCheckCountdown = API_CHECK_MAXTIME;


    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
    }
    [Serializable]
    public class WeatherInfo
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }  
        
    void Start()
    {
        StartCoroutine(GetWeather(CheckSnowStatus));
        StartCoroutine(GetWeather(CheckRainStatus));
        StartCoroutine(AskForWeather());
    }
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckSnowStatus));
            StartCoroutine(GetWeather(CheckRainStatus));
        }
    }

    public void CheckSnowStatus(WeatherInfo weatherObj)
    {
        bool snowing = weatherObj.weather[0].main.Equals("Snow");
        if (snowing)
            SnowSystem.SetActive(true);
        else
            SnowSystem.SetActive(false);
    }

    public void CheckRainStatus(WeatherInfo weatherObj)
    {
        bool raining = weatherObj.weather[0].main.Equals("Rain");
        if (raining)
            RainSystem.SetActive(true);
        else
            RainSystem.SetActive(false);
    }

    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?zip=11238&mode=xml&APPID=", CityId, API_KEY)))
        {
            yield return req.Send();
            while (!req.isDone)
            yield return null;
            byte[] result = req.downloadHandler.data;
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
            onSuccess(info);
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
            Debug.Log(www.downloadHandler.text);

        }
        else
        {
            Debug.Log(www.error + " " + www);
        }
    }
}

