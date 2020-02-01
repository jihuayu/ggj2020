using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class index : MonoBehaviour
{
    [Header("背景")]
    public Texture Texture;
    [Header("按钮")]
    public Texture enter;
    public Texture setting;
    public Texture about;
    public Texture exit;
    [Header("标题")]
    public Texture title;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        float x = UnityEngine.Screen.width * 0.6f;
        float y = UnityEngine.Screen.height * 0.45f;
        float dx = UnityEngine.Screen.width * 0.2f;
        float dy = dx/200*80;
        GUILayout.BeginArea(new Rect(0,0,UnityEngine.Screen.width,UnityEngine.Screen.height),Texture);
        GUI.RepeatButton(new Rect(x / 5, y / 3, 200,80), title);
        GUI.RepeatButton(new Rect(x,y-3*dy,200,60),enter);
        GUI.RepeatButton (new Rect(x,y-dy,200,60),setting);
        GUI.RepeatButton (new Rect(x,y+dy,200,60),about);
        GUI.RepeatButton (new Rect(x,y+3*dy,200,60),exit);
        GUILayout.EndArea();
    }
}
