using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class EditorInformationPanel : EditorWindow
{
    private static Texture2D _image;
    
    static EditorInformationPanel()
    {
        //First Time
        var hasFirstImport = PlayerPrefs.GetInt( "HasFirstImport");
        if( hasFirstImport == 0 )
        {
            ShowWindow();
            PlayerPrefs.SetInt("HasFirstImport", 1);
        }
    }

    [MenuItem("Prototype/About")]
    public static void ShowWindow()
    {
        _image = Resources.Load("Textures/INFORMATION", typeof(Texture2D)) as Texture2D;
        var window = GetWindow<EditorInformationPanel>("Prototype Setup Information");
        var position = window.position;
        position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
        window.position = position;
        window.Show();
    }
    
    void OnGUI()
    {
        GUI.contentColor = Color.white;
        GUILayout.Label(_image);
        
        Rect textHeaderRectVersion = new Rect(310, 50, 100, 60);
        GUIStyle headerTextStyle = new GUIStyle();
        headerTextStyle.fontSize = 50;
        headerTextStyle.fontStyle = FontStyle.Bold;
        EditorGUI.LabelField(textHeaderRectVersion, "Prototype Helper", headerTextStyle);
        
        Rect textSubTitleRectVersion = new Rect(460, 120, 100, 60);
        GUIStyle subtitleTextStyle = new GUIStyle();
        subtitleTextStyle.fontSize = 20;
        EditorGUI.LabelField(textSubTitleRectVersion, "Isa Tezcan", subtitleTextStyle);
        
        //Social Media Buttons
        Rect buttonRectLinkedin = new Rect(410, 230, 100, 60);
        if (GUI.Button(buttonRectLinkedin, "Linkedin"))
        {
            Application.OpenURL("https://www.linkedin.com/in/isa-tezcan-4080b5a4/");
        }
        
        Rect buttonRectInstagram = new Rect(520, 230, 100, 60);
        if (GUI.Button(buttonRectInstagram, "Instagram"))
        {
            Application.OpenURL("https://www.instagram.com/isatezcan_/");
        }
        
        Rect textRectVersion = new Rect(480, 280, 100, 60);
        EditorGUI.LabelField(textRectVersion, "Version:(1.2)");
    }
}