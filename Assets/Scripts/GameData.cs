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
        public static int InitialExtraSpeed = 10;
        public static int InitialExtraForce = 10;
        internal static int ExtraForceTimeout = 12;
        internal static int ExtraSpeedTimeout = 10;

        public static int InitialScore = 9000;
        
    }

    static int _score = 0;
    static int _currentNumberOfRockets = 0;
    static int bombCount = 0;

    static GameData()
    {
        
        Init(true);
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

    public static int ExtraSpeedTimeout { get; internal set; }
    public static int ExtraForceTimeout { get; internal set; }


    #region Shoping Hooks
    public static bool IsRocketBuyItemVisible()
    {
        return Score > 400;
    }
    public static bool IsBombBuyItemVisible()
    {
        return Score > 500;
    }

    public static bool IsForceBuytemVisible()
    {
        return Score > 1000;
    }

    internal static bool IsSpeedBuytemVisible()
    {
        return Score > 2000; //RK TODO Move to const
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

    internal static void Init(bool updateScore)
    {
        GameData.CurrentNumberOfRockets = GameData.Const.InitialNumberOfRockets;
        GameData.BombCount = GameData.Const.InitialNumberOfBombs;
        GameData.ExtraForceTimeout = 0;
        GameData.ExtraSpeedTimeout = 0;

        if (updateScore ) {
            GameData.Score = GameData.Score = GameData.Const.InitialScore;
        }

        WasShoped = false;
    }


    #endregion
}
