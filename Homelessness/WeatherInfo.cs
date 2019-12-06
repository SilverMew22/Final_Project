using System.Net;
using System;
using System.IO;
using Assets;
using UnityEngine;

private WeatherInfo GetWeather()
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY));
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    StreamReader reader = new StreamReader(response.GetResponseStream());
    string jsonResponse = reader.ReadToEnd();
    WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
    return info;
}