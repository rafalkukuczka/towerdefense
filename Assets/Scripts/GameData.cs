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
        public static int RocketsInCrate = 24;
        public static int InitialNumberOfRockets = 12;
        public static int InitialNumberOfBombs = 0;
        public static int InitialTotalPayments = 0;
    }

    static int _score = 0;
    static int _currentNumberOfRockets = 0;
    static int bombCount = 0;

    static GameData()
    {
        Score = 800;
    }
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

    internal static bool WasShoped { get; set; }

    internal static int CurrentNumberOfRockets
    {
        get
        {
            //Debug.Break();
            return _currentNumberOfRockets;
        }

        set
        {
            //Debug.Break();
            _currentNumberOfRockets = value;
        }
    }

    internal static int BombCount
    {
        get { return bombCount; }
        set { bombCount = value; }
    }


    #region Shoping Hooks
    public static bool IsRocketBuyItemVisible()
    {
        return Score > 400;
    }
    public static bool IsBombBuyItemVisible()
    {
        return Score > 500;
    }

    public static bool IsHealthBuyItemVisible()
    {
        return Score > 1000;
    }
    #endregion

    #region Menu Hooks
    public static bool IsSecondLevelVisible()
    {
        return Score > 1000;
    }

    public static bool IsThirdLevelVisible()
    {
        return Score > 2000;
    }

    public static bool IsForthLevelVisible()
    {
        return Score > 3000;
    }

    public static bool IsFifthLevelVisible()
    {
        return Score > 4000;
    }

    #endregion

    #region DEBUG Hooks
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
