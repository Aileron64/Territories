using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Facebook.MiniJSON;
using System;


public class TitleButton : MonoBehaviour 
{
    public int button_index = 0;
    public Texture2D facebook;
    Color normal;

        

    void Start()
    {
        normal = guiTexture.color;
    }

    void Update()
    {
        if (HUDTest.mapActive)
        {
            guiTexture.texture = facebook;
        }
        else
        {
            guiTexture.texture = null;
        }
    }

    void OnMouseEnter()
    {
        guiTexture.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnMouseExit()
    {
        guiTexture.color = normal;
    }

    void OnMouseDown()
    {
        guiTexture.color = new Color(0.3f, 0.3f, 0.3f);


        Application.OpenURL(String.Format("https://apps.facebook.com/1568503763380867"));
    }

    void OnMouseUp()
    {
        guiTexture.color = normal;
    }

}
