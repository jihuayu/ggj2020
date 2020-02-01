using System;
using UnityEngine;


public class GameManager : MonoBehaviour {
    private static GameManager _gm;
    public static GameManager GM => _gm;
    public float hp = 100;

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