using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoadImages : MonoBehaviour
{
    public GameObject[] CardsImages = new GameObject[6];

    public void Load() 
    {
        foreach(GameObject obj in CardsImages)
        {
            StartCoroutine(DownloadImage("https://picsum.photos/200", obj));
        }
    }
    
    
    IEnumerator DownloadImage(string MediaUrl, GameObject obj)
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        request.timeout = 5;
        yield return request.SendWebRequest();
        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error connection, can't load images");
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture) request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            obj.GetComponentInChildren<Image>().overrideSprite = sprite;
        }
    }
}
