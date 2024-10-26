using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms.Impl;

public class GameData : MonoBehaviour
{
    public static class Const {
        public static int Rockets = 24;
        public static int InitialRockets = 12;
    }

    static int _score = 0;
    static int _currentNumberOfRockets = 0;
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

        set
        {
            _score = value;
        }
    }

    internal static int CurrentNumberOfRockets
    {
        get
        {
            return _currentNumberOfRockets;
        }

        set
        {
            _currentNumberOfRockets = value;
        }
    }

    public static bool EnableBombHUD { get; internal set; }


    public int ExtraRockets { get; set; }

    public bool IsExtraBombEnabled { get; set; }

    public bool IsExtraHelpEnabled { get; set; }

    #region Shoping Hooks
    public static bool IsRocketVisible()
    {
        return true;
        return Score > 400;
    }
    public static bool IsBombVisible()
    {
        return true;
        return Score > 500;
    }

    public static bool IsHealthVisible()
    {
        return true;
        return Score > 400;
    }
    #endregion


    #region Menu Hooks
    public static bool IsSecondScreenVisible()
    {
        return true;
        return Score > 1000;
    }

    public static bool IsThirdScreenVisible()
    {
        return true;
        return Score > 2000;
    }

    public static bool IsForthScreenVisible()
    {
        return true;
        return Score > 3000;
    }

    public static bool IsFifthScreenVisible()
    {
        return true;
        return Score > 4000;
    }

    public static bool IsUnlimimtedBombs()
    {
        return false;
    }

    public static bool IsSlowMotion()
    {
        return false;
    } 
    #endregion
}
