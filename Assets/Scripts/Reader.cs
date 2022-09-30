using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reader : MonoBehaviour
{
    public TextAsset textJSON;

    [Serializable]
    public class Booth
    {
        public int booth_id;
        public string world_name;
        public string booth_name;
        public string logo_url;
        public List<Contents> screen;
        public List<Contents> booth_content;
    }

    [Serializable]
    public class Contents
    {
        public string type;
        public string url;

    }

    public Booth myBoothList = new Booth();

    // Start is called before the first frame update
    void Start()
    {
        myBoothList = JsonUtility.FromJson<Booth>(textJSON.text);

    }

    public void URLForm(string val)
    {
        //Debug.Log("URL = " + val);
        myBoothList.logo_url = val;
    }
}
