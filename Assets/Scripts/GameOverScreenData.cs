using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreenData : MonoBehaviour
{
    static int _score = 0;
     internal static string Text { 
        get
        {
            return _score.ToString() + " POINTS";
        }    
    }

    internal static int Score
    {
        get
        {
            return _score;
        }
    }

    public static void SetScore(int score)
    {
        _score = score;
    }
}
