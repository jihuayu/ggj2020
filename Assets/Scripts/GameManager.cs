using System;
using UnityEngine;


public class GameManager : MonoBehaviour {
    private static GameManager _gm = new GameManager();
    public static GameManager GM => _gm;
    public float hp = 100;
    public static Vector2 right = new Vector2(0,10);
    public static Vector2 left = new Vector2(-10,-10);

    private void Awake () {
        _gm = this;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            //TODO: TELL GAME OVER
        }
    }
}