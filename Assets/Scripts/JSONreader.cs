using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class JSONreader : MonoBehaviour
{
    public static UserLogin userData;
    //public static Stages stagesData;
    private string json;
    public GameObject value;
    void Start()
    {
        Load(userData.name);
        
        //StartCoroutine(Load());
    }

    
    void Load(string json)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "../Scripts/userdata.json");
        string data = System.IO.File.ReadAllText(filePath);
        Debug.Log(data);

        
        //stagesData = JsonUtility.FromJson<Stages>(json);
        userData = JsonUtility.FromJson<UserLogin>(json);
        //Debug.Log(stagesData.worldName.ToString());

        //string jsonString = "{\"booth_id":\"1"\",
        //UserLogin userLogin = JsonUtility.FromJson<UserLogin>(data);
        //Debug.Log(stageData.worldName);


    }
    
}

/*
[Serializable]
public class Stages
{
    public string boothID;
    public string worldName;
    public string boothName;
    public string URL;
}

*/

[Serializable]
public class UserLogin
{
    public string user;
    public string name;
    public string displayName;
    public string userStatus;
    public string token;
}


