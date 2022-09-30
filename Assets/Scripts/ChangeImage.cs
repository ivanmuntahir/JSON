using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class ChangeImage : MonoBehaviour
{
    //public TextAsset JSON;
    //Reader Reader;
    JReader jReader;
    //JReader jReader;
    public string TextureURL;

  
    // Start is called before the first frame update
    void Start()
    {
        jReader = GameObject.Find("JReader").GetComponent<JReader>();
        //jReader = GameObject.Find("List").GetComponent<JReader>();
        StartCoroutine(DownloadImage(TextureURL));
        
    }

    public void GetURL(string val)
    {
        Debug.Log("Get URL from " + val);
        jReader.URLForm(TextureURL);
        //JReader.URL(TextureURL);
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            gameObject.GetComponent<Image>().sprite = webSprite;
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }


}
